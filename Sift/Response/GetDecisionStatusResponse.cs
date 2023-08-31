using Newtonsoft.Json;

namespace Sift
{
    public class GetDecisionStatusResponse : SiftResponse
    {
        [JsonProperty("decisions")]
        public DecisionsByAbuseTypeJson Decisions { get; set; }

        public class DecisionsByAbuseTypeJson
        {
            [JsonProperty("account_abuse")]
            public DecisionStatusJson AccountAbuse { get; set; }

            [JsonProperty("payment_abuse")]
            public DecisionStatusJson PaymentAbuse { get; set; }

            [JsonProperty("promo_abuse")]
            public DecisionStatusJson PromoAbuse { get; set; }

            [JsonProperty("content_abuse")]
            public DecisionStatusJson ContentAbuse { get; set; }

            [JsonProperty("account_takeover")]
            public DecisionStatusJson AccountTakeover { get; set; }

            [JsonProperty("legacy")]
            public DecisionStatusJson Legacy { get; set; }
        }

        public class DecisionStatusJson
        {
            [JsonProperty("decision")]
            public DecisionJson Decision { get; set; }

            [JsonProperty("time")]
            public long Time { get; set; }

            [JsonProperty("webhook_succeeded")]
            public bool? WebhookSucceeded { get; set; }
        }

        public class DecisionJson
        {
            [JsonProperty("id")]
            public string Id { get; set; }
        }
    }
}
