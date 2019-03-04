using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Business.Interface;
using Microsoft.GraphAPI.Messages.Core.Interface;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Business
{
    internal class LicenseManager : ILicenseManager
    {
        private readonly IHttpCall _call;

        public LicenseManager(IHttpCall call)
        {
            _call = call;
        }

        public async Task<User> AssignAsync(string userId, UserLicense UserLicense)
        {
            return await _call.PostAsync<User, UserLicense>($"users/{userId}/assignLicense", UserLicense).ConfigureAwait(false);
        }
    }
}
