using System.Collections.Generic;
using System.Threading.Tasks;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Servers;
using DiscoCordAPI.Models.Users;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IServersRepository
    {
        Task<Server> GetServer(int id);
        Task<IEnumerable<BasicPreviewDto>> GetPublicServers();
        Task<ServerPreviewDto> GetServerDetails(int id);
        Task<Server> Insert(ServerForCreateDto server);
        Task Update(int id, ServerForUpdateDto server);
        Task<Server> Delete(int id);
        bool ServerExists(int id);
    }
}