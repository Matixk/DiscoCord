using System.Collections.Generic;

namespace DiscoCordAPI.Models.Users
{
    public class UserForDetailedDto : BasicPreviewDto
    {
        public virtual List<BasicPreviewDto> OwnedServers { get; set; } = new List<BasicPreviewDto>();
        public virtual List<BasicPreviewDto> ConnectedServers { get; set; } = new List<BasicPreviewDto>();
    }
}