namespace DiscoCordAPI.Models.Messages
{
    public class MessageDto
    {
        public int Id { get; private set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual BasicPreviewDto Author { get; set; }
        public virtual BasicPreviewDto Channel { get; set; }
    }
}
