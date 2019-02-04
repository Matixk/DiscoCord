using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DiscoCordAPI.Models.Servers;

namespace DiscoCordAPI.Models.Users
{
    public class User
    {
        public int Id { get; private set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }

        public virtual List<Server> OwnedServers { get; set; }
        public virtual List<Server> ConnectedServers { get; set; }

        public User(int id, string name, byte[] passwordHash, byte[] passwordSalt)
        {
            Id = id;
            Name = name;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            OwnedServers = new List<Server>();
            ConnectedServers = new List<Server>();
        }

        public User()
        {
        }
    }
}
