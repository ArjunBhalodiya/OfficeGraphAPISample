using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Services.Interface
{
    public interface IAttachmentService
    {
        Task<FileAttachment> AddAsync(string userId, string messageId, FileAttachment officeAttachment);
        Task<IList<FileAttachment>> GetAsync(string userId, string messageId);
        Task<bool> DeleteAsync(string userId, string messageId, string attachmentId);
        Task<FileAttachment> GetAsync(string userId, string messageId, string attachmentId);
    }
}
