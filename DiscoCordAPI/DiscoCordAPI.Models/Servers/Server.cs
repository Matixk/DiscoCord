using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Users;

namespace DiscoCordAPI.Models.Servers
{
    public class Server : Entity
    {
        public Server(string name, User owner, bool isPrivate)
        {
            Owner = owner;
            Name = name;
            IsPrivate = isPrivate;
            Users = new List<User>();
            Channels = new List<Channel>();
        }

        public Server()
        {
        }

        [Required] public User Owner { get; set; }

        [Required] [MaxLength(50)] public string Name { get; set; }

        [Required] public bool IsPrivate { get; set; }

        public virtual List<User> Users { get; set; }
        public virtual List<Channel> Channels { get; set; }
    }
}