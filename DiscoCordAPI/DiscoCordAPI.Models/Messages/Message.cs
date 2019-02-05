using System;
using System.ComponentModel.DataAnnotations;
using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Users;

namespace DiscoCordAPI.Models.Messages
{
    public class Message
    {
        public Message(Channel channel, User author, string content)
        {
            Author = author;
            Channel = channel;
            Content = content;
            Date = DateTime.Now;
        }

        public Message()
        {
        }

        public int Id { get; private set; }

        [Required] public string Content { get; set; }

        [Required] public DateTime Date { get; }

        [Required] public User Author { get; set; }

        [Required] public Channel Channel { get; set; }
    }
}