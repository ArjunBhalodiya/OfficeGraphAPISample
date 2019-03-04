using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Services.Interface
{
    public interface ILicenseService
    {
        Task<User> AssignAsync(string userId, UserLicense UserLicense);
    }
}
