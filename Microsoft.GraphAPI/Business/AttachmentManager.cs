using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Business.Interface;
using Microsoft.GraphAPI.Messages.Core.Interface;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Business
{
    internal class AttachmentManager : IAttachmentManager
    {
        private readonly IHttpCall _call;

        public AttachmentManager(IHttpCall call)
        {
            _call = call;
        }

        public async Task<IList<FileAttachment>> GetAsync(string userId, string messageId)
        {
            return await _call.GetAsync<IList<FileAttachment>>($"users/{userId}/messages/{messageId}/attachments").ConfigureAwait(false);
        }

        public async Task<FileAttachment> GetAsync(string userId, string messageId, string attachmentId)
        {
            return await _call.GetAsync<FileAttachment>($"users/{userId}/messages/{messageId}/attachments/{attachmentId}").ConfigureAwait(false);
        }

        public async Task<FileAttachment> AddAsync(string userId, string messageId, FileAttachment officeAttachments)
        {
            return await _call.PostAsync<FileAttachment, FileAttachment>($"users/{userId}/messages/{messageId}/attachments", officeAttachments).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(string userId, string messageId, string attachmentId)
        {
            return await _call.DeleteAsync<bool>($"users/{userId}/messages/{messageId}/attachments/{attachmentId}").ConfigureAwait(false);
        }
    }
}