using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sift
{
    public class ScoreResponse : SiftResponse
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("scores")]
        public Dictionary<string, ScoreJson> Scores { get; set; }

        [JsonProperty("latest_labels")]
        public Dictionary<string, LabelJson> LatestLabels { get; set; }

        public class ScoreJson
        {
            [JsonProperty("score")]
            public double Score { get; set; }

            [JsonProperty("reasons")]
            public List<ReasonJson> Reasons { get; set; }

            [JsonProperty("time")]
            public long Time { get; set; }
        }

        public class LabelJson
        {
            [JsonProperty("is_bad")]
            public bool IsBad { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("time")]
            public long Time { get; set; }
        }

        public class ReasonJson
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("value")]
            public object Value { get; set; }

            [JsonProperty("details")]
            public Dictionary<string, object> Details { get; set; }
        }
    }
}
