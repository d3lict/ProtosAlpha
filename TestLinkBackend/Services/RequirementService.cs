using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class RequirementService : IRequirementService
    {
        private static readonly List<Requirement> _requirements = new()
        {
            new Requirement { Id = 1, Name = "User Login Requirement", Description = "System must allow user login", TestprojectId = 1 }
        };

        private static readonly List<RequirementVersion> _requirementVersions = new()
        {
            new RequirementVersion { Id = 1, RequirementId = 1, Version = 1, Name = "User Login Requirement v1", Description = "System must allow user login", Active = true }
        };

        public async Task<IEnumerable<Requirement>> GetAllAsync()
        {
            return _requirements;
        }

        public async Task<Requirement> GetByIdAsync(int id)
        {
            return _requirements.FirstOrDefault(r => r.Id == id);
        }

        public async Task<Requirement> CreateAsync(Requirement requirement)
        {
            requirement.Id = _requirements.Max(r => r.Id) + 1;
            _requirements.Add(requirement);
            return requirement;
        }

        public async Task<Requirement> UpdateAsync(int id, Requirement requirement)
        {
            var existing = _requirements.FirstOrDefault(r => r.Id == id);
            if (existing == null) return null;

            existing.Name = requirement.Name;
            existing.Description = requirement.Description;
            existing.TestprojectId = requirement.TestprojectId;

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var requirement = _requirements.FirstOrDefault(r => r.Id == id);
            if (requirement == null) return false;

            _requirements.Remove(requirement);
            return true;
        }

        public async Task<IEnumerable<Requirement>> GetByTestProjectAsync(int testProjectId)
        {
            return _requirements.Where(r => r.TestprojectId == testProjectId);
        }

        public async Task<IEnumerable<RequirementVersion>> GetVersionsAsync(int requirementId)
        {
            return _requirementVersions.Where(rv => rv.RequirementId == requirementId);
        }

        public async Task AssignToTestCaseAsync(int requirementId, int testCaseId)
        {
            // Mock assignment
            await Task.CompletedTask;
        }
    }
}
