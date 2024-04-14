using LazyCache;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace mtg_library.Services
{
    public class RestService
    {
        HttpClient _http;
        private readonly IAppCache _cache;

        public RestService (IAppCache appCache)
        {
            _cache = appCache;
            _http = new HttpClient();
        }
        public RestService(IAppCache appCache, string baseUri)
        {
            _cache = appCache;
            _http = new HttpClient();
            _http.BaseAddress = new System.Uri(baseUri);
        }

        public async Task<HttpResponseMessage> Get (string requestUri)
        {
            Func<Task<HttpResponseMessage>> getResponseFactory = async () =>
            {
                HttpResponseMessage response = await _http.GetAsync(requestUri);
                return response;
            };
            var retVal = await _cache.GetOrAddAsync(requestUri, getResponseFactory, DateTimeOffset.Now.AddHours(8));
            return retVal;
        }
        public async Task<HttpResponseMessage> Post(string requestUri, HttpContent httpContent)
        {
            return await _http.PostAsync(requestUri, httpContent);
        }
        public async Task<HttpResponseMessage> Put(string requestUri, HttpContent httpContent)
        {
            return await _http.PutAsync(requestUri, httpContent);
        }
        public async Task<HttpResponseMessage> Delete(string requestUri)
        {
            return await _http.DeleteAsync(requestUri);
        }
    }
}