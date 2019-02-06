using System.Collections.Generic;
using DiscoCordAPI.Models.Servers;

namespace DiscoCordAPI.Models.Users
{
    public class UserForDetailedDto
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public virtual List<ServerForUserListDto> OwnedServers { get; set; } = new List<ServerForUserListDto>();
        public virtual List<ServerForUserListDto> ConnectedServers { get; set; } = new List<ServerForUserListDto>();
    }
}