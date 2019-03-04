using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.GraphAPI.Messages.Core
{
    internal class CoreCache
    {
        internal protected static AuthenticationResult token;
        internal protected static string baseUrl;
        internal protected static string tenant;
        internal protected static string appId;
        internal protected static string appSecrete;
        internal protected static string loginBaseUrl;

        public static void Configure(string baseUrl, string loginBaseUrl, string tenant, string appId, string appSecrete)
        {
            CoreCache.baseUrl = baseUrl;
            CoreCache.loginBaseUrl = loginBaseUrl;
            CoreCache.tenant = tenant;
            CoreCache.appId = appId;
            CoreCache.appSecrete = appSecrete;
        }

        internal protected static AuthenticationResult GetAccessToken()
        {
            return token;
        }

        internal protected static void SetAccessToken(AuthenticationResult token)
        {
            CoreCache.token = token;
        }
    }
}
