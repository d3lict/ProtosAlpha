using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface ITestProjectService
    {
        Task<IEnumerable<Testproject>> GetAllAsync();
        Task<Testproject> GetByIdAsync(int id);
        Task<Testproject> CreateAsync(Testproject testproject);
        Task<IEnumerable<Testcase>> GetTestCasesAsync(int testprojectId);
        Task<IEnumerable<Testplan>> GetTestPlansAsync(int testprojectId);
    }
}
