using System;
using Newtonsoft.Json;

namespace Friends.Models
{
    public  class Picture
    {
        [JsonProperty("large")]
        public Uri Large { get; set; }

        [JsonProperty("medium")]
        public Uri Medium { get; set; }

        [JsonProperty("thumbnail")]
        public Uri Thumbnail { get; set; }
    }
}