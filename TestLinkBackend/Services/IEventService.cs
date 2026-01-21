using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event> GetByIdAsync(int id);
        Task<IEnumerable<Event>> GetFilteredAsync(string[] logLevels, int? objectId, string objectType, DateTime? startDate, DateTime? endDate, int[] userIds);
        Task ClearEventsAsync(string[] logLevels);
        Task LogEventAsync(Event @event);
    }
}
