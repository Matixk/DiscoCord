using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiscoCordAPI.Models.Exceptions;
using DiscoCordAPI.Models.Servers;
using DiscoCordAPI.Web.Api.Repositories;
using Microsoft.AspNetCore.Cors;

namespace DiscoCordAPI.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ServersController : ControllerBase
    {
        private readonly IServersRepository servers;
        private readonly IUsersRepository users;

        public ServersController(IServersRepository servers, IUsersRepository users)
        {
            this.servers = servers;
            this.users = users;
        }

        // GET: api/Servers
        [HttpGet]
        public async Task<IActionResult> GetPublicServers() => Ok(servers.GetPublicServers());

        // GET: api/Servers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServer(int id)
        {
            //TODO do caller have permission
            return Ok(servers.GetServerDetails(id));
        }

        [HttpGet("{id}/channels")]
        public async Task<IActionResult> GetServerChannels(int id)
        {
            //TODO do caller have permission
            return Ok(servers.GetServerChannels(id));
        }

        // PUT: api/Servers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServer(int id, ServerForUpdateDto server)
        {
            //TODO do caller have permission
            try
            {
                servers.Update(id, server);
                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/Servers
        [HttpPost]
        public async Task<IActionResult> PostServer(ServerForCreateDto server)
        {
            servers.Insert(server, users.GetUser(server.OwnerId));

            return Ok();
        }

        // DELETE: api/Servers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Server>> DeleteServer(int id)
        {
            //TODO do caller have permission
            try
            {
                servers.Delete(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

    }
}
