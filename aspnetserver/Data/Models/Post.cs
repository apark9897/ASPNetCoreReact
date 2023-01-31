using aspnetserver.Data.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetserver.Data.Models
{
    public class Post : IEntityDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100000)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("LastCommentId")]
        public Comment? LastComment { get; set; }

        public int Views { get; set; } = 0;

        public Post()
        {
        }

        public Post(PostDTO postDTO)
        {
            PostId = postDTO.PostId;
            Title = postDTO.Title;
            Content = postDTO.Content;
            CategoryId = postDTO.CategoryId;
            UserId = postDTO.UserId;
        }
    }
}
