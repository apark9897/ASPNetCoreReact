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

        [Required]
        public int ups { get; set; } = 0;
        [Required]
        public int downs { get; set; } = 0;

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Comment()
        {
        }
        public Comment(CommentDTO commentDTO)
        {
            CommentId = commentDTO.CommentId;
            Content = commentDTO.Content;
            PostId = commentDTO.PostId;
            UserId = commentDTO.UserId;
            ups = commentDTO.ups;
            downs = commentDTO.downs;
        }
    }
}
