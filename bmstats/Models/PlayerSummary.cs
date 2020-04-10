using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace bmstats.Models
{
    /// <summary>
    /// Represents a single player summary from ISteamUser/GetPlayerSummaries interface/method. Not every field will be populated
    /// depending on the user's privacy choices or omission of data completely.
    /// </summary>
    public partial class PlayerSummary
    {
        [JsonProperty("steamid")]
        public string Steamid { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }
}