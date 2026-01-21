using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class AttachmentService : IAttachmentService
    {
        private static readonly List<Attachment> _attachments = new();

        public async Task<IEnumerable<Attachment>> GetAllAsync()
        {
            return _attachments;
        }

        public async Task<Attachment> GetByIdAsync(int id)
        {
            return _attachments.FirstOrDefault(a => a.Id == id);
        }

        public async Task<Attachment> UploadAsync(int fkId, string fkTable, string title, IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var fileContent = memoryStream.ToArray();

            var attachment = new Attachment
            {
                Id = _attachments.Max(a => a.Id) + 1,
                FkId = fkId,
                FkTable = fkTable,
                Title = title,
                FileName = file.FileName,
                FileType = file.ContentType,
                FileSize = file.Length,
                FileContent = fileContent,
                CreationTs = DateTime.Now,
                AuthorId = 1 // Mock author
            };

            _attachments.Add(attachment);
            return attachment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var attachment = _attachments.FirstOrDefault(a => a.Id == id);
            if (attachment == null) return false;

            _attachments.Remove(attachment);
            return true;
        }

        public async Task<IEnumerable<Attachment>> GetByEntityAsync(int fkId, string fkTable)
        {
            return _attachments.Where(a => a.FkId == fkId && a.FkTable == fkTable);
        }

        public async Task<byte[]> DownloadAsync(int id)
        {
            var attachment = _attachments.FirstOrDefault(a => a.Id == id);
            return attachment?.FileContent ?? Array.Empty<byte>();
        }
    }
}
