using aspnetserver.Data;
using aspnetserver.Data.DTOs;
using aspnetserver.Data.Models;
using global::aspnetserver.Data.DTOs;
using global::aspnetserver.Data.Models;
using global::aspnetserver.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace aspnetserver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration, AppDBContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(CreateUserDTO createUserDTO)
        {
            CreatePasswordHash(createUserDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User userToCreate = new User(createUserDTO);
            userToCreate.PasswordSalt = passwordSalt;
            userToCreate.PasswordHash = passwordHash;
            await _dbContext.Users.AddAsync(userToCreate);
            if (await _dbContext.SaveChangesAsync() >= 1)
            {
                return Ok("User created successfully");
            }
            return BadRequest("User failed to create");
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            User validateUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Username == loginDTO.Username);
            if (validateUser == null) return BadRequest("User does not exist");
            if(!VerifyPasswordHash(loginDTO.Password, validateUser.PasswordSalt, validateUser.PasswordHash))
            {
                return BadRequest("Incorrect pw");
            }

            string token = await CreateToken(validateUser);
            return Ok(token);
        }

        private async Task<string> CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            List<UserRole> userRoles = await _dbContext.Roles
                .Where(r => r.UserId == user.UserId)
                .ToListAsync();
            foreach (UserRole userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.RoleId));
            }
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
