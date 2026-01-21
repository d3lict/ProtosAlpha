using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("testprojects")]
    public class TestProjectsController : ControllerBase
    {
        private readonly ITestProjectService _testProjectService;

        public TestProjectsController(ITestProjectService testProjectService)
        {
            _testProjectService = testProjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var testprojects = await _testProjectService.GetAllAsync();
            return Ok(testprojects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var testproject = await _testProjectService.GetByIdAsync(id);
            if (testproject == null)
                return NotFound();
            return Ok(testproject);
        }

        [HttpGet("{id}/testcases")]
        public async Task<IActionResult> GetTestCases(int id)
        {
            var testcases = await _testProjectService.GetTestCasesAsync(id);
            return Ok(testcases);
        }

        [HttpGet("{mixedID}/testplans")]
        public async Task<IActionResult> GetTestPlans(string mixedID)
        {
            // For simplicity, assume mixedID is numeric ID
            if (!int.TryParse(mixedID, out int id))
                return BadRequest("Invalid ID");

            var testplans = await _testProjectService.GetTestPlansAsync(id);
            return Ok(testplans);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Testproject testproject)
        {
            var created = await _testProjectService.CreateAsync(testproject);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
