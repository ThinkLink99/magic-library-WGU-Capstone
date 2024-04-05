using System.Net.Http;
using System.Threading.Tasks;

namespace mtg_library.Services
{
    public class RestService
    {
        HttpClient _http;

        public RestService ()
        {
            _http = new HttpClient();
        }
        public RestService(string baseUri)
        {
            _http = new HttpClient();
            _http.BaseAddress = new System.Uri(baseUri);
        }

        public async Task<HttpResponseMessage> Get (string requestUri)
        {
            return await _http.GetAsync(requestUri);
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