using mtg_library.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace mtg_library.Services
{
    public class ScryfallService
    {
        RestService _scry;

        public ScryfallService ()
        {
            _scry = new RestService("https://api.scryfall.com");
        }

        public async Task<Card> GetCard (string id)
        {
            var response = await _scry.Get($"/cards/{id}");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Card>(json);
        }
    }
}