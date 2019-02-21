namespace DiscoCordAPI.Models.Messages
{
    public class MessageForCreateDto
    {
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int ChannelId { get; set; }
    }
}
