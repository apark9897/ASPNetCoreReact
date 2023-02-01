using aspnetserver.Data.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetserver.Data.Models
{
    public class Comment : IEntityDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }


        [Required]
        [MaxLength(100000)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [InverseProperty("Comments")]
        public Post? Post { get; set; }
        public int PostId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }

        public ICollection<UserLike>? Likes { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Comment()
        {
        }
        public Comment(CreateCommentDTO commentDTO)
        {
            CommentId = commentDTO.CommentId;
            Content = commentDTO.Content;
            PostId = commentDTO.PostId;
            UserId = commentDTO.UserId;
        }
    }
}
