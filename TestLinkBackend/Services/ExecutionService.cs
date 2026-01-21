using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class ExecutionService : IExecutionService
    {
        private static readonly List<Execution> _executions = new()
        {
            new Execution { Id = 1, TestplanId = 1, TestcaseVersionId = 1, BuildId = 1, PlatformId = 1, ExecutionTs = DateTime.Now, Status = true }
        };

        public async Task<IEnumerable<Execution>> GetAllAsync()
        {
            return _executions;
        }

        public async Task<Execution> GetByIdAsync(int id)
        {
            return _executions.FirstOrDefault(e => e.Id == id);
        }

        public async Task<Execution> CreateAsync(Execution execution)
        {
            execution.Id = _executions.Max(e => e.Id) + 1;
            execution.ExecutionTs = DateTime.Now;
            _executions.Add(execution);
            return execution;
        }

        public async Task<Execution> UpdateAsync(int id, Execution execution)
        {
            var existing = _executions.FirstOrDefault(e => e.Id == id);
            if (existing == null) return null;

            existing.Status = execution.Status;
            // Update other fields as needed

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var execution = _executions.FirstOrDefault(e => e.Id == id);
            if (execution == null) return false;

            _executions.Remove(execution);
            return true;
        }

        public async Task<IEnumerable<Execution>> GetByTestPlanAsync(int testPlanId)
        {
            return _executions.Where(e => e.TestplanId == testPlanId);
        }

        public async Task AddBugAsync(int executionId, string bugDescription)
        {
            // Mock bug addition
            await Task.CompletedTask;
        }

        public async Task SetResultAsync(int executionId, bool status)
        {
            var execution = _executions.FirstOrDefault(e => e.Id == executionId);
            if (execution != null)
            {
                execution.Status = status;
            }
            await Task.CompletedTask;
        }
    }
}
