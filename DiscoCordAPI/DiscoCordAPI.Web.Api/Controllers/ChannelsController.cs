using System;
using System.Threading.Tasks;
using DiscoCordAPI.Models;
using Microsoft.AspNetCore.Mvc;
using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Exceptions;
using DiscoCordAPI.Web.Api.Repositories;
using Microsoft.AspNetCore.Cors;

namespace DiscoCordAPI.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelsRepository channels;
        private readonly IServersRepository servers;

        public ChannelsController(IChannelsRepository channels, IServersRepository servers)
        {
            this.channels = channels;
            this.servers = servers;
        }

        // GET: api/Channels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Channel>> GetChannelDetails(int id) => Ok(channels.GetChannelDetails(id));

        // GET: api/Channels/5/messages
        [HttpGet("{id}/messages")]
        public async Task<ActionResult<Channel>> GetChannelMessages(int id) => Ok(channels.GetChannelMessages(id));

        // PUT: api/Channels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChannel(int id, ChannelForUpdateDto channel)
        {
            //TODO do caller have permission
            try
            {
                channels.Update(id, channel);
                return Ok(new BasicPreviewDto(id, channel.Name));
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

        // POST: api/Channels
        [HttpPost]
        public async Task<ActionResult<Channel>> PostChannel(ChannelForCreateDto channel)
        {
            channels.Insert(channel, servers.GetServer(channel.ServerId));

            return Ok();
        }

        // DELETE: api/Channels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Channel>> DeleteChannel(int id)
        {
            //TODO do caller have permission
            try
            {
                channels.Delete(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

    }
}
