using System.Collections.Generic;
using System.Threading.Tasks;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Servers;
using DiscoCordAPI.Models.Servers.Dto;
using DiscoCordAPI.Models.Users;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IServersRepository
    {
        IEnumerable<BasicPreviewDto> GetPublicServers();
        ServerPreviewDto GetServerDetails(int id);
        void Insert(ServerForCreateDto server, Task<User> get);
        void Update(int id, ServerForUpdateDto server);
        void Delete(int id);
    }
}