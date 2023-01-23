using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetserver.Data.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }


        [Required]
        [MaxLength(100000)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [ForeignKey("PostId")]
        public Post? Post { get; set; }
        public int PostId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }

        [Required]
        public int ups { get; set; } = 0;
        [Required]
        public int downs { get; set; } = 0;
    }
}
