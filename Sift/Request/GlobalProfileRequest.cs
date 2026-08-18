using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Sift
{
    public class GlobalProfileRequest : SiftRequest
    {
        static readonly String GlobalProfileUrl = @"https://api.sift.com/v3/accounts/{0}/global_profile/users/{1}";

        public string AccountId { get; set; }
        public string UserId { get; set; }
        public bool? GlobalOnly { get; set; }
        public bool? IncludeOwnData { get; set; }

        public override HttpRequestMessage Request
        {
            get
            {
                var request = new HttpRequestMessage(HttpMethod.Get, Url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.Default.GetBytes(ApiKey)));
                return request;
            }
        }

        protected override Uri Url
        {
            get
            {
                var url = new Uri(String.Format(GlobalProfileUrl,
                                                Uri.EscapeDataString(AccountId),
                                                Uri.EscapeDataString(UserId)));

                if (GlobalOnly.HasValue)
                {
                    url = url.AddQuery("global_only", GlobalOnly.Value.ToString().ToLowerInvariant());
                }

                if (IncludeOwnData.HasValue)
                {
                    url = url.AddQuery("include_own_data", IncludeOwnData.Value.ToString().ToLowerInvariant());
                }

                return url;
            }
        }
    }

    public class GlobalProfileLookupRequest : SiftRequest
    {
        static readonly String GlobalProfileLookupUrl = @"https://api.sift.com/v3/accounts/{0}/global_profile/lookup";

        [JsonIgnore]
        public string AccountId { get; set; }

        [JsonIgnore]
        public override string ApiKey { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonIgnore]
        public override HttpRequestMessage Request
        {
            get
            {
                if (String.IsNullOrEmpty(Email) && String.IsNullOrEmpty(Phone))
                {
                    throw new MissingFieldException("At least one of Email or Phone is required.");
                }

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
                return new Uri(String.Format(GlobalProfileLookupUrl,
                                             Uri.EscapeDataString(AccountId)));
            }
        }
    }
}
