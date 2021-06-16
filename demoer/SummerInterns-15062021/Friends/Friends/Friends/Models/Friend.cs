using Newtonsoft.Json;

namespace Friends.Models
{
    public  class Friend
    {
        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("dob")]
        public DateOfBirth DateOfBirth { get; set; }

        [JsonProperty("picture")]
        public Picture Picture { get; set; }

        [JsonProperty("nat")]
        public string Nationality { get; set; }
    }
}