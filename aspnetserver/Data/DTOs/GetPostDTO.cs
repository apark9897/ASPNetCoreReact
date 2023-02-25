using aspnetserver.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Net;
using System.Text.Json.Serialization;

namespace aspnetserver.Data.DTOs
{
    public class GetPostDTO
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int CommentCount { get; set; }
        public int Views { get; set; }
        public DateTime CreatedDate { get; set; }

        [JsonConstructor]
        public GetPostDTO() { }

        public GetPostDTO(Post post)
        {
            PostId = post.PostId;
            Title = post.Title;
            Content = post.Content;
            CategoryId = post.CategoryId;
            CategoryTitle = post.Category.Title;
            UserId = post.UserId;
            Username = post.User.Username;
            CommentCount = post.Comments.Count;
            Views = post.Views;
            CreatedDate = post.CreatedDate;
        }
    }
}
