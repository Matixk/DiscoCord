using DiscoCordAPI.Web.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DiscoCordAPI.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IMessagesRepository repo;

        public MessagesController(IConfiguration configuration, IMessagesRepository repository)
        {
            config = configuration;
            repo = repository;
        }
    }
}
