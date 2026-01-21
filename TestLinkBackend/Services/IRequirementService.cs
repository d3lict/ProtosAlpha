using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface IRequirementService
    {
        Task<IEnumerable<Requirement>> GetAllAsync();
        Task<Requirement> GetByIdAsync(int id);
        Task<Requirement> CreateAsync(Requirement requirement);
        Task<Requirement> UpdateAsync(int id, Requirement requirement);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Requirement>> GetByTestProjectAsync(int testProjectId);
        Task<IEnumerable<RequirementVersion>> GetVersionsAsync(int requirementId);
        Task AssignToTestCaseAsync(int requirementId, int testCaseId);
    }
}
