using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Business.Interface
{
    internal interface ILicenseManager
    {
        Task<User> AssignAsync(string userId, UserLicense UserLicense);
    }
}
