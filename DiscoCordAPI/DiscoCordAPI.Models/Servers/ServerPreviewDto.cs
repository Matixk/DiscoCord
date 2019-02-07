using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Users;

namespace DiscoCordAPI.Models.Servers.Dto
{
    public class ServerPreviewDto
    {
        public int Id { get; private set; }

        public User Owner { get; set; }

        public string Name { get; set; }

        public bool IsPrivate { get; set; }

        public virtual List<BasicPreviewDto> Users { get; set; }
        public virtual List<BasicPreviewDto> Channels { get; set; }
    }
}
