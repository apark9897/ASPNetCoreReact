using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetserver.Data.Models
{
    public class CategoryImage
    {
        [ForeignKey("Category")]
        public int CategoryImageId { get; set; }

        public byte[] ImageData { get; set; }
        public Category Category { get; set; }
    }
}
