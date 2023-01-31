using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetserver.Data.Models
{
    public class Avatar
    {
        [ForeignKey("User")]
        public int AvatarId { get; set; }

        public byte[] ImageData { get; set; }
        public User User { get; set; }
    }
}
