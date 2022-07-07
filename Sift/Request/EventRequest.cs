using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Sift
{
    public class EventRequest : SiftRequest
    {
        static readonly String EventsUrl = "https://api.sift.com/v205/events";

        public SiftEvent Event { get; set; }
        public List<String> AbuseTypes { get; set; } = new List<string>();
        public bool ReturnScore { get; set; }
        public bool ReturnWorkflowStatus { get; set; }
        public bool ReturnRouteInfo { get; set; }
        public bool ForceWorkflowRun { get; set; }

        public override HttpRequestMessage Request
        {
            get
            {
                var request = new HttpRequestMessage(HttpMethod.Post, Url);
                Event.AddApiKey(ApiKey);
                request.Content = new StringContent(Event.ToJson(), Encoding.UTF8, "application/json");
                return request;
            }
        }

        protected override Uri Url
        {
            get
            {
                var url = new Uri(EventsUrl);

                if (AbuseTypes.Count > 0)
                {
                    url = url.AddQuery("abuse_types", string.Join(",", AbuseTypes));
                }

                if (ReturnScore)
                {
                    url = url.AddQuery("return_score", "true");
                }

                if (ReturnWorkflowStatus)
                {
                    url = url.AddQuery("return_workflow_status", "true");
                }

                if (ReturnRouteInfo)
                {
                    url = url.AddQuery("return_route_info", "true");
                }

                if (ForceWorkflowRun)
                {
                    url = url.AddQuery("force_workflow_run", "true");
                }

                return url;
            }
        }
    }
}