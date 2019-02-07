using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Servers;
using DiscoCordAPI.Models.Servers.Dto;
using DiscoCordAPI.Models.Users;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public class ServerRepository : IServersRepository
    {
        private readonly IMapper mapper;
        private readonly IRepository<Server> context;

        public ServerRepository(IRepository<Server> context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        public async Task<IEnumerable<BasicPreviewDto>> GetPublicServers()
        {
            var servers = await context.GetAll();
        
            var publicServers = servers.Where(s => s.IsPrivate == false);
            return mapper.Map<IEnumerable<BasicPreviewDto>>(publicServers);
        }

        public async Task<ServerPreviewDto> GetServerDetails(int id)
        {
            var server = await context.Get(id);
            
            return mapper.Map<ServerPreviewDto>(server);
        }

        public async Task Insert(ServerForCreateDto server, Task<User> user)
        {
            var serverToCreate = new Server(
                server.Name,
                user.Result,
                server.IsPrivate);

            await context.Insert(serverToCreate);
        }

        public async Task Update(int id, ServerForUpdateDto server)
        {
            var serverToUpdate = context.Get(id).Result;

            serverToUpdate.Name = server.Name;
            serverToUpdate.IsPrivate = server.IsPrivate;
            
            await context.Update(id, serverToUpdate);
        }

        public async Task Delete(int id)
        {
            await context.Delete(id);
        }
    }
}