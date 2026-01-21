using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class PlatformService : IPlatformService
    {
        private static readonly List<Platform> _platforms = new()
        {
            new Platform { Id = 1, Name = "Windows 10", TestprojectId = 1 },
            new Platform { Id = 2, Name = "Linux Ubuntu", TestprojectId = 1 }
        };

        public async Task<IEnumerable<Platform>> GetAllAsync()
        {
            return _platforms;
        }

        public async Task<Platform> GetByIdAsync(int id)
        {
            return _platforms.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Platform> CreateAsync(Platform platform)
        {
            platform.Id = _platforms.Max(p => p.Id) + 1;
            _platforms.Add(platform);
            return platform;
        }

        public async Task<Platform> UpdateAsync(int id, Platform platform)
        {
            var existing = _platforms.FirstOrDefault(p => p.Id == id);
            if (existing == null) return null;

            existing.Name = platform.Name;
            existing.TestprojectId = platform.TestprojectId;

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var platform = _platforms.FirstOrDefault(p => p.Id == id);
            if (platform == null) return false;

            _platforms.Remove(platform);
            return true;
        }

        public async Task<IEnumerable<Platform>> GetByTestProjectAsync(int testProjectId)
        {
            return _platforms.Where(p => p.TestprojectId == testProjectId);
        }

        public async Task AssignToTestCaseAsync(int platformId, int testCaseId)
        {
            // Mock assignment
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Platform>> GetAssignedToTestCaseAsync(int testCaseId)
        {
            // Mock - return all platforms
            return _platforms;
        }
    }
}
