using System.Collections.Generic;
using System.Threading.Tasks;
using DiscoCordAPI.Models;
using Microsoft.AspNetCore.Mvc;
using DiscoCordAPI.Models.Exceptions;
using DiscoCordAPI.Models.Servers;
using DiscoCordAPI.Web.Api.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace DiscoCordAPI.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ServersController : ControllerBase
    {
        private readonly IServersRepository servers;

        public ServersController(IServersRepository servers)
        {
            this.servers = servers;
        }

        // GET: api/Servers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicPreviewDto>>> GetPublicServers()
        {
            var publicServers = await servers.GetPublicServers();

            if (publicServers == null)
            {
                return NotFound();
            }

            return Ok(publicServers);
        }

        // GET: api/Servers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServerPreviewDto>> GetServer(int id)
        {
            //TODO do caller have permission
            var server = await servers.GetServerDetails(id);

            if (server == null)
            {
                return NotFound();
            }

            return server;
        }

        // PUT: api/Servers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServer(int id, ServerForUpdateDto server)
        {
            //TODO do caller have permission
            try
            {
                await servers.Update(id, server);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Servers
        [HttpPost]
        public async Task<IActionResult> PostServer(ServerForCreateDto server)
        {
            var serverCreated = await servers.Insert(server);
            
            return CreatedAtAction("GetServer", new { id = serverCreated.Id }, serverCreated);
        }

        // DELETE: api/Servers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Server>> DeleteServer(int id)
        {
            //TODO do caller have permission
            try
            {
                return await servers.Delete(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        private bool ServerExists(int id)
        {
            return servers.ServerExists(id);
        }

    }
}
