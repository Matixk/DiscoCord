using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DiscoCordAPI.Models.Messages;
using DiscoCordAPI.Models.Servers;

namespace DiscoCordAPI.Models.Channels
{
    public class Channel
    {
        public int Id { get; private set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Server Server { get; set; }
        public virtual List<Message> Messages { get; set; } = new List<Message>();

        public Channel(int id, Server server, string name)
        {
            Id = id;
            Server = server;
            Name = name;
        }

        public Channel()
        {
        }
    }
}
