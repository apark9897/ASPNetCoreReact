using aspnetserver.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Net;
using System.Text.Json.Serialization;

namespace aspnetserver.Data.DTOs
{
    public class HomeCategoryDTO
    {
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public int PostCount { get; set; }

        [JsonConstructor]
        public HomeCategoryDTO() { }

        public HomeCategoryDTO(Category category)
        {
            CategoryId = category.CategoryId;
            Title = category.Title;
            Description = category.Description;
            PostCount = category.Posts.Count;
        }
    }
}
