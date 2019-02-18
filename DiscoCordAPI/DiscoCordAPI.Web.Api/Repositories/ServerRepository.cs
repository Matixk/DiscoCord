using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Servers;
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
        
        public IEnumerable<BasicPreviewDto> GetPublicServers()
        {
            var servers = context.GetAll().Result;
        
            var publicServers = servers.Where(s => s.IsPrivate == false);
            return mapper.Map<IEnumerable<BasicPreviewDto>>(publicServers);
        }

        public ServerPreviewDto GetServerDetails(int id)
        {
            var server = context.Get(id).Result;
            
            return mapper.Map<ServerPreviewDto>(server);
        }

        public void Insert(ServerForCreateDto server, Task<User> user)
        {
            var serverToCreate = new Server(
                server.Name,
                user.Result,
                server.IsPrivate);

            context.Insert(serverToCreate);
        }

        public void Update(int id, ServerForUpdateDto server)
        {
            var serverToUpdate = context.Get(id).Result;

            serverToUpdate.Name = server.Name;
            serverToUpdate.IsPrivate = server.IsPrivate;
            
            context.Update(id, serverToUpdate);
        }

        public void Delete(int id)
        {
            context.Delete(id);
        }
    }
}