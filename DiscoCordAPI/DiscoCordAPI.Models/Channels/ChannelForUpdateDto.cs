using System.ComponentModel.DataAnnotations;

namespace DiscoCordAPI.Models.Channels
{
    public class ChannelForUpdateDto
    {
        [Required] [MaxLength(50)] public string Name { get; set; }
    }
}
