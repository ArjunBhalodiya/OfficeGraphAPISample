using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Business.Interface
{
    internal interface IMessageManager
    {
        Task<Message> GetAsync(string userId, string messageId);
        Task<IList<Message>> GetAsync(string userId, FilterConditions filterConditions);
        Task<Message> ComposeAsync(string userId, Message message);
        Task<Message> UpdateAsync(string userId, string messageId, Message message);
        Task<Message> DeleteAsync(string userId, string messageId);
        Task<HttpStatusCode> SendAsync(string userId, string messageId);
        Task<Message> SendAsync(string userId, Message message);
        Task<Message> ComposeReplyAsync(string userId, string messageId);
        Task<Message> ComposeReplyAllAsync(string userId, string messageId);
        Task<Message> ComposeForwardAsync(string userId, string messageId);
        Task<Message> CopyAsync(string userId, string messageId, string destinationId);
        Task<Message> MoveAsync(string userId, string messageId, string destinationId);
    }
}