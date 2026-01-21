using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class TestProjectService : ITestProjectService
    {
        private static readonly List<Testproject> _testprojects = new()
        {
            new Testproject { Id = 1, Prefix = "TP", ApiKey = "api-key-123", Name = "Sample Project", Description = "A sample test project", Active = true }
        };

        private static readonly List<Testcase> _testcases = new()
        {
            new Testcase { Id = 1, Name = "Login Test", Description = "Test login functionality", TestprojectId = 1 }
        };

        private static readonly List<Testplan> _testplans = new()
        {
            new Testplan { Id = 1, Name = "Sample Test Plan", TestprojectId = 1 }
        };

        public async Task<IEnumerable<Testproject>> GetAllAsync()
        {
            return _testprojects;
        }

        public async Task<Testproject> GetByIdAsync(int id)
        {
            return _testprojects.FirstOrDefault(tp => tp.Id == id);
        }

        public async Task<Testproject> CreateAsync(Testproject testproject)
        {
            testproject.Id = _testprojects.Max(tp => tp.Id) + 1;
            _testprojects.Add(testproject);
            return testproject;
        }

        public async Task<IEnumerable<Testcase>> GetTestCasesAsync(int testprojectId)
        {
            return _testcases.Where(tc => tc.TestprojectId == testprojectId);
        }

        public async Task<IEnumerable<Testplan>> GetTestPlansAsync(int testprojectId)
        {
            return _testplans.Where(tp => tp.TestprojectId == testprojectId);
        }
    }
}
