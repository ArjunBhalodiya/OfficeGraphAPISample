using System;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Core.Interface;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.GraphAPI.Messages.Core
{
    internal class HttpAuth : CoreCache, IHttpAuth
    {
        public async Task<AuthenticationResult> AccessTokenAsync()
        {
            var accessToken = GetAccessToken();

            if (accessToken == null || (DateTimeOffset.UtcNow.ToUnixTimeSeconds() > accessToken.ExpiresOn.ToUnixTimeSeconds()))
            {
                try
                {
                    string authority = $"{loginBaseUrl}/{tenant}";

                    var clientCredential = new ClientCredential(appId, appSecrete);

                    var authContext = new AuthenticationContext(authority);
                    var result = await authContext.AcquireTokenAsync(baseUrl, clientCredential).ConfigureAwait(false);
                    if (authContext != null)
                        SetAccessToken(result);
                }
                catch
                {
                    throw;
                }
            }

            return GetAccessToken();
        }
    }
}
