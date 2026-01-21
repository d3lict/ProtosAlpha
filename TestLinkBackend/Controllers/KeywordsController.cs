using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeywordsController : ControllerBase
    {
        private readonly IKeywordService _keywordService;

        public KeywordsController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var keywords = await _keywordService.GetAllAsync();
            return Ok(keywords);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var keyword = await _keywordService.GetByIdAsync(id);
            if (keyword == null)
                return NotFound();
            return Ok(keyword);
        }

        [HttpGet("testproject/{testProjectId}")]
        public async Task<IActionResult> GetByTestProject(int testProjectId)
        {
            var keywords = await _keywordService.GetByTestProjectAsync(testProjectId);
            return Ok(keywords);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Keyword keyword)
        {
            var created = await _keywordService.CreateAsync(keyword);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Keyword keyword)
        {
            var updated = await _keywordService.UpdateAsync(id, keyword);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _keywordService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

        [HttpPost("{id}/assign/{objectId}")]
        public async Task<IActionResult> AssignToObject(int id, int objectId, [FromQuery] string tableName)
        {
            await _keywordService.AssignToObjectAsync(id, objectId, tableName);
            return Ok();
        }

        [HttpGet("assigned/{objectId}")]
        public async Task<IActionResult> GetAssignedToObject(int objectId, [FromQuery] string tableName)
        {
            var keywords = await _keywordService.GetAssignedToObjectAsync(objectId, tableName);
            return Ok(keywords);
        }
    }
}
