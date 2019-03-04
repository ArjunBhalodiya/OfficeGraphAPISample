using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Business.Interface;
using Microsoft.GraphAPI.Messages.Models;
using Microsoft.GraphAPI.Messages.Services.Interface;

namespace Microsoft.GraphAPI.Messages.Services
{
    internal class LicenseService : ILicenseService
    {
        private readonly ILicenseManager _officeLincenseManager;

        public LicenseService(ILicenseManager officeLicenseManager)
        {
            _officeLincenseManager = officeLicenseManager;
        }

        /// <summary>
        /// Assign office license to specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="UserLicense"></param>
        /// <returns></returns>
        public async Task<User> AssignAsync(string userId, UserLicense UserLicense)
        {
            return await _officeLincenseManager.AssignAsync(userId, UserLicense).ConfigureAwait(false);
        }
    }
}