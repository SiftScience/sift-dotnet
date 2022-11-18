using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Sift
{
    public class VerificationCheckRequest : SiftRequest
    {
        static readonly String VerificationCheckUrl = @"https://api.sift.com/v1.1/verification/check";

        [JsonIgnore]
        public override string ApiKey { get; set; }

        [JsonProperty("$user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("$code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code { get; set; }

        [JsonProperty("$verified_event", NullValueHandling = NullValueHandling.Ignore)]
        public string VerifiedEvent { get; set; }

        [JsonProperty("$verified_entity_id", NullValueHandling = NullValueHandling.Ignore)]
        public string VerifiedEntityId { get; set; }

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
                return new Uri(VerificationCheckUrl);
            }
        }
    }

    public class VerificationSendRequest : SiftRequest
    {
        static readonly String VerificationSendUrl = @"https://api.sift.com/v1.1/verification/send";

        [JsonIgnore]
        public override string ApiKey { get; set; }

        [JsonProperty("$user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }


        [JsonProperty("$send_to", NullValueHandling = NullValueHandling.Ignore)]
        public string SendTo { get; set; }

        [JsonProperty("$verification_type", NullValueHandling = NullValueHandling.Ignore)]
        public string VerificationType { get; set; }

        [JsonProperty("$brand_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BrandName { get; set; }

        [JsonProperty("$language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("$event")]
        public VerificationSendEvent Event { get; set; }

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
                return new Uri(VerificationSendUrl);
            }
        }
    }

    public class VerificationReSendRequest : SiftRequest
    {
        static readonly String VerificationReSendUrl = @"https://api.sift.com/v1.1/verification/resend";

        [JsonIgnore]
        public override string ApiKey { get; set; }

        [JsonProperty("$user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("$verified_event", NullValueHandling = NullValueHandling.Ignore)]
        public string VerifiedEvent { get; set; }

        [JsonProperty("$verified_entity_id", NullValueHandling = NullValueHandling.Ignore)]
        public string VerifiedEntityId { get; set; }

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
                return new Uri(VerificationReSendUrl);
            }
        }
    }


    public class VerificationSendEvent
    {
        [JsonProperty("$session_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get; set; }

        [JsonProperty("$verified_event", NullValueHandling = NullValueHandling.Ignore)]
        public string VerifiedEvent { get; set; }

        [JsonProperty("$reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }

        [JsonProperty("$ip", NullValueHandling = NullValueHandling.Ignore)]
        public string IP { get; set; }

        [JsonProperty("$browser")]
        public VerificationSendBrowser Browser { get; set; }
    }

    public class VerificationSendBrowser
    {
        [JsonProperty("$user_agent", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAgent { get; set; }
    }
}
