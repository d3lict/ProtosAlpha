using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface IKeywordService
    {
        Task<IEnumerable<Keyword>> GetAllAsync();
        Task<Keyword> GetByIdAsync(int id);
        Task<Keyword> CreateAsync(Keyword keyword);
        Task<Keyword> UpdateAsync(int id, Keyword keyword);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Keyword>> GetByTestProjectAsync(int testProjectId);
        Task AssignToObjectAsync(int keywordId, int objectId, string tableName);
        Task<IEnumerable<Keyword>> GetAssignedToObjectAsync(int objectId, string tableName);
    }
}
