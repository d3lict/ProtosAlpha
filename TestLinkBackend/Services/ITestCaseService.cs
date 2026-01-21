using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface ITestCaseService
    {
        Task<IEnumerable<Testcase>> GetAllAsync();
        Task<Testcase> GetByIdAsync(int id);
        Task<Testcase> CreateAsync(Testcase testcase);
        Task<Testcase> UpdateAsync(int id, Testcase testcase);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Testcase>> GetByTestProjectAsync(int testProjectId);
        Task AssignToTestPlanAsync(int testCaseId, int testPlanId);
        Task ExecuteAsync(int testCaseId, int testPlanId, bool status);
        Task<IEnumerable<TestcaseVersion>> GetVersionsAsync(int testCaseId);
    }
}
