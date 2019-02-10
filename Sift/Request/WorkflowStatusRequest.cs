using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Sift
{
    public class WorkflowStatusRequest : SiftRequest
    {
        static readonly String WORKFLOW_STATUS_URL = @"https://api.sift.com/v3/accounts/{0}/workflows/runs/{1}";

        public string AccountId { get; set; }
        public string WorkflowRunId { get; set; }

        public override HttpRequestMessage Request
        {
            get
            {
                var request = new HttpRequestMessage(HttpMethod.Get, URL);
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.Default.GetBytes(ApiKey)));
                return request;
            }
        }

        protected override Uri URL
        {
            get
            {
                return new Uri(String.Format(WORKFLOW_STATUS_URL, AccountId, WorkflowRunId));
            }
        }
    }
}