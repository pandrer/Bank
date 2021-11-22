namespace CatalogMicroservice.Setup.CountryStateCity.Model
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Country
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("iso3")]
        public string Iso3 { get; set; }

        [JsonProperty("iso2")]
        public string Iso2 { get; set; }

        [JsonProperty("numeric_code")]
        public string NumericCode { get; set; }

        [JsonProperty("phone_code")]
        public string PhoneCode { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("tld")]
        public string Tld { get; set; }

        [JsonProperty("native")]
        public string Native { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("subregion")]
        public string Subregion { get; set; }

        [JsonProperty("timezones")]
        public List<Timezone> Timezones { get; set; }

        [JsonProperty("translations")]
        public Translations Translations { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("emoji")]
        public string Emoji { get; set; }

        [JsonProperty("emojiU")]
        public string EmojiU { get; set; }

        [JsonProperty("states")]
        public List<State> States { get; set; }
    }

    public class State
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state_code")]
        public string StateCode { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("cities")]
        public List<City> Cities { get; set; }
    }

    public class City
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }

    public class Timezone
    {
        [JsonProperty("zoneName")]
        public string ZoneName { get; set; }

        [JsonProperty("gmtOffset")]
        public long GmtOffset { get; set; }

        [JsonProperty("gmtOffsetName")]
        public string GmtOffsetName { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("tzName")]
        public string TzName { get; set; }
    }

    public class Translations
    {
        [JsonProperty("kr")]
        public string Kr { get; set; }

        [JsonProperty("br", NullValueHandling = NullValueHandling.Ignore)]
        public string Br { get; set; }

        [JsonProperty("pt", NullValueHandling = NullValueHandling.Ignore)]
        public string Pt { get; set; }

        [JsonProperty("nl", NullValueHandling = NullValueHandling.Ignore)]
        public string Nl { get; set; }

        [JsonProperty("hr", NullValueHandling = NullValueHandling.Ignore)]
        public string Hr { get; set; }

        [JsonProperty("fa", NullValueHandling = NullValueHandling.Ignore)]
        public string Fa { get; set; }

        [JsonProperty("de", NullValueHandling = NullValueHandling.Ignore)]
        public string De { get; set; }

        [JsonProperty("es", NullValueHandling = NullValueHandling.Ignore)]
        public string Es { get; set; }

        [JsonProperty("fr", NullValueHandling = NullValueHandling.Ignore)]
        public string Fr { get; set; }

        [JsonProperty("ja", NullValueHandling = NullValueHandling.Ignore)]
        public string Ja { get; set; }

        [JsonProperty("it", NullValueHandling = NullValueHandling.Ignore)]
        public string It { get; set; }

        [JsonProperty("cn")]
        public string Cn { get; set; }
    }

}
