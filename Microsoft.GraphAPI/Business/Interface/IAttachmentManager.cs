using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Business.Interface
{
    internal interface IAttachmentManager
    {
        Task<IList<FileAttachment>> GetAsync(string userId, string messageId);
        Task<FileAttachment> GetAsync(string userId, string messageId, string attachmentId);
        Task<FileAttachment> AddAsync(string userId, string messageId, FileAttachment officeAttachment);
        Task<bool> DeleteAsync(string userId, string messageId, string attachmentId);
    }
}
