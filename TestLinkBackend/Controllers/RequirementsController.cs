using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequirementsController : ControllerBase
    {
        private readonly IRequirementService _requirementService;

        public RequirementsController(IRequirementService requirementService)
        {
            _requirementService = requirementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requirements = await _requirementService.GetAllAsync();
            return Ok(requirements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var requirement = await _requirementService.GetByIdAsync(id);
            if (requirement == null)
                return NotFound();
            return Ok(requirement);
        }

        [HttpGet("testproject/{testProjectId}")]
        public async Task<IActionResult> GetByTestProject(int testProjectId)
        {
            var requirements = await _requirementService.GetByTestProjectAsync(testProjectId);
            return Ok(requirements);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Requirement requirement)
        {
            var created = await _requirementService.CreateAsync(requirement);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Requirement requirement)
        {
            var updated = await _requirementService.UpdateAsync(id, requirement);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _requirementService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

        [HttpGet("{id}/versions")]
        public async Task<IActionResult> GetVersions(int id)
        {
            var versions = await _requirementService.GetVersionsAsync(id);
            return Ok(versions);
        }

        [HttpPost("{id}/assign/{testCaseId}")]
        public async Task<IActionResult> AssignToTestCase(int id, int testCaseId)
        {
            await _requirementService.AssignToTestCaseAsync(id, testCaseId);
            return Ok();
        }
    }
}
