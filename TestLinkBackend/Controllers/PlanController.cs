using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly ITestPlanService _testPlanService;
        private readonly IBuildService _buildService;

        public PlanController(ITestPlanService testPlanService, IBuildService buildService)
        {
            _testPlanService = testPlanService;
            _buildService = buildService;
        }

        [HttpPost("{testPlanId}/copybuild")]
        public async Task<IActionResult> CopyBuildExecTaskAssignment(int testPlanId, [FromQuery] int sourceBuildId, [FromQuery] int targetBuildId)
        {
            // Mock copy build execution task assignment
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("{testPlanId}/urgency")]
        public async Task<IActionResult> UpdateTestCaseUrgency(int testPlanId, [FromBody] Dictionary<int, int> urgencyMap)
        {
            // Mock update test case urgency
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{testPlanId}/newesttcversions")]
        public async Task<IActionResult> GetNewestTestCaseVersions(int testPlanId)
        {
            // Mock get newest test case versions
            var versions = new List<TestcaseVersion>
            {
                new TestcaseVersion { Id = 1, TestcaseId = 1, Version = 1, Name = "Login Test v1", Active = true }
            };
            return Ok(versions);
        }

        [HttpPost("{testPlanId}/tcnavigator")]
        public async Task<IActionResult> TestCaseNavigator(int testPlanId, [FromBody] string filter)
        {
            // Mock test case navigator
            var testCases = await _testPlanService.GetAssignedTestCasesAsync(testPlanId);
            return Ok(testCases);
        }

        [HttpPut("{testPlanId}/updatetc")]
        public async Task<IActionResult> UpdateTestCase(int testPlanId, [FromQuery] int testCaseId, [FromQuery] string action)
        {
            // Mock update test case in plan
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost("{testPlanId}/tcunassign")]
        public async Task<IActionResult> UnassignTestCases(int testPlanId, [FromBody] int[] testCaseIds)
        {
            // Mock unassign test cases
            await Task.CompletedTask;
            return Ok();
        }
    }
}
