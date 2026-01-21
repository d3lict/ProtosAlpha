using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface IExecutionService
    {
        Task<IEnumerable<Execution>> GetAllAsync();
        Task<Execution> GetByIdAsync(int id);
        Task<Execution> CreateAsync(Execution execution);
        Task<Execution> UpdateAsync(int id, Execution execution);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Execution>> GetByTestPlanAsync(int testPlanId);
        Task AddBugAsync(int executionId, string bugDescription);
        Task SetResultAsync(int executionId, bool status);
    }
}
