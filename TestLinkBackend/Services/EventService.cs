using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class EventService : IEventService
    {
        private static readonly List<Event> _events = new()
        {
            new Event { Id = 1, LogLevel = "INFO", Description = "User logged in", UserId = 1, Timestamp = DateTime.Now },
            new Event { Id = 2, LogLevel = "AUDIT", Description = "Test case created", UserId = 1, ObjectId = 1, ObjectType = "testcases", Timestamp = DateTime.Now.AddMinutes(-5) }
        };

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return _events.OrderByDescending(e => e.Timestamp);
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }

        public async Task<IEnumerable<Event>> GetFilteredAsync(string[] logLevels, int? objectId, string objectType, DateTime? startDate, DateTime? endDate, int[] userIds)
        {
            var query = _events.AsQueryable();

            if (logLevels != null && logLevels.Length > 0)
            {
                query = query.Where(e => logLevels.Contains(e.LogLevel));
            }

            if (objectId.HasValue)
            {
                query = query.Where(e => e.ObjectId == objectId);
            }

            if (!string.IsNullOrEmpty(objectType))
            {
                query = query.Where(e => e.ObjectType == objectType);
            }

            if (startDate.HasValue)
            {
                query = query.Where(e => e.Timestamp >= startDate);
            }

            if (endDate.HasValue)
            {
                query = query.Where(e => e.Timestamp <= endDate);
            }

            if (userIds != null && userIds.Length > 0)
            {
                query = query.Where(e => e.UserId.HasValue && userIds.Contains(e.UserId.Value));
            }

            return query.OrderByDescending(e => e.Timestamp);
        }

        public async Task ClearEventsAsync(string[] logLevels)
        {
            if (logLevels == null || logLevels.Length == 0)
            {
                _events.Clear();
            }
            else
            {
                _events.RemoveAll(e => logLevels.Contains(e.LogLevel));
            }
            await Task.CompletedTask;
        }

        public async Task LogEventAsync(Event @event)
        {
            @event.Id = _events.Max(e => e.Id) + 1;
            @event.Timestamp = DateTime.Now;
            _events.Add(@event);
            await Task.CompletedTask;
        }
    }
}
