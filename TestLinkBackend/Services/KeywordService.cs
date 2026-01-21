using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class KeywordService : IKeywordService
    {
        private static readonly List<Keyword> _keywords = new()
        {
            new Keyword { Id = 1, Name = "Smoke Test", Notes = "Basic functionality test", TestprojectId = 1 },
            new Keyword { Id = 2, Name = "Regression", Notes = "Regression testing", TestprojectId = 1 }
        };

        public async Task<IEnumerable<Keyword>> GetAllAsync()
        {
            return _keywords;
        }

        public async Task<Keyword> GetByIdAsync(int id)
        {
            return _keywords.FirstOrDefault(k => k.Id == id);
        }

        public async Task<Keyword> CreateAsync(Keyword keyword)
        {
            keyword.Id = _keywords.Max(k => k.Id) + 1;
            _keywords.Add(keyword);
            return keyword;
        }

        public async Task<Keyword> UpdateAsync(int id, Keyword keyword)
        {
            var existing = _keywords.FirstOrDefault(k => k.Id == id);
            if (existing == null) return null;

            existing.Name = keyword.Name;
            existing.Notes = keyword.Notes;
            existing.TestprojectId = keyword.TestprojectId;

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var keyword = _keywords.FirstOrDefault(k => k.Id == id);
            if (keyword == null) return false;

            _keywords.Remove(keyword);
            return true;
        }

        public async Task<IEnumerable<Keyword>> GetByTestProjectAsync(int testProjectId)
        {
            return _keywords.Where(k => k.TestprojectId == testProjectId);
        }

        public async Task AssignToObjectAsync(int keywordId, int objectId, string tableName)
        {
            // Mock assignment - in real implementation, would add to object_keyword table
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Keyword>> GetAssignedToObjectAsync(int objectId, string tableName)
        {
            // Mock - return all keywords for the test project
            return _keywords.Where(k => k.TestprojectId == 1);
        }
    }
}
