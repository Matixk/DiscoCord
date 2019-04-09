using DiscoCordAPI.Models.Context;
using DiscoCordAPI.Models.Messages;
using DiscoCordAPI.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscoCordAPI.Models.Exceptions;
using System.Diagnostics;

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
            if (await UserIsTheAuthor(user, id) && message != null)
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
            var allMessages = await context.Messages.Include("Channel").ToListAsync();
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

        public async Task SendMessage(MessageForCreateDto message)
        {
            var user = await context
                .Users
                .FirstOrDefaultAsync(u => u.Id == message.AuthorId);
            var channel = await context
                .Channels
                .FirstOrDefaultAsync(c => c.Id == message.ChannelId);

            if (user == null)
            {
                throw new NotFoundException("User not found!");
            }
            if (channel == null)
            {
                throw new NotFoundException("Channel not found!");
            }

            var messageToCreate = new Message(
                channel,
                user,
                message.Content
                );

            context.Messages.Add(messageToCreate);
            await context.SaveChangesAsync();
        }

        public async void UpdateMessage(User user, int id, string content)
        {
            var message = await context.Messages.FirstOrDefaultAsync(msg => msg.Id == id);
            if (message != null && await UserIsTheAuthor(user, id))
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
