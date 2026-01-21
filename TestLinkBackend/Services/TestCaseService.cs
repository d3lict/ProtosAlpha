using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class TestCaseService : ITestCaseService
    {
        private static readonly List<Testcase> _testcases = new()
        {
            new Testcase { Id = 1, Name = "Login Test", Description = "Test login functionality", TestprojectId = 1 }
        };

        private static readonly List<TestcaseVersion> _testcaseVersions = new()
        {
            new TestcaseVersion { Id = 1, TestcaseId = 1, Version = 1, Name = "Login Test v1", Description = "Test login functionality", Active = true }
        };

        public async Task<IEnumerable<Testcase>> GetAllAsync()
        {
            return _testcases;
        }

        public async Task<Testcase> GetByIdAsync(int id)
        {
            return _testcases.FirstOrDefault(tc => tc.Id == id);
        }

        public async Task<Testcase> CreateAsync(Testcase testcase)
        {
            testcase.Id = _testcases.Max(tc => tc.Id) + 1;
            _testcases.Add(testcase);
            return testcase;
        }

        public async Task<Testcase> UpdateAsync(int id, Testcase testcase)
        {
            var existing = _testcases.FirstOrDefault(tc => tc.Id == id);
            if (existing == null) return null;

            existing.Name = testcase.Name;
            existing.Description = testcase.Description;
            existing.TestprojectId = testcase.TestprojectId;

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var testcase = _testcases.FirstOrDefault(tc => tc.Id == id);
            if (testcase == null) return false;

            _testcases.Remove(testcase);
            return true;
        }

        public async Task<IEnumerable<Testcase>> GetByTestProjectAsync(int testProjectId)
        {
            return _testcases.Where(tc => tc.TestprojectId == testProjectId);
        }

        public async Task AssignToTestPlanAsync(int testCaseId, int testPlanId)
        {
            // Mock assignment - in real implementation, would add to testplan_testcase table
            await Task.CompletedTask;
        }

        public async Task ExecuteAsync(int testCaseId, int testPlanId, bool status)
        {
            // Mock execution - in real implementation, would create execution record
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<TestcaseVersion>> GetVersionsAsync(int testCaseId)
        {
            return _testcaseVersions.Where(tv => tv.TestcaseId == testCaseId);
        }
    }
}
