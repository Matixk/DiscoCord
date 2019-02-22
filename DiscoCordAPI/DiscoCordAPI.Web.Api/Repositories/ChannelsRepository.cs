using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Context;
using DiscoCordAPI.Models.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public class ChannelsRepository : IChannelsRepository
    {
        private readonly IMapper mapper;
        private readonly ApplicationContext context;

        public ChannelsRepository(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BasicPreviewDto>> GetServerChannels(int id)
        {
            var channels = await context
                .Servers
                .Include(s => s.Channels)
                .FirstOrDefaultAsync(s => s.Id == id);

            return mapper.Map<IEnumerable<BasicPreviewDto>>(channels);
        }

        public async Task<ChannelPreviewDto> GetChannelDetails(int id)
        {
            var channel = await context
                .Channels
                .Include(c => c.Server)
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.Id == id);

            return mapper.Map<ChannelPreviewDto>(channel);
        }

        public async Task<Channel> Insert(ChannelForCreateDto channel)
        {
            var server = await context
                .Servers
                .FirstOrDefaultAsync(s => s.Id == channel.ServerId);

            if (server == null)
            {
                throw new NotFoundException("Server not found!");
            }

            var channelToCreate = new Channel(server, channel.Name);

            context.Channels.Add(channelToCreate);
            await context.SaveChangesAsync();

            return channelToCreate;
        }

        public async Task Update(int id, ChannelForUpdateDto channel)
        {
            var channelEntity = await context
                .Channels
                .FirstOrDefaultAsync(c => c.Id == id);

            if (channelEntity == null)
            {
                throw new NotFoundException();
            }

            channelEntity.Name = channel.Name;

            context.Entry(channelEntity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Channel> Delete(int id)
        {
            var channel = await context
                .Channels
                .FirstOrDefaultAsync(c => c.Id == id);

            if (channel == null)
            {
                throw new NotFoundException();
            }

            context.Remove(channel);
            await context.SaveChangesAsync();

            return channel;
        }

        public bool ChannelExists(int id)
        {
            return context.Channels.Any(c => c.Id == id);
        }
    }
}
