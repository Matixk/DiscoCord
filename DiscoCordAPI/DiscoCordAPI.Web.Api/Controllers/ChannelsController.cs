using System.Collections.Generic;
using System.Threading.Tasks;
using DiscoCordAPI.Models;
using Microsoft.AspNetCore.Mvc;
using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Exceptions;
using DiscoCordAPI.Web.Api.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace DiscoCordAPI.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelsRepository channels;

        public ChannelsController(IChannelsRepository channels)
        {
            this.channels = channels;
        }

        // GET: api/Channels/5/details
        [HttpGet("{id}/details")]
        public async Task<ActionResult<ChannelPreviewDto>> GetChannel(int id)
        {
            var channel = await channels.GetChannelDetails(id);

            if (channel == null)
            {
                return NotFound();
            }

            return Ok(channel);
        }

        // GET: api/Channels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BasicPreviewDto>>> GetServerChannels(int id)
        {
            var serverChannels = await channels.GetServerChannels(id);

            if (serverChannels == null)
            {
                return NotFound();
            }

            return Ok(serverChannels);
        }

        // PUT: api/Channels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChannel(int id, ChannelForUpdateDto channel)
        {
            //TODO do caller have permission
            try
            {
                await channels.Update(id, channel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChannelExists(id))
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

        // POST: api/Channels
        [HttpPost]
        public async Task<ActionResult<Channel>> PostChannel(ChannelForCreateDto channel)
        {
            var channelCreated = await channels.Insert(channel);

            return CreatedAtAction("GetChannel", new { id = channelCreated.Id }, channelCreated);
        }

        // DELETE: api/Channels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Channel>> DeleteChannel(int id)
        {
            //TODO do caller have permission
            try
            {
                await channels.Delete(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        private bool ChannelExists(int id)
        {
            return channels.ChannelExists(id);
        }

    }
}
