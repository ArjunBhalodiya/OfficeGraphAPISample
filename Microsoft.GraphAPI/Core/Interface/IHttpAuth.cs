using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.GraphAPI.Messages.Core.Interface
{
    interface IHttpAuth
    {
        Task<AuthenticationResult> AccessTokenAsync();
    }
}
