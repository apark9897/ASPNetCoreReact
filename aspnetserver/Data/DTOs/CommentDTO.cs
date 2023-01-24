using aspnetserver.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace aspnetserver.Data.DTOs
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public int ups { get; set; }
        public int downs { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        [JsonConstructor]
        public CommentDTO() { }

        public CommentDTO(Comment comment)
        {
            CommentId = comment.CommentId;
            Content = comment.Content;
            ups = comment.ups;
            downs = comment.downs;
            PostId = comment.PostId;
            UserId = comment.UserId;
        }
    }
}
