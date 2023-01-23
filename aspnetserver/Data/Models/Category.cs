using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public ICollection<Post>? Posts { get; set; }
    }
}
