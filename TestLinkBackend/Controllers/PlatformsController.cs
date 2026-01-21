using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _platformService;

        public PlatformsController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var platforms = await _platformService.GetAllAsync();
            return Ok(platforms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var platform = await _platformService.GetByIdAsync(id);
            if (platform == null)
                return NotFound();
            return Ok(platform);
        }

        [HttpGet("testproject/{testProjectId}")]
        public async Task<IActionResult> GetByTestProject(int testProjectId)
        {
            var platforms = await _platformService.GetByTestProjectAsync(testProjectId);
            return Ok(platforms);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Platform platform)
        {
            var created = await _platformService.CreateAsync(platform);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Platform platform)
        {
            var updated = await _platformService.UpdateAsync(id, platform);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _platformService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

        [HttpPost("{id}/assign/{testCaseId}")]
        public async Task<IActionResult> AssignToTestCase(int id, int testCaseId)
        {
            await _platformService.AssignToTestCaseAsync(id, testCaseId);
            return Ok();
        }

        [HttpGet("assigned/{testCaseId}")]
        public async Task<IActionResult> GetAssignedToTestCase(int testCaseId)
        {
            var platforms = await _platformService.GetAssignedToTestCaseAsync(testCaseId);
            return Ok(platforms);
        }
    }
}
