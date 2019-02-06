﻿using DiscoCordAPI.Models.Context;
using DiscoCordAPI.Models.Messages;
using DiscoCordAPI.Models.Users;
using Microsoft.EntityFrameworkCore;
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

        public async void DeleteMessage(int id)
        {
            var message = await context.Messages.FirstOrDefaultAsync(msg => msg.Id == id);
            context.Messages.Remove(message);
        }

        public async Task<Message> GetMessageById(int id)
        {
            return await context.Messages.FirstOrDefaultAsync(msg => msg.Id == id);
        }

        public async Task<bool> MessageExists(int id)
        {
            return await context.Messages.AnyAsync(msg => msg.Id == id);
        }

        public async Task<Message> SendMessage(Message message)
        {
            await context.Messages.AddAsync(message);
            return await context.Messages.FirstOrDefaultAsync(msg => msg == message);
        }

        public async Task<Message> UpdateMessage(int id, string content)
        {
            var message = await context.Messages.FirstOrDefaultAsync(msg => msg.Id == id);
            context.Messages.AsTracking();
            message.Content = content;
            await context.SaveChangesAsync();
            return await context.Messages.FirstOrDefaultAsync(msg => msg.Id == id);
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