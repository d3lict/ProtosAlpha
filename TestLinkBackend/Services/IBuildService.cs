using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface IBuildService
    {
        Task<IEnumerable<Build>> GetAllAsync();
        Task<Build> GetByIdAsync(int id);
        Task<Build> CreateAsync(Build build);
        Task<Build> UpdateAsync(int id, Build build);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Build>> GetByTestProjectAsync(int testProjectId);
        Task<IEnumerable<Build>> GetByTestPlanAsync(int testPlanId);
    }
}
