using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Business.Interface;
using Microsoft.GraphAPI.Messages.Models;
using Microsoft.GraphAPI.Messages.Services.Interface;

namespace Microsoft.GraphAPI.Messages.Services
{
    internal class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentManager _officeAttachmentManager;

        public AttachmentService(IAttachmentManager officeAttachmentManager)
        {
            _officeAttachmentManager = officeAttachmentManager;
        }

        /// <summary>
        /// This method used to add attachemnts to message
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <param name="officeAttachment"></param>
        /// <returns></returns>
        public async Task<FileAttachment> AddAsync(string userId, string messageId, FileAttachment officeAttachment)
        {
            return await _officeAttachmentManager.AddAsync(userId, messageId, officeAttachment).ConfigureAwait(false);
        }

        /// <summary>
        /// This method used to get attachemnts to message
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task<IList<FileAttachment>> GetAsync(string userId, string messageId)
        {
            return await _officeAttachmentManager.GetAsync(userId, messageId).ConfigureAwait(false);
        }

        /// <summary>
        /// This method used to delete attachemnts to message
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string userId, string messageId, string attachmentId)
        {
            return await _officeAttachmentManager.DeleteAsync(userId, messageId, attachmentId).ConfigureAwait(false);
        }

        /// <summary>
        /// This method used to get attachemnt to message
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        public async Task<FileAttachment> GetAsync(string userId, string messageId, string attachmentId)
        {
            return await _officeAttachmentManager.GetAsync(userId, messageId, attachmentId).ConfigureAwait(false);
        }
    }
}