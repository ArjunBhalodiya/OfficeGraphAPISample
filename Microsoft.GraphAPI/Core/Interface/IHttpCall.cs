using System.Net;
using System.Threading.Tasks;

namespace Microsoft.GraphAPI.Messages.Core.Interface
{
    internal interface IHttpCall
    {
        Task<T> GetAsync<T>(string url);

        Task<T> GetAsync<T>(string url, string queryParamaters);

        Task<HttpStatusCode> PostAsync<T>(string url, T content);

        Task<TResponse> PostAsync<TResponse, TRequest>(string url, TRequest content);

        Task<HttpStatusCode> PutAsync<T>(string url, T content);

        Task<TResponse> PutAsync<TResponse, TRequest>(string url, TRequest content);

        Task<HttpStatusCode> PatchAsync<T>(string url, T content);

        Task<TResponse> PatchAsync<TResponse, TRequest>(string url, TRequest content);

        Task<T> DeleteAsync<T>(string url);

        Task<T> DeleteAsync<T>(string url, string queryParamaters);
    }
}
