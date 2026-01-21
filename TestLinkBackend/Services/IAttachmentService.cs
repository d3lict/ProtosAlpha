using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface IAttachmentService
    {
        Task<IEnumerable<Attachment>> GetAllAsync();
        Task<Attachment> GetByIdAsync(int id);
        Task<Attachment> UploadAsync(int fkId, string fkTable, string title, IFormFile file);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Attachment>> GetByEntityAsync(int fkId, string fkTable);
        Task<byte[]> DownloadAsync(int id);
    }
}
