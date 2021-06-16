using Newtonsoft.Json;

namespace Friends.Models
{
    public  class Timezone
    {
        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}