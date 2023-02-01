using aspnetserver.Data.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetserver.Data.Models
{
    public class User : IEntityDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Email { get; set; } = string.Empty;

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        public Avatar Avatar { get; set; }
        public ICollection<UserRole>? Roles { get; set; }
        public ICollection<UserLike>? Likes { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public User() { }

        public User(CreateUserDTO createUserDTO)
        {
            Username = createUserDTO.Username;
            Email = createUserDTO.Email;
        }
    }
}
