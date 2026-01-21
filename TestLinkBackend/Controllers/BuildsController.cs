using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildsController : ControllerBase
    {
        private readonly IBuildService _buildService;

        public BuildsController(IBuildService buildService)
        {
            _buildService = buildService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var builds = await _buildService.GetAllAsync();
            return Ok(builds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var build = await _buildService.GetByIdAsync(id);
            if (build == null)
                return NotFound();
            return Ok(build);
        }

        [HttpGet("testproject/{testProjectId}")]
        public async Task<IActionResult> GetByTestProject(int testProjectId)
        {
            var builds = await _buildService.GetByTestProjectAsync(testProjectId);
            return Ok(builds);
        }

        [HttpGet("testplan/{testPlanId}")]
        public async Task<IActionResult> GetByTestPlan(int testPlanId)
        {
            var builds = await _buildService.GetByTestPlanAsync(testPlanId);
            return Ok(builds);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Build build)
        {
            var created = await _buildService.CreateAsync(build);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Build build)
        {
            var updated = await _buildService.UpdateAsync(id, build);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _buildService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
