using LazyCache;
using mtg_library.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace mtg_library.Services
{
    public class ScryfallService
    {
        private readonly IAppCache appCache;
        RestService _scry;

        public ScryfallService (IAppCache appCache)
        {
            _scry = new RestService(appCache, "https://api.scryfall.com");
            this.appCache = appCache;
        }

        public async Task<Card> GetCard (string id)
        {
            var response = await _scry.Get($"/cards/{id}");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Card>(json);
        }
    }
}