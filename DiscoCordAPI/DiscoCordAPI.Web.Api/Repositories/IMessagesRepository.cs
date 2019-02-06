using DiscoCordAPI.Models.Messages;
using DiscoCordAPI.Models.Users;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DiscoCordAPI.Web.Api.Repositories
{
    interface IMessagesRepository
    {
        Task<Message> GetMessageById(int id);
        Task<Message> SendMessage(Channel channel, User author, string content);
        Task<Message> UpdateMessage(string content);
        Task<Message> DeleteMessage(int id);
        Task<Message> MessageExists(int id);
        Task<Message> UserIsTheAuthor(User author, int id);
    }
}
