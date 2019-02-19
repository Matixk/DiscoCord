using System.Collections.Generic;
using System.Threading.Tasks;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Servers;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IChannelsRepository
    {
        IEnumerable<BasicPreviewDto> GetChannelMessages(int id);
        ChannelPreviewDto GetChannelDetails(int id);
        void Insert(ChannelForCreateDto channel, Task<Server> server);
        void Update(int id, ChannelForUpdateDto channel);
        void Delete(int id);
    }
}