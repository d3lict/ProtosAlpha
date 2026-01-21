using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        private readonly IExecutionService _executionService;
        private readonly ITestPlanService _testPlanService;

        public ResultsController(IExecutionService executionService, ITestPlanService testPlanService)
        {
            _executionService = executionService;
            _testPlanService = testPlanService;
        }

        [HttpGet("general/{testPlanId}")]
        public async Task<IActionResult> GetGeneralResults(int testPlanId)
        {
            // Mock general test results - status totals, build metrics, etc.
            var results = new
            {
                TestPlanId = testPlanId,
                TotalTestCases = 10,
                Executed = 8,
                Passed = 6,
                Failed = 2,
                Blocked = 0,
                NotRun = 2,
                CompletionPercentage = 80.0,
                BuildMetrics = new[] {
                    new { BuildName = "Build 1.0", Passed = 6, Failed = 2, Total = 8 }
                },
                PlatformMetrics = new[] {
                    new { PlatformName = "Windows", Passed = 3, Failed = 1, Total = 4 }
                },
                KeywordMetrics = new[] {
                    new { Keyword = "Smoke Test", Passed = 4, Failed = 0, Total = 4 }
                }
            };
            return Ok(results);
        }

        [HttpGet("by-status/{testPlanId}")]
        public async Task<IActionResult> GetResultsByStatus(int testPlanId)
        {
            var executions = await _executionService.GetByTestPlanAsync(testPlanId);
            var statusGroups = executions.GroupBy(e => e.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() });
            return Ok(statusGroups);
        }

        [HttpGet("by-tester/{testPlanId}")]
        public async Task<IActionResult> GetResultsByTester(int testPlanId)
        {
            // Mock results by tester
            var results = new[] {
                new { TesterId = 1, TesterName = "admin", Passed = 4, Failed = 1, Total = 5 },
                new { TesterId = 2, TesterName = "testuser", Passed = 2, Failed = 1, Total = 3 }
            };
            return Ok(results);
        }

        [HttpGet("by-build/{testPlanId}")]
        public async Task<IActionResult> GetResultsByBuild(int testPlanId)
        {
            // Mock results by build
            var results = new[] {
                new { BuildId = 1, BuildName = "Build 1.0", Passed = 6, Failed = 2, Total = 8 },
                new { BuildId = 2, BuildName = "Build 1.1", Passed = 2, Failed = 0, Total = 2 }
            };
            return Ok(results);
        }

        [HttpGet("by-platform/{testPlanId}")]
        public async Task<IActionResult> GetResultsByPlatform(int testPlanId)
        {
            // Mock results by platform
            var results = new[] {
                new { PlatformId = 1, PlatformName = "Windows 10", Passed = 4, Failed = 1, Total = 5 },
                new { PlatformId = 2, PlatformName = "Linux Ubuntu", Passed = 2, Failed = 1, Total = 3 }
            };
            return Ok(results);
        }

        [HttpGet("by-keyword/{testPlanId}")]
        public async Task<IActionResult> GetResultsByKeyword(int testPlanId)
        {
            // Mock results by keyword
            var results = new[] {
                new { KeywordId = 1, KeywordName = "Smoke Test", Passed = 4, Failed = 0, Total = 4 },
                new { KeywordId = 2, KeywordName = "Regression", Passed = 2, Failed = 2, Total = 4 }
            };
            return Ok(results);
        }

        [HttpGet("charts/pie/{testPlanId}")]
        public async Task<IActionResult> GetOverallPieChart(int testPlanId)
        {
            // Mock pie chart data
            var data = new {
                Labels = new[] { "Passed", "Failed", "Blocked", "Not Run" },
                Values = new[] { 6, 2, 0, 2 },
                Colors = new[] { "#28a745", "#dc3545", "#ffc107", "#6c757d" }
            };
            return Ok(data);
        }

        [HttpGet("charts/bar/keyword/{testPlanId}")]
        public async Task<IActionResult> GetKeywordBarChart(int testPlanId)
        {
            // Mock keyword bar chart data
            var data = new {
                Labels = new[] { "Smoke Test", "Regression", "Integration" },
                Passed = new[] { 4, 2, 1 },
                Failed = new[] { 0, 2, 1 }
            };
            return Ok(data);
        }

        [HttpGet("charts/bar/priority/{testPlanId}")]
        public async Task<IActionResult> GetPriorityBarChart(int testPlanId)
        {
            // Mock priority bar chart data
            var data = new {
                Labels = new[] { "High", "Medium", "Low" },
                Passed = new[] { 3, 2, 1 },
                Failed = new[] { 1, 1, 0 }
            };
            return Ok(data);
        }

        [HttpGet("free-testcases/{testProjectId}")]
        public async Task<IActionResult> GetFreeTestCases(int testProjectId)
        {
            // Mock free test cases (not assigned to any test plan)
            var freeTestCases = new[] {
                new { Id = 11, Name = "New Test Case", Description = "Not assigned yet" }
            };
            return Ok(freeTestCases);
        }

        [HttpGet("never-run/{testPlanId}")]
        public async Task<IActionResult> GetNeverRunTestCases(int testPlanId)
        {
            // Mock test cases that were never executed
            var neverRun = new[] {
                new { Id = 3, Name = "Never Run Test", Description = "Not executed yet" }
            };
            return Ok(neverRun);
        }

        [HttpGet("uncovered-testcases/{testPlanId}")]
        public async Task<IActionResult> GetUncoveredTestCases(int testPlanId)
        {
            // Mock test cases without requirements coverage
            var uncovered = new[] {
                new { Id = 4, Name = "Uncovered Test", Description = "No requirements linked" }
            };
            return Ok(uncovered);
        }

        [HttpGet("metrics-dashboard/{testPlanId}")]
        public async Task<IActionResult> GetMetricsDashboard(int testPlanId)
        {
            // Mock comprehensive metrics dashboard
            var dashboard = new {
                Summary = new {
                    TotalTestCases = 10,
                    Executed = 8,
                    Passed = 6,
                    Failed = 2,
                    Blocked = 0,
                    NotRun = 2,
                    CompletionRate = 80.0
                },
                Trends = new[] {
                    new { Date = "2024-01-01", Passed = 2, Failed = 0 },
                    new { Date = "2024-01-02", Passed = 4, Failed = 1 },
                    new { Date = "2024-01-03", Passed = 6, Failed = 2 }
                },
                TopFailures = new[] {
                    new { TestCase = "Login Test", FailureCount = 3 },
                    new { TestCase = "Payment Test", FailureCount = 2 }
                }
            };
            return Ok(dashboard);
        }

        [HttpGet("export/{testPlanId}")]
        public async Task<IActionResult> ExportResults(int testPlanId, [FromQuery] string format = "json")
        {
            var results = await GetGeneralResults(testPlanId);
            // In a real implementation, this would generate CSV, XLS, etc.
            return File(System.Text.Encoding.UTF8.GetBytes("Mock export data"), "application/octet-stream", $"results_{testPlanId}.{format}");
        }
    }
}
