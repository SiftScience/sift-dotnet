using Newtonsoft.Json;

namespace Sift
{
    public class ApplyDecisionResponse : SiftResponse
    {
        [JsonProperty("entity")]
        public EntityJson Entity { get; set; }

        [JsonProperty("decision")]
        public DecisionJson Decision { get; set; }

        public class EntityJson
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public class DecisionJson
        {
            [JsonProperty("id")]
            public string Id { get; set; }
        }
    }
}
