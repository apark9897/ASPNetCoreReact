using aspnetserver.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace aspnetserver.Data.DTOs
{
    public class GetCommentDTO
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public ICollection<LikedUserDTO> Likes { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        [JsonConstructor]
        public GetCommentDTO() { }

        public GetCommentDTO(Comment comment)
        {
            CommentId = comment.CommentId;
            Content = comment.Content;
            PostId = comment.PostId;
            UserId = comment.UserId;
            Likes = new List<LikedUserDTO>();
            foreach (UserLike user in comment.Likes)
            {
                Likes.Add(new LikedUserDTO
                {
                    UserId = user.User.UserId,
                    Username = user.User.Username,
                });
            }
        }
    }

    public class LikedUserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public LikedUserDTO() { }
        public LikedUserDTO(User user)
        {
            UserId = user.UserId;
            Username = user.Username;
        }
    }
}
