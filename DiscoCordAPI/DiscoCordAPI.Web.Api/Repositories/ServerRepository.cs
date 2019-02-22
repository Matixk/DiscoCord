using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Context;
using DiscoCordAPI.Models.Exceptions;
using DiscoCordAPI.Models.Servers;
using Microsoft.EntityFrameworkCore;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public class ServerRepository : IServersRepository
    {
        private readonly IMapper mapper;
        private readonly ApplicationContext context;

        public ServerRepository(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Server> GetServer(int id)
        {
            return await context
                .Servers
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<BasicPreviewDto>> GetPublicServers()
        {
            var publicServers = await context
                .Servers
                .Where(s => s.IsPrivate)
                .ToListAsync();
        
            return mapper.Map<IEnumerable<BasicPreviewDto>>(publicServers);
        }

        public async Task<ServerPreviewDto> GetServerDetails(int id)
        {
            var server = await context
                .Servers
                .Include(s => s.Owner)
                .Include(s => s.Users)
                .Include(s => s.Channels)
                .FirstOrDefaultAsync(s => s.Id == id);
            
            return mapper.Map<ServerPreviewDto>(server);
        }

        public async Task<Server> Insert(ServerForCreateDto server)
        {
            var user = await context
                .Users
                .FirstOrDefaultAsync(u => u.Id == server.OwnerId);

            if (user == null)
            {
                throw new NotFoundException("User not found!");
            }

            var serverToCreate = new Server(
                server.Name,
                user,
                server.IsPrivate);

            context.Servers.Add(serverToCreate);
            await context.SaveChangesAsync();

            return serverToCreate;
        }

        public async Task Update(int id, ServerForUpdateDto server)
        {
            var serverEntity = await context
                .Servers
                .FirstOrDefaultAsync(s => s.Id == id);

            if (server == null)
            {
                throw new NotFoundException();
            }

            serverEntity.Name = server.Name;
            serverEntity.IsPrivate = server.IsPrivate;

            context.Entry(serverEntity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Server> Delete(int id)
        {
            var server = await context
                .Servers
                .FirstOrDefaultAsync(s => s.Id == id);

            if (server == null)
            {
                throw new NotFoundException();
            }

            context.Remove(server);
            await context.SaveChangesAsync();

            return server;
        }

        public bool ServerExists(int id)
        {
            return context.Servers.Any(s => s.Id == id);
        }
    }
}