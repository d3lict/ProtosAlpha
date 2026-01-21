using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class SearchService : ISearchService
    {
        public async Task<IEnumerable<Testcase>> SearchTestCasesAsync(string query, int testProjectId, string[] keywords = null)
        {
            // Mock search - return test cases that contain the query in name or description
            var testCases = new List<Testcase>
            {
                new Testcase { Id = 1, Name = "Login Test", Description = "Test login functionality", TestprojectId = 1 }
            };

            if (!string.IsNullOrEmpty(query))
            {
                testCases = testCases.Where(tc =>
                    tc.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    tc.Description.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return testCases.Where(tc => tc.TestprojectId == testProjectId);
        }

        public async Task<IEnumerable<TestSuite>> SearchTestSuitesAsync(string query, int testProjectId)
        {
            // Mock search
            var testSuites = new List<TestSuite>
            {
                new TestSuite { Id = 1, Details = "Sample test suite" }
            };

            if (!string.IsNullOrEmpty(query))
            {
                testSuites = testSuites.Where(ts =>
                    ts.Details.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return testSuites;
        }

        public async Task<IEnumerable<Requirement>> SearchRequirementsAsync(string query, int testProjectId)
        {
            // Mock search
            var requirements = new List<Requirement>
            {
                new Requirement { Id = 1, Name = "User Login Requirement", Description = "System must allow user login", TestprojectId = 1 }
            };

            if (!string.IsNullOrEmpty(query))
            {
                requirements = requirements.Where(r =>
                    r.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    r.Description.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return requirements.Where(r => r.TestprojectId == testProjectId);
        }

        public async Task<IEnumerable<RequirementSpec>> SearchRequirementSpecsAsync(string query, int testProjectId)
        {
            // Mock search
            var reqSpecs = new List<RequirementSpec>
            {
                new RequirementSpec { Id = 1, Name = "Functional Requirements", Description = "Functional requirements spec", TestprojectId = 1, TotalRequirement = 10, Status = 1, Type = 1 }
            };

            if (!string.IsNullOrEmpty(query))
            {
                reqSpecs = reqSpecs.Where(rs =>
                    rs.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    rs.Description.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return reqSpecs.Where(rs => rs.TestprojectId == testProjectId);
        }

        public async Task<SearchResult> PerformGlobalSearchAsync(string query, int testProjectId)
        {
            var result = new SearchResult
            {
                TestCases = await SearchTestCasesAsync(query, testProjectId),
                TestSuites = await SearchTestSuitesAsync(query, testProjectId),
                Requirements = await SearchRequirementsAsync(query, testProjectId),
                RequirementSpecs = await SearchRequirementSpecsAsync(query, testProjectId)
            };

            return result;
        }
    }
}
