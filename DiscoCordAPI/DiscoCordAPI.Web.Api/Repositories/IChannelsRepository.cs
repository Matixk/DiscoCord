using System.Collections.Generic;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Channels;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IChannelsRepository
    {
        IEnumerable<BasicPreviewDto> GetServerChannels(int id);
        ChannelPreviewDto GetChannelDetails(int id);
        void Insert(ChannelForCreateDto channel);
        void Update(int id, ChannelForUpdateDto channel);
        void Delete(int id);
    }
}