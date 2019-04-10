using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Sift
{
    public class LabelRequest : SiftRequest
    {
        static readonly String LabelUrl = @"https://api.sift.com/v205/users/{0}/labels";

        [JsonIgnore]
        public string UserId { get; set; }

        [JsonProperty("$api_key", NullValueHandling = NullValueHandling.Ignore)]
        public override string ApiKey { get; set; }

        [JsonProperty("$is_bad", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsBad { get; set; }

        [JsonProperty("$abuse_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AbuseType { get; set; }

        [JsonProperty("$description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("$source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("$analyst", NullValueHandling = NullValueHandling.Ignore)]
        public string Analyst { get; set; }

        [JsonIgnore]
        public override HttpRequestMessage Request
        {
            get
            {
                var request = new HttpRequestMessage(HttpMethod.Post, Url);
                request.Content = new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
                return request;
            }
        }

        [JsonIgnore]
        protected override Uri Url
        {
            get
            {
                return new Uri(String.Format(LabelUrl,
                                             Uri.EscapeDataString(UserId)));
            }
        }
    }
}