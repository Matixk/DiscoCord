using System.Collections.Generic;
using DiscoCordAPI.Models.Messages;
using DiscoCordAPI.Models.Servers;

namespace DiscoCordAPI.Models.Channels
{
    public class Channel
    {
        public int Id { get; private set; }
        public Server Server { get; set; }
        public string Name { get; set; }
        public virtual List<Message> Messages { get; set; } = new List<Message>();

        public Channel(int id, Server server, string name)
        {
            Id = id;
            Server = server;
            Name = name;
        }
    }
}
