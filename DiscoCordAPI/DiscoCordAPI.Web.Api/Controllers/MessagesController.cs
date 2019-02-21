using AutoMapper;
using DiscoCordAPI.Models.Messages;
using DiscoCordAPI.Models.Users;
using DiscoCordAPI.Web.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscoCordAPI.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMessagesRepository repo;
        private readonly IUsersRepository users;

        public MessagesController(IMapper autoMapper, IMessagesRepository repository, IUsersRepository usersRepo)
        {
            mapper = autoMapper;
            repo = repository;
            users = usersRepo;
        }

        // GET: api/Messages
        [HttpGet("channel/{id}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesForChannel(int id)
        {
            var messages = await repo.GetMessagesForChannel(id);
            var messagesToReturn = mapper.Map<IEnumerable<MessageDto>>(messages);
            return Ok(messagesToReturn);
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            var message = await repo.GetMessageById(id);
            if (message == null)
            {
                return BadRequest();
            }
            return Ok(message);
        }

        // PUT: api/Messages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(User user, int id, string content)
        {
            repo.UpdateMessage(user, id, content);
            return Ok("Updated");
        }

        // POST: api/Messages
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(MessageForCreateDto message)
        {
            repo.SendMessage(message, users.GetUser(message.AuthorId));
            return Ok("Sent");
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Message>> DeleteMessage(User user, int id)
        {
            repo.DeleteMessage(user, id);
            return Ok("Deleted");
        }
    }
}
