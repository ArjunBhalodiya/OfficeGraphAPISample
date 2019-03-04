using Microsoft.GraphAPI.Messages.Core;

namespace Microsoft.GraphAPI.Messages
{
    public class GraphApi
    {
        public static void Configure(string baseUrl, string loginBaseUrl, string tenant, string appId, string appSecrete)
        {
            CoreCache.Configure(baseUrl, loginBaseUrl, tenant, appId, appSecrete);
        }
    }
}
