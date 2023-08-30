using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sift
{
    public class GetDecisionsResponse : SiftResponse
    {
        [JsonProperty("data")]
        public List<DecisionJson> Decisions { get; set; }

        public class DecisionJson
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("entity_type")]
            public string EntityType { get; set; }

            [JsonProperty("abuse_type")]
            public string AbuseType { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("webhook_url")]
            public string WebhookUrl { get; set; }

            [JsonProperty("created_at")]
            public long CreatedAt { get; set; }

            [JsonProperty("created_by")]
            public string CreatedBy { get; set; }

            [JsonProperty("updated_at")]
            public long UpdatedAt { get; set; }

            [JsonProperty("updated_by")]
            public string UpdatedBy { get; set; }
        }
    }
}
