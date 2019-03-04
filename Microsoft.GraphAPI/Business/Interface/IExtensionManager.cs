using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Business.Interface
{
    internal interface IExtensionManager
    {
        Task<OpenTypeExtensionResponse> GetAsync(string userId, string messageId);
        Task<OpenTypeExtensionResponse> CreateAsync(string userId, string messageId, IList<Extension> extensions);
        Task<OpenTypeExtensionResponse> AddMessageIdAsync(string userId, string messageId, string messageExtensionId);
        Task<Collection<Message>> GetBasedOnExtensionIdAsync(string userId, string messageExtensionId);
    }
}
