using aspnetserver.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Net;
using System.Text.Json.Serialization;

namespace aspnetserver.Data.DTOs
{
    public class HomePostDTO
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int CommentCount { get; set; }
        public int Views { get; set; }
        public int LastCommentUserId { get; set; }
        public string LastCommentUsername { get; set; }
        public DateTime LastCommentDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [JsonConstructor]
        public HomePostDTO() { }

        public HomePostDTO(Post post)
        {
            PostId = post.PostId;
            Title = post.Title;
            CategoryId = post.CategoryId;
            CategoryTitle = post.Category.Title;
            UserId = post.UserId;
            Username = post.User.Username;
            CommentCount = post.Comments.Count;
            Views = post.Views;
            LastCommentUserId = post.LastComment.User.UserId;
            LastCommentUsername = post.LastComment.User.Username;
            LastCommentDate = post.LastComment.CreatedDate;
            CreatedDate = post.CreatedDate;
        }
    }
}
