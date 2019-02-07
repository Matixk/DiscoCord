using System.ComponentModel.DataAnnotations;

namespace DiscoCordAPI.Models.Servers
{
    public class ServerForUpdateDto
    {
        [Required] [MaxLength(50)] public string Name { get; set; }

        [Required] public bool IsPrivate { get; set; }
    }
}
