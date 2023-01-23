using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Email { get; set; } = string.Empty;

        public ICollection<UserRole>? Roles { get; set; }
    }
}
