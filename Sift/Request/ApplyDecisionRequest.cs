using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Sift
{
    public class ApplyDecisionRequest : SiftRequest
    {
        static readonly String ApplyDecisionUrl = @"https://api.sift.com/v3/accounts/{0}/users/{1}/decisions";

        [JsonIgnore]
        public string AccountId { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }

        [JsonIgnore]
        public override string ApiKey { get; set; }

        [JsonProperty("decision_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DecisionId { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("analyst", NullValueHandling = NullValueHandling.Ignore)]
        public string Analyst { get; set; }

        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonIgnore]
        public override HttpRequestMessage Request
        {
            get
            {
                var request = new HttpRequestMessage(HttpMethod.Post, Url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.Default.GetBytes(ApiKey)));
                request.Content = new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
                return request;
            }
        }

        [JsonIgnore]
        protected override Uri Url
        {
            get
            {
                return new Uri(String.Format(ApplyDecisionUrl, AccountId, UserId));
            }
        }
    }

    public class ApplyUserDecisionRequest : ApplyDecisionRequest
    {
    }

    public class ApplyOrderDecisionRequest : ApplyDecisionRequest
    {
        static readonly String APPLY_ORDER_DECISION_URL = @"https://api.siftscience.com/v3/accounts/{0}/users/{1}/orders/{2}/decisions";

        [JsonIgnore]
        public string OrderId { get; set; }

        [JsonIgnore]
        protected override Uri Url
        {
            get
            {
                return new Uri(String.Format(APPLY_ORDER_DECISION_URL, AccountId, UserId, OrderId));
            }
        }
    }

    public class ApplySessionDecisionRequest : ApplyDecisionRequest
    {
        static readonly String APPLY_SESSION_DECISION_URL = @"https://api.siftscience.com/v3/accounts/{0}/users/{1}/sessions/{2}/decisions";

        [JsonIgnore]
        public string SessionId { get; set; }

        [JsonIgnore]
        protected override Uri Url
        {
            get
            {
                return new Uri(String.Format(APPLY_SESSION_DECISION_URL, AccountId, UserId, SessionId));
            }
        }
    }

    public class ApplyContentDecisionRequest : ApplyDecisionRequest
    {
        static readonly String APPLY_CONTENT_DECISION_URL = @"https://api.siftscience.com/v3/accounts/{0}/users/{1}/content/{2}/decisions";

        [JsonIgnore]
        public string ContentId { get; set; }

        [JsonIgnore]
        protected override Uri Url
        {
            get
            {
                return new Uri(String.Format(APPLY_CONTENT_DECISION_URL, AccountId, UserId, ContentId));
            }
        }
    }

}