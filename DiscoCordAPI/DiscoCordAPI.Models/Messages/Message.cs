using System;
using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Users;

namespace DiscoCordAPI.Models.Messages
{
    public class Message
    {
        public int Id { get; private set; }
        public Channel Channel { get; set; }
        public User Author { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; private set; }

        public Message(int id, Channel channel, User author, string content)
        {
            Id = id;
            Channel = channel;
            Author = author;
            Content = content;
            Date = DateTime.Now;
        }
    }
}
