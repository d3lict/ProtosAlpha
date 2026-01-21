using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class TestPlanService : ITestPlanService
    {
        private static readonly List<Testplan> _testplans = new()
        {
            new Testplan { Id = 1, Name = "Sample Test Plan", TestprojectId = 1 }
        };

        private static readonly List<Testcase> _assignedTestCases = new()
        {
            new Testcase { Id = 1, Name = "Login Test", Description = "Test login functionality", TestprojectId = 1 }
        };

        public async Task<IEnumerable<Testplan>> GetAllAsync()
        {
            return _testplans;
        }

        public async Task<Testplan> GetByIdAsync(int id)
        {
            return _testplans.FirstOrDefault(tp => tp.Id == id);
        }

        public async Task<Testplan> CreateAsync(Testplan testplan)
        {
            testplan.Id = _testplans.Max(tp => tp.Id) + 1;
            _testplans.Add(testplan);
            return testplan;
        }

        public async Task<Testplan> UpdateAsync(int id, Testplan testplan)
        {
            var existing = _testplans.FirstOrDefault(tp => tp.Id == id);
            if (existing == null) return null;

            existing.Name = testplan.Name;
            existing.TestprojectId = testplan.TestprojectId;

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var testplan = _testplans.FirstOrDefault(tp => tp.Id == id);
            if (testplan == null) return false;

            _testplans.Remove(testplan);
            return true;
        }

        public async Task<IEnumerable<Testplan>> GetByTestProjectAsync(int testProjectId)
        {
            return _testplans.Where(tp => tp.TestprojectId == testProjectId);
        }

        public async Task AssignTestCaseAsync(int testPlanId, int testCaseId)
        {
            // Mock assignment
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Testcase>> GetAssignedTestCasesAsync(int testPlanId)
        {
            return _assignedTestCases;
        }
    }
}
