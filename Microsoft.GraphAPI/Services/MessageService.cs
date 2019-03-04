using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Business.Interface;
using Microsoft.GraphAPI.Messages.Contract.Interfaces.OfficeApi;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Services
{
    internal class MessageService : IMessageService
    {
        private readonly IMessageManager _officeMessageManager;

        public MessageService(IMessageManager officeMessageManager)
        {
            _officeMessageManager = officeMessageManager;
        }

        /// <summary>
        /// Get list of all messages.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="filterConditions"></param>
        /// <returns></returns>
        public async Task<IList<Message>> GetAsync(string userId, FilterConditions filterConditions)
        {
            if (filterConditions == null) filterConditions = new FilterConditions();

            // Get all message for specific user
            return await _officeMessageManager.GetAsync(userId, filterConditions).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a messages.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task<Message> GetAsync(string userId, string messageId)
        {
            // Get all message for specific user
            return await _officeMessageManager.GetAsync(userId, messageId).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to compose message in draft
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<Message> ComposeAsync(string userId, Message message)
        {
            return await _officeMessageManager.ComposeAsync(userId, message).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to update composed message in draft
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<Message> UpdateComposeAsync(string userId, string messageId, Message message)
        {
            return await _officeMessageManager.UpdateAsync(userId, messageId, message).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to delete composed/received/sent/trash/spam message
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task<Message> DeleteAsync(string userId, string messageId)
        {
            return await _officeMessageManager.DeleteAsync(userId, messageId).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to send composed message from draft
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> SendAsync(string userId, string messageId)
        {
            return await _officeMessageManager.SendAsync(userId, messageId).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to send message without saving it in draft
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<Message> SendAsync(string userId, Message message)
        {
            return await _officeMessageManager.SendAsync(userId, message).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to compose reply message in draft
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task<Message> ComposeReplyAsync(string userId, string messageId)
        {
            return await _officeMessageManager.ComposeReplyAsync(userId, messageId).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to compose reply all message in draft
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task<Message> ComposeReplyAllAsync(string userId, string messageId)
        {
            return await _officeMessageManager.ComposeReplyAllAsync(userId, messageId).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to compose forward message in draft
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <param name="ToRecipients"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Message> ComposeForwardAsync(string userId, string messageId)
        {
            return await _officeMessageManager.ComposeForwardAsync(userId, messageId).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to copy message to destination folder
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public async Task<Message> CopyAsync(string userId, string messageId, string destinationId)
        {
            return await _officeMessageManager.CopyAsync(userId, messageId, destinationId).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to move message to destination folder
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public async Task<Message> MoveAsync(string userId, string messageId, string destinationId)
        {
            return await _officeMessageManager.MoveAsync(userId, messageId, destinationId).ConfigureAwait(false);
        }
    }
}