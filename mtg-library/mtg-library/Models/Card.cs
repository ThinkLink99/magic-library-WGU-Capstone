using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace mtg_library.Models
{
    public class Card
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public Guid OracleId { get; set; }
        public int[] MultiverseIds { get; set; }
        public int MTGOId { get; set; }
        public int MTGOFoilId { get; set; }
        public int TCGPlayerId { get; set; }
        public int CardMarketId { get; set; }
        public string Name { get; set; }
        public string Lang { get; set; }
        public DateTime ReleasedAt { get; set; }
        public Uri Uri { get; set; }
        public Uri ScryfallUri { get; set; }
        public string Layout { get; set; }
        public bool HasHighResImage { get; set; }
        public string ImageStatus { get; set; }
        [JsonProperty("image_uris")]
        public CardImageUris ImageUris { get; set; }
        public string ManaCost { get; set; }
        [JsonProperty("cmc")]
        public int ConvertedManaCost { get; set; }
        public string TypeLine { get; set; }
        public string OracleText { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string[] Colors { get; set; }
        public string[] ColorIdentity { get; set; }
        public string[] Keywords { get; set; }
        public CardLegalities Legalities { get; set; }
        public string[] Games { get; set; }
        public bool Reserved { get; set; }
        public bool Foil { get; set; }
        public bool Nonfoil { get; set; }
        public string[] Finishes { get; set; }
        public bool Oversized { get; set; }
        public bool Promo { get; set; }
        public bool Reprint { get; set; }
        public bool Variation { get; set; }
        public Guid SetId { get; set; }
        public string Set { get; set; }
        public string SetName { get; set; }
        public string SetType { get; set; }
        public Uri SetUri { get; set; }
        public Uri ScryfallSetUri { get; set; }
        public Uri RulingsUri { get; set; }
        public Uri PrintSearchUri { get; set; }
        public string CollectorNumber { get; set; }
        public bool Digital { get; set; }
        public string Rarity { get; set; }
        public Guid CardBackId { get; set; }
        public string Artist { get; set; }
        public string[] ArtistIds { get; set; }
        public string IllustrationIds { get; set; }
        public string BorderColor { get; set; }
        public string Frame { get; set; }
        public bool FullArt { get; set; }
        public bool Textless { get; set; }
        public bool Booster { get; set; }
        public bool StorySpotlight { get; set; }
        public int EDHRank { get; set; }
        public int PennyRank { get; set; }
        public 


        public class CardImageUris
        {
            [JsonProperty("small")]
            public Uri Small { get; set; }
            [JsonProperty("normal")]
            public Uri Normal { get; set; }
            [JsonProperty("large")]
            public Uri Large { get; set; }
            [JsonProperty("png")]
            public Uri Png { get; set; }
            [JsonProperty("art_crop")]
            public Uri ArtCrop { get; set; }
            [JsonProperty("border_crop")]
            public Uri BorderCrop { get; set; }
        }
        public class CardLegalities
        {
            public string Standard { get; set; }
            public string Future { get; set; }
            public string Historic { get; set; }
            public string Timeless { get; set; }
            public string Gladiator { get; set; }
            public string Pioneer { get; set; }
            public string Explorer { get; set; }
            public string Modern { get; set; }
            public string Legacy { get; set; }
            public string Pauper { get; set; }
            public string Vintage { get; set; }
            public string Penny { get; set; }
            public string Commander { get; set; }
            public string Oathbreaker { get; set; }
            public string StandardBrawl { get; set; }
            public string Brawl { get; set; }
            public string Alchemy { get; set; }
            public string PauperCommander { get; set; }
            public string Duel { get; set; }
            public string OldSchool { get; set; }
            public string Premodern { get; set; }
            public string Predh { get; set; }
        }
    {
  "edhrec_rank": 9904,
  "penny_rank": 4846,
  "prices": {
    "usd": "4.24",
    "usd_foil": "20.26",
    "usd_etched": null,
    "eur": "4.49",
    "eur_foil": "32.71",
    "tix": "0.18"
  },
  "related_uris": {
    "gatherer": "https://gatherer.wizards.com/Pages/Card/Details.aspx?multiverseid=37113&printed=false",
    "tcgplayer_infinite_articles": "https://tcgplayer.pxf.io/c/4931599/1830156/21018?subId1=api&trafcat=infinite&u=https%3A%2F%2Finfinite.tcgplayer.com%2Fsearch%3FcontentMode%3Darticle%26game%3Dmagic%26partner%3Dscryfall%26q%3DPhantom%2BNishoba",
    "tcgplayer_infinite_decks": "https://tcgplayer.pxf.io/c/4931599/1830156/21018?subId1=api&trafcat=infinite&u=https%3A%2F%2Finfinite.tcgplayer.com%2Fsearch%3FcontentMode%3Ddeck%26game%3Dmagic%26partner%3Dscryfall%26q%3DPhantom%2BNishoba",
    "edhrec": "https://edhrec.com/route/?cc=Phantom+Nishoba"
  },
  "purchase_uris": {
    "tcgplayer": "https://tcgplayer.pxf.io/c/4931599/1830156/21018?subId1=api&u=https%3A%2F%2Fwww.tcgplayer.com%2Fproduct%2F10190%3Fpage%3D1",
    "cardmarket": "https://www.cardmarket.com/en/Magic/Products/Singles/Judgment/Phantom-Nishoba?referrer=scryfall&utm_campaign=card_prices&utm_medium=text&utm_source=scryfall",
    "cardhoarder": "https://www.cardhoarder.com/cards/17622?affiliate_id=scryfall&ref=card-profile&utm_campaign=affiliate&utm_medium=card&utm_source=scryfall"
  }
}
}
