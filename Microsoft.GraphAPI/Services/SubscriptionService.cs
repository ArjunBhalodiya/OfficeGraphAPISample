using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Business.Interface;
using Microsoft.GraphAPI.Messages.Models;
using Microsoft.GraphAPI.Messages.Services.Interface;

namespace Microsoft.GraphAPI.Messages.Services
{
    internal class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionManager _officeSubscriptionService;

        public SubscriptionService(ISubscriptionManager officeSubscriptionService)
        {
            _officeSubscriptionService = officeSubscriptionService;
        }

        public async Task<Subscription> CreateAsync(Subscription subscription)
        {
            return await _officeSubscriptionService.CreateAsync(subscription).ConfigureAwait(false);
        }

        public async Task<Subscription> DeleteAsync(string id)
        {
            return await _officeSubscriptionService.DeleteAsync(id).ConfigureAwait(false);
        }

        public async Task<List<Subscription>> GetAsync()
        {
            return await _officeSubscriptionService.GetAsync().ConfigureAwait(false);
        }

        public async Task<Subscription> GetAsync(string id)
        {
            return await _officeSubscriptionService.GetAsync(id).ConfigureAwait(false);
        }
    }
}
