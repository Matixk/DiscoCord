using System.Collections.Generic;
using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Users;

namespace DiscoCordAPI.Models.Servers
{
    public class Server
    {
        public int Id { get; private set; }
        public User Owner { get; set; }
        public virtual List<Channel> Channels { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }

        public Server(int id, User owner, List<Channel> channels, string name, bool isPrivate)
        {
            Id = id;
            Owner = owner;
            Channels = channels;
            Name = name;
            IsPrivate = isPrivate;
        }
    }
}
