using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Business.Interface
{
    internal interface ISubscriptionManager
    {
        Task<List<Subscription>> GetAsync();
        Task<Subscription> GetAsync(string id);
        Task<Subscription> CreateAsync(Subscription officeSubscription);
        Task<Subscription> DeleteAsync(string id);
    }
}
