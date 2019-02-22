using System.Collections.Generic;
using System.Threading.Tasks;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Servers;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IChannelsRepository
    {
        Task<IEnumerable<BasicPreviewDto>> GetServerChannels(int id);
        Task<ChannelPreviewDto> GetChannelDetails(int id);
        Task<Channel> Insert(ChannelForCreateDto channel);
        Task Update(int id, ChannelForUpdateDto channel);
        Task<Channel> Delete(int id);
        bool ChannelExists(int id);
    }
}