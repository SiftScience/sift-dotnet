﻿using Newtonsoft.Json;
using System.Collections.Generic;


namespace Sift
{
    public class GetMerchantsResponse : SiftResponse
    {
        [JsonProperty("data")]
        public List<MerchantJson> Merchants { get; set; }

        public class MerchantJson
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("created_at")]
            public long CreatedAt { get; set; }

            [JsonProperty("created_by")]
            public long CreatedBy { get; set; }

            [JsonProperty("last_updated_at")]
            public long UpdatedAt { get; set; }

            [JsonProperty("last_updated_by")]
            public string UpdatedBy { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("address")]
            public MerchantAddressJson Address { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("service_level")]
            public string ServiceLevel { get; set; }

            [JsonProperty("status")]
            public bool Status { get; set; }

            [JsonProperty("risk_profile")]
            public MerchantRiskProfile RiskProfile { get; set; }

            [JsonProperty("has_more")]
            public bool HasMore { get; set; }

            [JsonProperty("next_ref")]
            public string NextRef { get; set; }

        }

        public class MerchantAddressJson
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("address_1")]
            public string Address1 { get; set; }

            [JsonProperty("address_2")]
            public string Address2 { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("zipcode")]
            public string ZipCode { get; set; }

            [JsonProperty("phone")]
            public string Phone { get; set; }
        }

        public class MerchantRiskProfile
        {
            [JsonProperty("level")]
            public string Level { get; set; }

            [JsonProperty("score")]
            public int Score { get; set; }
        }
    }

    public class GetMerchantDetailsResponse : SiftResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("created_by")]
        public long CreatedBy { get; set; }

        [JsonProperty("last_updated_at")]
        public long UpdatedAt { get; set; }

        [JsonProperty("last_updated_by")]
        public string UpdatedBy { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("address")]
        public MerchantAddressJson Address { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("service_level")]
        public string ServiceLevel { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("risk_profile")]
        public MerchantRiskProfile RiskProfile { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("next_ref")]
        public string NextRef { get; set; }

        public class MerchantAddressJson
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("address_1")]
            public string Address1 { get; set; }

            [JsonProperty("address_2")]
            public string Address2 { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("zipcode")]
            public string ZipCode { get; set; }

            [JsonProperty("phone")]
            public string Phone { get; set; }
        }

        public class MerchantRiskProfile
        {
            [JsonProperty("level")]
            public string Level { get; set; }

            [JsonProperty("score")]
            public int Score { get; set; }
        }
    }
}
