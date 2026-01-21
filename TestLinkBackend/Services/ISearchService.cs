using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<Testcase>> SearchTestCasesAsync(string query, int testProjectId, string[] keywords = null);
        Task<IEnumerable<TestSuite>> SearchTestSuitesAsync(string query, int testProjectId);
        Task<IEnumerable<Requirement>> SearchRequirementsAsync(string query, int testProjectId);
        Task<IEnumerable<RequirementSpec>> SearchRequirementSpecsAsync(string query, int testProjectId);
        Task<SearchResult> PerformGlobalSearchAsync(string query, int testProjectId);
    }
}
