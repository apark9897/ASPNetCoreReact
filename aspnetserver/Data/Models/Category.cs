using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Data.Models
{
    public class Category : IEntityDate
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; }

        public ICollection<Post>? Posts { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
