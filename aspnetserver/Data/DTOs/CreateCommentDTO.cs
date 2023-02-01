using aspnetserver.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace aspnetserver.Data.DTOs
{
    public class CreateCommentDTO
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public int PostId { get; set; }
        public int UserId { get; set; }

        [JsonConstructor]
        public CreateCommentDTO() { }

        public CreateCommentDTO(Comment comment)
        {
            CommentId = comment.CommentId;
            Content = comment.Content;
            PostId = comment.PostId;
            UserId = comment.UserId;
        }
    }
}
