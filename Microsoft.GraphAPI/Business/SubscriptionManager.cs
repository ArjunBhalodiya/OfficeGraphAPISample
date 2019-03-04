using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Business.Interface;
using Microsoft.GraphAPI.Messages.Core.Interface;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Business
{
    internal class SubscriptionManager : ISubscriptionManager
    {
        private readonly IHttpCall _call;

        public SubscriptionManager(IHttpCall call)
        {
            _call = call;
        }

        public async Task<List<Subscription>> GetAsync()
        {
            return await _call.GetAsync<List<Subscription>>("subscriptions").ConfigureAwait(false);
        }

        public async Task<Subscription> GetAsync(string id)
        {
            return await _call.GetAsync<Subscription>($"subscriptions/{id}").ConfigureAwait(false);
        }

        public async Task<Subscription> CreateAsync(Subscription officeSubscription)
        {
            return await _call.PostAsync<Subscription, Subscription>($"subscriptions", officeSubscription).ConfigureAwait(false);
        }

        public async Task<Subscription> DeleteAsync(string id)
        {
            return await _call.DeleteAsync<Subscription>($"subscriptions/{id}").ConfigureAwait(false);
        }
    }
}