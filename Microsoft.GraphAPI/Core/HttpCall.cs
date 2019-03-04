using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Core.Interface;
using Newtonsoft.Json;

namespace Microsoft.GraphAPI.Messages.Core
{
    internal class HttpCall : IHttpCall
    {
        private readonly IHttpAuth _auth;

        public HttpCall(IHttpAuth auth)
        {
            _auth = auth;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"{url}", HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                    var message = response.EnsureSuccessStatusCode();

                    var content = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<T>(content);
                }
                catch
                {
                    throw;
                }
            }
        }

        public async Task<T> GetAsync<T>(string url, string queryParamaters)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    await AddTokneToHeaderAsync(client).ConfigureAwait(false);
                    var response = await client.GetAsync($"{url}?{queryParamaters}", HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                    var message = response.EnsureSuccessStatusCode();

                    var content = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<T>(content);
                }
                catch
                {
                    throw;
                }
            }
        }

        public async Task<HttpStatusCode> PostAsync<T>(string url, T content)
        {
            using (HttpClient client = new HttpClient())
            {
                await AddTokneToHeaderAsync(client).ConfigureAwait(false);
                var contentString = JsonConvert.SerializeObject(content);
                var httpContent = new StringContent(contentString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{url}", httpContent).ConfigureAwait(false);
                return response.StatusCode;
            }
        }

        public async Task<TResponse> PostAsync<TResponse, TRequest>(string url, TRequest content)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    await AddTokneToHeaderAsync(client).ConfigureAwait(false);
                    var contentString = JsonConvert.SerializeObject(content);
                    var httpContent = new StringContent(contentString, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{url}", httpContent).ConfigureAwait(false);
                    var message = response.EnsureSuccessStatusCode();

                    var responseContent = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<TResponse>(responseContent);
                }
                catch
                {
                    throw;
                }
            }
        }

        public async Task<HttpStatusCode> PutAsync<T>(string url, T content)
        {
            using (HttpClient client = new HttpClient())
            {
                await AddTokneToHeaderAsync(client).ConfigureAwait(false);
                var contentString = JsonConvert.SerializeObject(content);
                var httpContent = new StringContent(contentString, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{url}", httpContent).ConfigureAwait(false);
                return response.StatusCode;
            }
        }

        public async Task<TResponse> PutAsync<TResponse, TRequest>(string url, TRequest content)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    await AddTokneToHeaderAsync(client).ConfigureAwait(false);
                    var contentString = JsonConvert.SerializeObject(content);
                    var httpContent = new StringContent(contentString, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync($"{url}", httpContent).ConfigureAwait(false);
                    var message = response.EnsureSuccessStatusCode();

                    var responseContent = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<TResponse>(responseContent);
                }
                catch
                {
                    throw;
                }
            }
        }

        public async Task<HttpStatusCode> PatchAsync<T>(string url, T content)
        {
            using (HttpClient client = new HttpClient())
            {
                await AddTokneToHeaderAsync(client).ConfigureAwait(false);
                var contentString = JsonConvert.SerializeObject(content);
                var httpContent = new StringContent(contentString, Encoding.UTF8, "application/json");
                var response = await client.PatchAsync($"{url}", httpContent).ConfigureAwait(false);
                return response.StatusCode;
            }
        }

        public async Task<TResponse> PatchAsync<TResponse, TRequest>(string url, TRequest content)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    await AddTokneToHeaderAsync(client).ConfigureAwait(false);
                    var contentString = JsonConvert.SerializeObject(content);
                    var httpContent = new StringContent(contentString, Encoding.UTF8, "application/json");
                    var response = await client.PatchAsync($"{url}", httpContent).ConfigureAwait(false);
                    var message = response.EnsureSuccessStatusCode();

                    var responseContent = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<TResponse>(responseContent);
                }
                catch
                {
                    throw;
                }
            }
        }

        public async Task<T> DeleteAsync<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    await AddTokneToHeaderAsync(client).ConfigureAwait(false);
                    var response = await client.DeleteAsync($"{url}").ConfigureAwait(false);
                    var message = response.EnsureSuccessStatusCode();

                    var content = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<T>(content);
                }
                catch
                {
                    throw;
                }
            }
        }

        public async Task<T> DeleteAsync<T>(string url, string queryParamaters)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    await AddTokneToHeaderAsync(client).ConfigureAwait(false);
                    var response = await client.DeleteAsync($"{url}?{queryParamaters}").ConfigureAwait(false);
                    var message = response.EnsureSuccessStatusCode();

                    var content = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<T>(content);
                }
                catch
                {
                    throw;
                }
            }
        }

        private async Task AddTokneToHeaderAsync(HttpClient client)
        {
            var token = await _auth.AccessTokenAsync().ConfigureAwait(false);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
        }
    }
}
