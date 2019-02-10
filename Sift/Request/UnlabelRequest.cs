using System;
using System.Net.Http;

namespace Sift
{
    public class UnlabelRequest : SiftRequest
    {
        static readonly String UNLABEL_URL = @"https://api.sift.com/v205/users/{0}/labels?api_key={1}";

        public string UserId { get; set; }
        public string AbuseType { get; set; }

        public override HttpRequestMessage Request
        {
            get
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, URL);
                return request;
            }
        }

        protected override Uri URL
        {
            get
            {
                var url = new Uri(String.Format(UNLABEL_URL, UserId, ApiKey));

                if (!String.IsNullOrEmpty(AbuseType))
                {
                    url = url.AddQuery("abuse_type", AbuseType);
                }

                return url;
            }
        }
    }
}