namespace DiscoCordAPI.Models.Messages
{
    public class MessageDto
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public virtual BasicPreviewDto Channel { get; set; }
    }
}
