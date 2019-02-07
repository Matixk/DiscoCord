using DiscoCordAPI.Models.Context;
using DiscoCordAPI.Models.Messages;
using DiscoCordAPI.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly ApplicationContext context;

        public MessagesRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async void DeleteMessage(User user, int id)
        {
            var message = await context.Messages.FirstOrDefaultAsync(msg => msg.Id == id);
            if (await UserIsTheAuthor(user, id))
            {
                context.Messages.Remove(message);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Message> GetMessageById(int id)
        {
            return await context.Messages.FirstOrDefaultAsync(msg => msg.Id == id);
        }

        public async Task<IEnumerable<Message>> GetMessagesForChannel(int id)
        {
            var allMessages = await context.Messages.ToListAsync();
            var messages = new List<Message>();
            foreach (var msg in allMessages)
            {
                if (msg.Channel.Id == id)
                {
                    messages.Add(msg);
                }
            }
            return messages;
        }

        public async Task<bool> MessageExists(int id)
        {
            return await context.Messages.AnyAsync(msg => msg.Id == id);
        }

        public async void SendMessage(Message message)
        {
            await context.Messages.AddAsync(message);
            await context.SaveChangesAsync();
        }

        public async void UpdateMessage(int id, string content)
        {
            var message = await context.Messages.FirstOrDefaultAsync(msg => msg.Id == id);
            if (message != null)
            {
                context.Messages.AsTracking();
                message.Content = content;
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> UserIsTheAuthor(User author, int id)
        {
            var message = await context.Messages.FirstOrDefaultAsync(msg => msg.Id == id);
            if (message != null)
            {
                return message.Author.Equals(author);
            }
            return false;
        }
    }
}
