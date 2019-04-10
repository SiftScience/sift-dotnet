using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Sift
{
    public class WorkflowStatusRequest : SiftRequest
    {
        static readonly String WorkflowStatusUrl = @"https://api.sift.com/v3/accounts/{0}/workflows/runs/{1}";

        public string AccountId { get; set; }
        public string WorkflowRunId { get; set; }

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
                return new Uri(String.Format(WorkflowStatusUrl,
                                             WebUtility.UrlEncode(AccountId),
                                             WebUtility.UrlEncode(WorkflowRunId)));
            }
        }
    }
}