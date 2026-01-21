using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestPlansController : ControllerBase
    {
        private readonly ITestPlanService _testPlanService;

        public TestPlansController(ITestPlanService testPlanService)
        {
            _testPlanService = testPlanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var testplans = await _testPlanService.GetAllAsync();
            return Ok(testplans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var testplan = await _testPlanService.GetByIdAsync(id);
            if (testplan == null)
                return NotFound();
            return Ok(testplan);
        }

        [HttpGet("testproject/{testProjectId}")]
        public async Task<IActionResult> GetByTestProject(int testProjectId)
        {
            var testplans = await _testPlanService.GetByTestProjectAsync(testProjectId);
            return Ok(testplans);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Testplan testplan)
        {
            var created = await _testPlanService.CreateAsync(testplan);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Testplan testplan)
        {
            var updated = await _testPlanService.UpdateAsync(id, testplan);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _testPlanService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

        [HttpPost("{id}/assign/{testCaseId}")]
        public async Task<IActionResult> AssignTestCase(int id, int testCaseId)
        {
            await _testPlanService.AssignTestCaseAsync(id, testCaseId);
            return Ok();
        }

        [HttpGet("{id}/testcases")]
        public async Task<IActionResult> GetAssignedTestCases(int id)
        {
            var testcases = await _testPlanService.GetAssignedTestCasesAsync(id);
            return Ok(testcases);
        }
    }
}
