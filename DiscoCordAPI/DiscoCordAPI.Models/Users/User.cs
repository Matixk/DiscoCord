﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DiscoCordAPI.Models.Servers;

namespace DiscoCordAPI.Models.Users
{
    public class User : Entity
    {
        public User(string name, byte[] passwordHash, byte[] passwordSalt)
        {
            Name = name;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public User()
        {
        }

        [Required] [MaxLength(25)] public string Name { get; set; }

        [Required] public byte[] PasswordHash { get; set; }

        [Required] public byte[] PasswordSalt { get; set; }

        public virtual List<Server> OwnedServers { get; set; } = new List<Server>();
        public virtual List<Server> ConnectedServers { get; set; } = new List<Server>();
    }
}