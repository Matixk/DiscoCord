using System.Collections.Generic;

namespace DiscoCordAPI.Models.Servers
{
    public class ServerPreviewDto
    {
        public int Id { get; private set; }

        public BasicPreviewDto Owner { get; set; }

        public string Name { get; set; }

        public bool IsPrivate { get; set; }

        public virtual List<BasicPreviewDto> Users { get; set; }
        public virtual List<BasicPreviewDto> Channels { get; set; }
    }
}
