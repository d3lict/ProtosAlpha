using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;

        public AttachmentsController(IAttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var attachments = await _attachmentService.GetAllAsync();
            return Ok(attachments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var attachment = await _attachmentService.GetByIdAsync(id);
            if (attachment == null)
                return NotFound();
            return Ok(attachment);
        }

        [HttpGet("entity/{fkId}/{fkTable}")]
        public async Task<IActionResult> GetByEntity(int fkId, string fkTable)
        {
            var attachments = await _attachmentService.GetByEntityAsync(fkId, fkTable);
            return Ok(attachments);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] int fkId, [FromForm] string fkTable, [FromForm] string title, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            var attachment = await _attachmentService.UploadAsync(fkId, fkTable, title, file);
            return CreatedAtAction(nameof(GetById), new { id = attachment.Id }, attachment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _attachmentService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

        [HttpGet("{id}/download")]
        public async Task<IActionResult> Download(int id)
        {
            var attachment = await _attachmentService.GetByIdAsync(id);
            if (attachment == null)
                return NotFound();

            var content = await _attachmentService.DownloadAsync(id);
            return File(content, attachment.FileType, attachment.FileName);
        }
    }
}
