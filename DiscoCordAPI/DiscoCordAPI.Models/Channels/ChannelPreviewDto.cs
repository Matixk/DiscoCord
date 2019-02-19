using System.Collections.Generic;
using DiscoCordAPI.Models.Messages;
using DiscoCordAPI.Models.Servers;

namespace DiscoCordAPI.Models.Channels
{
    public class ChannelPreviewDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Server Server { get; set; }

        public virtual List<Message> Messages { get; set; } = new List<Message>();
    }
}
