using System;
using System.Collections.Generic;
using AutoMapper;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Channels;

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

        public IEnumerable<BasicPreviewDto> GetServerChannels(int id)
        {
            throw new NotImplementedException();
        }

        public ChannelPreviewDto GetChannelDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ChannelForCreateDto channel)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ChannelForUpdateDto channel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
