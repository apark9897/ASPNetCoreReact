using aspnetserver.Data;
using aspnetserver.Data.DTOs;
using aspnetserver.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace aspnetserver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public CategoriesController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<HomeCategoryDTO>>> GetHomePageCategoriesAsync()
        {
            List<HomeCategoryDTO> categoriesToReturn = await _dbContext.Categories
                .Include(e => e.Posts)
                .OrderByDescending(e => e.Posts.Count)
                .Select(e => new HomeCategoryDTO(e))
                .ToListAsync();
            if (categoriesToReturn.Count > 0)
            {
                return Ok(categoriesToReturn);
            }
            return BadRequest("No categories found");
        }
    }
}
