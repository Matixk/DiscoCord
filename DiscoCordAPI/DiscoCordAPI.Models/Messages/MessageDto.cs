using DiscoCordAPI.Models.Channels;

namespace DiscoCordAPI.Models.Messages
{
    class MessageDto
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public virtual ChannelForMessageDto Channel { get; set; }
    }
}
