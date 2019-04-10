using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Sift
{
    public class ScoreRequest : SiftRequest
    {
        static readonly String ScoreUrl = @"https://api.sift.com/v205/users/{0}/score?api_key={1}";

        public string UserId { get; set; }
        public List<String> AbuseTypes { get; set; } = new List<string>();

        public override HttpRequestMessage Request {
            get
            {
                return new HttpRequestMessage(HttpMethod.Get, Url);
            }
        }

        protected override Uri Url
        {
            get
            {
                var url = new Uri(String.Format(ScoreUrl,
                                                Uri.EscapeDataString(UserId),
                                                Uri.EscapeDataString(ApiKey)));

                if (AbuseTypes.Count > 0)
                {
                    url = url.AddQuery("abuse_types", string.Join(",", AbuseTypes));
                }

                return url;
            }
        }
    }

    public class RescoreRequest : ScoreRequest
    {
        public override HttpRequestMessage Request
        {
            get
            {
                return new HttpRequestMessage(HttpMethod.Post, Url);
            }
        }
    }
}