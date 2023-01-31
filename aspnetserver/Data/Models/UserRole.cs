using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetserver.Data.Models
{
    public class UserRole : IEntityDate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string RoleId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId;

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
