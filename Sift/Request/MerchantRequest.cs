using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Sift
{
    public class CreateMerchantRequest : SiftRequest
    {
        static readonly String CreateMerchantUrl = @"https://api.sift.com/v3/accounts/{0}/psp_management/merchants";

        [JsonIgnore]
        public string AccountId { get; set; }

        [JsonIgnore]
        public override string ApiKey { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("address")]
        public MerchantAddress Address { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        [JsonProperty("service_level", NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceLevel { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("risk_profile")]
        public MerchantRiskProfile RiskProfile { get; set; }

        [JsonIgnore]
        public override HttpRequestMessage Request
        {
            get
            {
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
                return new Uri(String.Format(CreateMerchantUrl,
                                             Uri.EscapeDataString(AccountId)));
            }
        }
    }

    public class UpdateMerchantRequest : SiftRequest
    {
        static readonly String UpdateMerchantUrl = @"https://api.sift.com/v3/accounts/{0}/psp_management/merchants/{1}";

        [JsonIgnore]
        public string AccountId { get; set; }

        [JsonIgnore]
        public string MerchantId { get; set; }

        [JsonIgnore]
        public override string ApiKey { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("address")]
        public MerchantAddress Address { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        [JsonProperty("service_level", NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceLevel { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("risk_profile")]
        public MerchantRiskProfile RiskProfile { get; set; }

        [JsonIgnore]
        public override HttpRequestMessage Request
        {
            get
            {
                var request = new HttpRequestMessage(HttpMethod.Put, Url);
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
                return new Uri(String.Format(UpdateMerchantUrl,
                                             Uri.EscapeDataString(AccountId),
                                             Uri.EscapeDataString(MerchantId)));
            }
        }
    }

    public class MerchantAddress
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("address_1", NullValueHandling = NullValueHandling.Ignore)]
        public string Address1 { get; set; }

        [JsonProperty("address_2", NullValueHandling = NullValueHandling.Ignore)]
        public string Address2 { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("zipcode", NullValueHandling = NullValueHandling.Ignore)]
        public string ZipCode { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }
    }

    public class MerchantRiskProfile
    {
        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public string Level { get; set; }

        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public int Score { get; set; }
    }
}