using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Business.Interface;
using Microsoft.GraphAPI.Messages.Models;
using Microsoft.GraphAPI.Messages.Services.Interface;

namespace Microsoft.GraphAPI.Messages.Services
{
    internal class ExtensionService : IExtensionService
    {
        private readonly IExtensionManager _officeExtensionManager;

        public ExtensionService(IExtensionManager officeExtensionManager)
        {
            _officeExtensionManager = officeExtensionManager;
        }

        public async Task<OpenTypeExtensionResponse> GetOpenExtensionMessageAsync(string userId, string messageId)
        {
            return await _officeExtensionManager.GetAsync(userId, messageId).ConfigureAwait(false);
        }

        public async Task<OpenTypeExtensionResponse> CreateOpenExtensionMessageAsync(string userId, string messageId, IList<Extension> request)
        {
            return await _officeExtensionManager.CreateAsync(userId, messageId, request).ConfigureAwait(false);
        }

        public async Task<OpenTypeExtensionResponse> AddMessageIdAsync(string userId, string messageId, string messageExtensionId)
        {
            return await _officeExtensionManager.AddMessageIdAsync(userId, messageId, messageExtensionId).ConfigureAwait(false);
        }

        public async Task<IList<Message>> GetBasedOnExtensionIdAsync(string userId, string messageExtensionId)
        {
            return await _officeExtensionManager.GetBasedOnExtensionIdAsync(userId, messageExtensionId).ConfigureAwait(false);
        }
    }
}