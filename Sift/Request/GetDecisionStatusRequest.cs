using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Sift
{
    public class GetDecisionStatusRequest : SiftRequest
    {
        static readonly String GetDecisionUrl = @"https://api.sift.com/v3/accounts/{0}/users/{1}/decisions";

        [JsonIgnore]
        public string UserId { get; set; }

        [JsonIgnore]
        public string AccountId { get; set; }

        [JsonIgnore]
        public override string ApiKey { get; set; }

        [JsonIgnore]
        public override HttpRequestMessage Request
        {
            get
            {
                var request = new HttpRequestMessage(HttpMethod.Get, Url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.Default.GetBytes(ApiKey)));
                return request;
            }
        }

        [JsonIgnore]
        protected override Uri Url
        {
            get
            {
                return new Uri(String.Format(GetDecisionUrl,
                                             Uri.EscapeDataString(AccountId),
                                             Uri.EscapeDataString(UserId)));
            }
        }
    }

    public class GetUserDecisionStatusRequest : ApplyDecisionRequest
    {
    }

    public class GetOrderDecisionStatusRequest : ApplyDecisionRequest
    {
        static readonly String GetOrderDecisionUrl = @"https://api.siftscience.com/v3/accounts/{0}/orders/{1}/decisions";

        [JsonIgnore]
        public string OrderId { get; set; }

        [JsonIgnore]
        protected override Uri Url
        {
            get
            {
                return new Uri(String.Format(GetOrderDecisionUrl,
                                             Uri.EscapeDataString(AccountId),
                                             Uri.EscapeDataString(OrderId)));
            }
        }
    }

    public class GetSessionDecisionStatusRequest : ApplyDecisionRequest
    {
        static readonly String GetSessionDecisionUrl = @"https://api.siftscience.com/v3/accounts/{0}/users/{1}/sessions/{2}/decisions";

        [JsonIgnore]
        public string SessionId { get; set; }

        [JsonIgnore]
        protected override Uri Url
        {
            get
            {
                return new Uri(String.Format(GetSessionDecisionUrl,
                                             Uri.EscapeDataString(AccountId),
                                             Uri.EscapeDataString(UserId),
                                             Uri.EscapeDataString(SessionId)));
            }
        }
    }

    public class GetContentDecisionStatusRequest : ApplyDecisionRequest
    {
        static readonly String GetContentDecisionUrl = @"https://api.siftscience.com/v3/accounts/{0}/users/{1}/content/{2}/decisions";

        [JsonIgnore]
        public string ContentId { get; set; }

        [JsonIgnore]
        protected override Uri Url
        {
            get
            {
                return new Uri(String.Format(GetContentDecisionUrl,
                                             Uri.EscapeDataString(AccountId),
                                             Uri.EscapeDataString(UserId),
                                             Uri.EscapeDataString(ContentId)));
            }
        }
    }

}