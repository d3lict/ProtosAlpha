using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class BuildService : IBuildService
    {
        private static readonly List<Build> _builds = new()
        {
            new Build { Id = 1, Name = "Build 1.0", TestprojectId = 1 }
        };

        public async Task<IEnumerable<Build>> GetAllAsync()
        {
            return _builds;
        }

        public async Task<Build> GetByIdAsync(int id)
        {
            return _builds.FirstOrDefault(b => b.Id == id);
        }

        public async Task<Build> CreateAsync(Build build)
        {
            build.Id = _builds.Max(b => b.Id) + 1;
            _builds.Add(build);
            return build;
        }

        public async Task<Build> UpdateAsync(int id, Build build)
        {
            var existing = _builds.FirstOrDefault(b => b.Id == id);
            if (existing == null) return null;

            existing.Name = build.Name;
            existing.TestprojectId = build.TestprojectId;

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var build = _builds.FirstOrDefault(b => b.Id == id);
            if (build == null) return false;

            _builds.Remove(build);
            return true;
        }

        public async Task<IEnumerable<Build>> GetByTestProjectAsync(int testProjectId)
        {
            return _builds.Where(b => b.TestprojectId == testProjectId);
        }

        public async Task<IEnumerable<Build>> GetByTestPlanAsync(int testPlanId)
        {
            // Mock - builds are per test project, not test plan
            return _builds.Where(b => b.TestprojectId == 1);
        }
    }
}
