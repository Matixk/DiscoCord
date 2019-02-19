using System.ComponentModel.DataAnnotations;

namespace DiscoCordAPI.Models.Channels
{
    public class ChannelForCreateDto
    {
        [Required] [MaxLength(50)] public string Name { get; set; }

        [Required] public int ServerId { get; set; }
    }
}
