using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("testcases")]
        public async Task<IActionResult> SearchTestCases([FromQuery] string query, [FromQuery] int testProjectId, [FromQuery] string[] keywords = null)
        {
            var results = await _searchService.SearchTestCasesAsync(query, testProjectId, keywords);
            return Ok(results);
        }

        [HttpGet("testsuites")]
        public async Task<IActionResult> SearchTestSuites([FromQuery] string query, [FromQuery] int testProjectId)
        {
            var results = await _searchService.SearchTestSuitesAsync(query, testProjectId);
            return Ok(results);
        }

        [HttpGet("requirements")]
        public async Task<IActionResult> SearchRequirements([FromQuery] string query, [FromQuery] int testProjectId)
        {
            var results = await _searchService.SearchRequirementsAsync(query, testProjectId);
            return Ok(results);
        }

        [HttpGet("requirementspecs")]
        public async Task<IActionResult> SearchRequirementSpecs([FromQuery] string query, [FromQuery] int testProjectId)
        {
            var results = await _searchService.SearchRequirementSpecsAsync(query, testProjectId);
            return Ok(results);
        }

        [HttpGet("global")]
        public async Task<IActionResult> GlobalSearch([FromQuery] string query, [FromQuery] int testProjectId)
        {
            var results = await _searchService.PerformGlobalSearchAsync(query, testProjectId);
            return Ok(results);
        }
    }
}
