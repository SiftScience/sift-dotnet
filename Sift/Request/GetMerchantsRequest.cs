using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Sift
{
    public class GetMerchantsRequest : SiftRequest
    {
        static readonly String GetMerchantsUrl = @"https://api.sift.com/v3/accounts/{0}/psp_management/merchants";

        public string AccountId { get; set; }
        public string BatchToken { get; set; }
        public int? BatchSize { get; set; }


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
                var url = new Uri(String.Format(GetMerchantsUrl,
                                                Uri.EscapeDataString(AccountId)));


                if (!String.IsNullOrEmpty(BatchToken))
                {
                    url = url.AddQuery("batch_token", BatchToken);
                }

                if (BatchSize.HasValue)
                {
                    url = url.AddQuery("limit", BatchSize.Value.ToString());
                }


                return url;
            }
        }

    }

    public class GetMerchantDetailsRequest : SiftRequest
    {
        static readonly String GetMerchantsUrl = @"https://api.sift.com/v3/accounts/{0}/psp_management/merchants/{1}";

        public string AccountId { get; set; }
        public string MerchantId { get; set; }

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
                var url = new Uri(String.Format(GetMerchantsUrl,
                                                Uri.EscapeDataString(AccountId),
                                                Uri.EscapeDataString(MerchantId)));
                return url;
            }
        }

    }

}
