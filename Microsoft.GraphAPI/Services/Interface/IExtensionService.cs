using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Services.Interface
{
    public interface IExtensionService
    {
        Task<OpenTypeExtensionResponse> GetOpenExtensionMessageAsync(string userId, string messageId);
        Task<OpenTypeExtensionResponse> CreateOpenExtensionMessageAsync(string userId, string messageId, IList<Extension> request);
        Task<OpenTypeExtensionResponse> AddMessageIdAsync(string userId, string messageId, string messageExtensionId);
        Task<IList<Message>> GetBasedOnExtensionIdAsync(string userId, string messageExtensionId);
    }
}