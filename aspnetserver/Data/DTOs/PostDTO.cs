using aspnetserver.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Net;
using System.Text.Json.Serialization;

namespace aspnetserver.Data.DTOs
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        [JsonConstructor]
        public PostDTO() { }

        public PostDTO(Post post)
        {
            PostId = post.PostId;
            Title = post.Title;
            Content = post.Content;
            CategoryId = post.CategoryId;
            UserId = post.UserId;
        }
    }
}
