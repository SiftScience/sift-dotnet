using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Sift
{
    public class GetDecisionsRequest : SiftRequest
    {
        static readonly String GetDecisionsUrl = @"https://api.sift.com/v3/accounts/{0}/decisions";

        public string AccountId { get; set; }
        public List<String> AbuseTypes { get; set; } = new List<string>();
        public string EntityType { get; set; }
        public long? Limit { get; set; }
        public long? From { get; set; }

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
                var url = new Uri(String.Format(GetDecisionsUrl,
                                                WebUtility.EscapedDataString(AccountId)));

                if (AbuseTypes.Count > 0)
                {
                    url = url.AddQuery("abuse_types", string.Join(",", AbuseTypes));
                }

                if (!String.IsNullOrEmpty(EntityType))
                {
                    url = url.AddQuery("entity_type", EntityType);
                }

                if (Limit.HasValue)
                {
                    url = url.AddQuery("limit", Limit.Value.ToString());
                }

                if (From.HasValue)
                {
                    url = url.AddQuery("from", From.Value.ToString());
                }

                return url;
            }
        }
    }
}