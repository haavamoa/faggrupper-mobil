using System;
using Newtonsoft.Json;

namespace FriendsBluePrint.Models
{
    public  class DateOfBirth
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }
    }
}