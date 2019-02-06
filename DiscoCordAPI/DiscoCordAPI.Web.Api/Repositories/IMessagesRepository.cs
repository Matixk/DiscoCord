using DiscoCordAPI.Models.Messages;
using DiscoCordAPI.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IMessagesRepository
    {
        Task<Message> GetMessageById(int id);
        void SendMessage(Message message);
        void UpdateMessage(int id, string content);
        void DeleteMessage(int id);
        Task<bool> MessageExists(int id);
        Task<bool> UserIsTheAuthor(User author, int id);
    }
}
