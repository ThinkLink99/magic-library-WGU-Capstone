using LazyCache;
using mtg_library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mtg_library.Services
{
    public class ScryfallService
    {
        private readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

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
            return JsonConvert.DeserializeObject<Card>(json, settings);
        }

        public async Task<List<Card>> SearchCards(string cardText, bool[] filterColors)
        {
            string query = "";
         
            if (filterColors.Any(c => c == true)) { query += "c%3A"; }
            if (filterColors[0]) // black
                query += "b";
            if (filterColors[1]) // blue
                query += "u";
            if (filterColors[2]) // red
                query += "r";
            if (filterColors[3]) // green
                query += "g";
            if (filterColors[4]) // white
                query += "w";

            

            if (!string.IsNullOrWhiteSpace(cardText)) 
            {
                if (!string.IsNullOrWhiteSpace(query)) query += "+";
                query += $"o%3A{cardText}"; 
            }

            if (string.IsNullOrWhiteSpace(query)) { return null; }
            var response = await _scry.Get($"/cards/search?q={query}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                
                var obj = JsonConvert.DeserializeObject<ScryList<Card>>(json, settings);
                return obj.Data.ToList();
            }
            else
            {
                return null;
            }
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ScryList<TListObject>
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("data")]
        public TListObject[] Data { get; set; }
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
        [JsonProperty("next_page")]
        public Uri NextPage { get; set; }
        [JsonProperty("total_cards")]
        public int TotalCards { get; set; }
        [JsonProperty("warnings")]
        public string[] Warnings { get; set; }
    }
}