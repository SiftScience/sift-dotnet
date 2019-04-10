using System;
using System.Net.Http;

namespace Sift
{
    public class UnlabelRequest : SiftRequest
    {
        static readonly String UnlabelUrl = @"https://api.sift.com/v205/users/{0}/labels?api_key={1}";

        public string UserId { get; set; }
        public string AbuseType { get; set; }

        public override HttpRequestMessage Request
        {
            get
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, Url);
                return request;
            }
        }

        protected override Uri Url
        {
            get
            {
                var url = new Uri(String.Format(UnlabelUrl,
                                                Uri.EscapeDataString(UserId),
                                                Uri.EscapeDataString(ApiKey)));

                if (!String.IsNullOrEmpty(AbuseType))
                {
                    url = url.AddQuery("abuse_type", AbuseType);
                }

                return url;
            }
        }
    }
}