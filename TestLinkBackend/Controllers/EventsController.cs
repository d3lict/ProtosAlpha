using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAllAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var @event = await _eventService.GetByIdAsync(id);
            if (@event == null)
                return NotFound();
            return Ok(@event);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFiltered([FromQuery] string[] logLevels, [FromQuery] int? objectId, [FromQuery] string objectType, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] int[] userIds)
        {
            var events = await _eventService.GetFilteredAsync(logLevels, objectId, objectType, startDate, endDate, userIds);
            return Ok(events);
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearEvents([FromQuery] string[] logLevels)
        {
            await _eventService.ClearEventsAsync(logLevels);
            return Ok();
        }

        [HttpPost("log")]
        public async Task<IActionResult> LogEvent([FromBody] Event @event)
        {
            await _eventService.LogEventAsync(@event);
            return Ok();
        }
    }
}
