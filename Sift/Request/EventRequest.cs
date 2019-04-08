using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Sift
{
    public class EventRequest : SiftRequest
    {
        private static readonly String EVENTS_URL = "https://api.sift.com/v205/events";

        public SiftEvent Event { get; set; }
        public List<String> AbuseTypes { get; set; } = new List<string>();
        public bool ReturnScore { get; set; }
        public bool ReturnWorkflowStatus { get; set; }
        public bool ForceWorkflowRun { get; set; }

        public override HttpRequestMessage Request
        {
            get
            {
                var request = new HttpRequestMessage(HttpMethod.Post, URL);
                Event.AddApiKey(ApiKey);
                request.Content = new StringContent(Event.ToJson(), Encoding.UTF8, "application/json");
                return request;
            }
        }

        protected override Uri URL
        {
            get
            {
                var url = new Uri(EVENTS_URL);

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

                if (ForceWorkflowRun)
                {
                    url = url.AddQuery("force_workflow_run", "true");
                }

                return url;
            }
        }
    }
}