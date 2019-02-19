using System.Collections.Generic;
using AutoMapper;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Servers;
using Microsoft.EntityFrameworkCore;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public class ChannelsRepository : IChannelsRepository
    {
        private readonly IMapper mapper;
        private readonly IRepository<Channel> context;

        public ChannelsRepository(IRepository<Channel> context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<BasicPreviewDto> GetChannelMessages(int id)
        {
            var messages = context.GetDbSet()
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.Id == id)
                .Result
                .Messages;

            return mapper.Map<IEnumerable<BasicPreviewDto>>(messages);
        }

        public ChannelPreviewDto GetChannelDetails(int id)
        {
            var channel = context.GetDbSet()
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.Id == id)
                .Result;

            return mapper.Map<ChannelPreviewDto>(channel);
        }

        public void Insert(ChannelForCreateDto channel, Server server)
        {
            var channelToCreate = new Channel(server, channel.Name);

            context.Insert(channelToCreate);
        }

        public void Update(int id, ChannelForUpdateDto channel)
        {
            var channelToUpdate= context.Get(id).Result;

            channelToUpdate.Name = channel.Name;

            context.Update(id, channelToUpdate);
        }

        public void Delete(int id)
        {
            context.Delete(id);
        }
    }
}
