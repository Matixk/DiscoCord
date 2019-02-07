using DiscoCordAPI.Models.Messages;
using DiscoCordAPI.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IMessagesRepository
    {
        Task<Message> GetMessageById(int id);
        Task<IEnumerable<Message>> GetMessagesForChannel(int id);
        void SendMessage(Message message);
        void UpdateMessage(User user,int id, string content);
        void DeleteMessage(User user,int id);
        Task<bool> MessageExists(int id);
        Task<bool> UserIsTheAuthor(User author, int id);
    }
}
