using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Business.Interface;
using Microsoft.GraphAPI.Messages.Core.Interface;
using Microsoft.GraphAPI.Messages.Enum;
using Microsoft.GraphAPI.Messages.Extensions;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Business
{
    internal class MessageManager : IMessageManager
    {
        private readonly IHttpCall _call;

        public MessageManager(IHttpCall call)
        {
            _call = call;
        }

        public async Task<IList<Message>> GetAsync(string userId, FilterConditions filterConditions)
        {
            StringBuilder urlBuilder = new StringBuilder($"users/{userId}/");

            switch (filterConditions.Folder)
            {
                case Folder.All:
                    urlBuilder.Append($"messages");
                    break;
                case Folder.DeletedItems:
                    urlBuilder.Append($"mailFolders('DeletedItems')/messages");
                    break;
                case Folder.Drafts:
                    urlBuilder.Append($"mailFolders('Drafts')/messages");
                    break;
                case Folder.Inbox:
                    urlBuilder.Append($"mailFolders('Inbox')/messages");
                    break;
                case Folder.SentItems:
                    urlBuilder.Append($"mailFolders('SentItems')/messages");
                    break;
            }

            if (!string.IsNullOrEmpty(filterConditions.ConversationId))
                urlBuilder.Append($"?$filter=conversationId%20eq%20'{filterConditions.ConversationId}'&$top={filterConditions.Top}");
            else if (!string.IsNullOrEmpty(filterConditions.SearchText))
                urlBuilder.Append($"?$search=\"{filterConditions.SearchText}\"&$top={filterConditions.Top}");
            else if (filterConditions.Unread.HasValue)
                urlBuilder.Append($"?$filter=isRead eq {!filterConditions.Unread.Value} And ReceivedDateTime ge {filterConditions.LastReceivedDateTime} ");
            else if (!string.IsNullOrEmpty(filterConditions.LastReceivedDateTime))
                urlBuilder.Append($"?$filter= ReceivedDateTime ge {filterConditions.LastReceivedDateTime}");
            else
            {
                urlBuilder.Append($"?$count={filterConditions.Count.ToString().ToLower()}");
                urlBuilder.Append($"&$orderby={filterConditions.OrderBy.GetEnumDescription()}");
                urlBuilder.Append($"&$skip={filterConditions.Skip}");
                urlBuilder.Append($"&$top={filterConditions.Top}");
            }

            urlBuilder.Append($"&$expand=attachments($select=id,lastModifiedDateTime,name,contentType,size)");

            return await _call.GetAsync<IList<Message>>(urlBuilder.ToString()).ConfigureAwait(false);
        }

        public async Task<Message> GetAsync(string userId, string messageId)
        {
            return await _call.GetAsync<Message>($"users/{userId}/messages/{messageId}?$expand=attachments($select=id,lastModifiedDateTime,name,contentType,size)").ConfigureAwait(false);
        }

        public async Task<Message> ComposeAsync(string userId, Message message)
        {
            return await _call.PostAsync<Message, Message>($"users/{userId}/messages", message).ConfigureAwait(false);
        }

        public async Task<Message> UpdateAsync(string userId, string messageId, Message message)
        {
            return await _call.PatchAsync<Message, Message>($"users/{userId}/messages/{messageId}", message).ConfigureAwait(false);
        }

        public async Task<Message> DeleteAsync(string userId, string messageId)
        {
            return await _call.DeleteAsync<Message>($"users/{userId}/messages/{messageId}").ConfigureAwait(false);
        }

        public async Task<Message> SendAsync(string userId, Message message)
        {
            return await _call.PostAsync<Message, Message>($"users/{userId}/sendMail", message).ConfigureAwait(false);
        }

        public async Task<Message> ComposeReplyAsync(string userId, string messageId)
        {
            return await _call.PostAsync<Message, Message>($"users/{userId}/messages/{messageId}/createReply", null).ConfigureAwait(false);
        }

        public async Task<Message> ComposeReplyAllAsync(string userId, string messageId)
        {
            return await _call.PostAsync<Message, Message>($"users/{userId}/messages/{messageId}/createReplyAll", null).ConfigureAwait(false);
        }

        public async Task<Message> ComposeForwardAsync(string userId, string messageId)
        {
            return await _call.PostAsync<Message, Message>($"users/{userId}/messages/{messageId}/createForward", null).ConfigureAwait(false);
        }

        public async Task<Message> CopyAsync(string userId, string messageId, string destinationId)
        {
            return await _call.PostAsync<Message, string>($"users/{userId}/messages/{messageId}/copy", destinationId).ConfigureAwait(false);
        }

        public async Task<Message> MoveAsync(string userId, string messageId, string destinationId)
        {
            return await _call.PostAsync<Message, string>($"users/{userId}/messages/{messageId}/move", destinationId).ConfigureAwait(false);
        }

        public async Task<HttpStatusCode> SendAsync(string userId, string messageId)
        {
            return await _call.PostAsync<Message>($"users/{userId}/messages/{messageId}/send", null).ConfigureAwait(false);
        }
    }
}
