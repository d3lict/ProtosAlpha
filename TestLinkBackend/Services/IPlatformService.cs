using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface IPlatformService
    {
        Task<IEnumerable<Platform>> GetAllAsync();
        Task<Platform> GetByIdAsync(int id);
        Task<Platform> CreateAsync(Platform platform);
        Task<Platform> UpdateAsync(int id, Platform platform);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Platform>> GetByTestProjectAsync(int testProjectId);
        Task AssignToTestCaseAsync(int platformId, int testCaseId);
        Task<IEnumerable<Platform>> GetAssignedToTestCaseAsync(int testCaseId);
    }
}
