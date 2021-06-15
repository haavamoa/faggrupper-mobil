using Newtonsoft.Json;

namespace FriendsBluePrint.Models
{
    public  class Street
    {
        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}