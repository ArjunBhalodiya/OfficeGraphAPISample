using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Business.Interface;
using Microsoft.GraphAPI.Messages.Core.Interface;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Business
{
    internal class ExtensionManager : IExtensionManager
    {
        private readonly IHttpCall _call;

        public ExtensionManager(IHttpCall call)
        {
            _call = call;
        }

        public async Task<OpenTypeExtensionResponse> CreateAsync(string userId, string messageId, IList<Extension> extensions)
        {
            return await _call.PostAsync<OpenTypeExtensionResponse, IList<Extension>>($"users/{userId}/messages/{messageId}/extensions", extensions).ConfigureAwait(false);
        }

        public async Task<OpenTypeExtensionResponse> GetAsync(string userId, string messageId)
        {
            return await _call.GetAsync<OpenTypeExtensionResponse>($"users/{userId}/messages/{messageId}/extensions/com.homegenius").ConfigureAwait(false);
        }

        public async Task<OpenTypeExtensionResponse> AddMessageIdAsync(string userId, string messageId, string messageExtensionId)
        {
            // Add extension Id to Message Extension
            var extension = new List<Extension>
            {
                new Extension
                {
                    ExtensionName = messageExtensionId,
                    ODataType = "microsoft.graph.openTypeExtension",
                }
            };

            // Attach extension to specific message
            return await CreateAsync(userId, messageId, extension).ConfigureAwait(false);
        }

        public async Task<Collection<Message>> GetBasedOnExtensionIdAsync(string userId, string messageExtensionId)
        {
            return await _call.GetAsync<Collection<Message>>($"users/{userId}/messages?$filter=Extensions/any(f:f/id%20eq%20'{messageExtensionId}')" +
                                                                $"&$expand=Extensions($filter=id%20eq%20'{messageExtensionId}')").ConfigureAwait(false);
        }
    }
}
