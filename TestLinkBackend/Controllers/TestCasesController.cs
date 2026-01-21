using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestCasesController : ControllerBase
    {
        private readonly ITestCaseService _testCaseService;

        public TestCasesController(ITestCaseService testCaseService)
        {
            _testCaseService = testCaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var testcases = await _testCaseService.GetAllAsync();
            return Ok(testcases);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var testcase = await _testCaseService.GetByIdAsync(id);
            if (testcase == null)
                return NotFound();
            return Ok(testcase);
        }

        [HttpGet("testproject/{testProjectId}")]
        public async Task<IActionResult> GetByTestProject(int testProjectId)
        {
            var testcases = await _testCaseService.GetByTestProjectAsync(testProjectId);
            return Ok(testcases);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Testcase testcase)
        {
            var created = await _testCaseService.CreateAsync(testcase);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Testcase testcase)
        {
            var updated = await _testCaseService.UpdateAsync(id, testcase);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _testCaseService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

        [HttpPost("{id}/assign/{testPlanId}")]
        public async Task<IActionResult> AssignToTestPlan(int id, int testPlanId)
        {
            await _testCaseService.AssignToTestPlanAsync(id, testPlanId);
            return Ok();
        }

        [HttpPost("{id}/execute/{testPlanId}")]
        public async Task<IActionResult> Execute(int id, int testPlanId, [FromBody] bool status)
        {
            await _testCaseService.ExecuteAsync(id, testPlanId, status);
            return Ok();
        }

        [HttpGet("{id}/versions")]
        public async Task<IActionResult> GetVersions(int id)
        {
            var versions = await _testCaseService.GetVersionsAsync(id);
            return Ok(versions);
        }
    }
}
