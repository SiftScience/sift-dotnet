using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sift
{
    public class SiftResponse
    {
        [JsonProperty("status")]
        public int? Status { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("issues")]
        public Dictionary<string, string> Issues { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }
    }
}
