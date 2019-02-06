using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiscoCordAPI.Models.Exceptions;
using DiscoCordAPI.Models.Servers;
using DiscoCordAPI.Web.Api.Repositories;

namespace DiscoCordAPI.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly IRepository<Server> context;

        public ServersController(IRepository<Server> context)
        {
            this.context = context;
        }

        // GET: api/Servers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Server>>> GetServers()
        {
            return await context.GetAll();
        }

        // GET: api/Servers/5
        [HttpGet("{id}")]
        public async Task<Task<Server>> GetServer(int id)
        {
            return context.Get(id);
        }

        // PUT: api/Servers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServer(int id, Server server)
        {
            try
            {
                await context.Update(id, server);
                return NoContent();
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
        public async Task<ActionResult<Server>> PostServer(Server server)
        {
            await context.Insert(server);

            return CreatedAtAction("GetServer", new { id = server.Id }, server);
        }

        // DELETE: api/Servers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Server>> DeleteServer(int id)
        {
            try
            {
                return await context.Delete(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        private bool ServerExists(int id)
        {
            return context.Exists(id);
        }
    }
}
