using Newtonsoft.Json;

namespace FriendsBluePrint.Models
{
    public  class Timezone
    {
        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}