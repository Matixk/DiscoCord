namespace DiscoCordAPI.Models
{
    public class BasicPreviewDto
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public BasicPreviewDto()
        {
        }

        public BasicPreviewDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}