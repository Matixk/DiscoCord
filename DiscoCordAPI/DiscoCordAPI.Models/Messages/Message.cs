using System;
using System.ComponentModel.DataAnnotations;
using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Users;

namespace DiscoCordAPI.Models.Messages
{
    public class Message
    {
        public int Id { get; private set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime Date { get; private set; }

        [Required]
        public User Author { get; set; }
        [Required]
        public Channel Channel { get; set; }

        public Message(int id, Channel channel, User author, string content)
        {
            Id = id;
            Author = author;
            Channel = channel;
            Content = content;
            Date = DateTime.Now;
        }

        public Message()
        {
        }
    }
}
