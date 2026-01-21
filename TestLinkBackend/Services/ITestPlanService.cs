using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface ITestPlanService
    {
        Task<IEnumerable<Testplan>> GetAllAsync();
        Task<Testplan> GetByIdAsync(int id);
        Task<Testplan> CreateAsync(Testplan testplan);
        Task<Testplan> UpdateAsync(int id, Testplan testplan);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Testplan>> GetByTestProjectAsync(int testProjectId);
        Task AssignTestCaseAsync(int testPlanId, int testCaseId);
        Task<IEnumerable<Testcase>> GetAssignedTestCasesAsync(int testPlanId);
    }
}
