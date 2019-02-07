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
        Task<IEnumerable<BasicPreviewDto>> GetPublicServers();
        Task<ServerPreviewDto> GetServerDetails(int id);
        Task Insert(ServerForCreateDto server, Task<User> get);
        Task Update(int id, ServerForUpdateDto server);
        Task Delete(int id);
    }
}