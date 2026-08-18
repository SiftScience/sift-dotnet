using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sift
{
    public class GlobalProfileResponse : SiftResponse
    {
        [JsonProperty("error_code")]
        public int? ErrorCode { get; set; }

        [JsonProperty("lookback_months")]
        public int? LookbackMonths { get; set; }

        [JsonProperty("profile_summary")]
        public ProfileSummaryJson ProfileSummary { get; set; }

        [JsonProperty("identity_age")]
        public IdentityAgeJson IdentityAge { get; set; }

        [JsonProperty("user_decisions")]
        public UserDecisionsJson UserDecisions { get; set; }

        [JsonProperty("chargebacks")]
        public ChargebacksJson Chargebacks { get; set; }

        [JsonProperty("orders")]
        public OrdersJson Orders { get; set; }

        [JsonProperty("transactions")]
        public TransactionsJson Transactions { get; set; }

        [JsonProperty("locations")]
        public LocationsJson Locations { get; set; }

        public class ProfileSummaryJson
        {
            [JsonProperty("identity_found")]
            public bool IdentityFound { get; set; }

            [JsonProperty("has_links")]
            public bool HasLinks { get; set; }

            [JsonProperty("link_count")]
            public int LinkCount { get; set; }

            [JsonProperty("linked_accounts_count_per_industry")]
            public Dictionary<string, int> LinkedAccountsCountPerIndustry { get; set; }
        }

        public class IdentityAgeJson
        {
            [JsonProperty("oldest_account_age_timestamp")]
            public long? OldestAccountAgeTimestamp { get; set; }

            [JsonProperty("newest_account_age_timestamp")]
            public long? NewestAccountAgeTimestamp { get; set; }

            [JsonProperty("average_account_age_timestamp")]
            public long? AverageAccountAgeTimestamp { get; set; }
        }

        public class UserDecisionsJson
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("blocked")]
            public int Blocked { get; set; }

            [JsonProperty("watched")]
            public int Watched { get; set; }

            [JsonProperty("accepted")]
            public int Accepted { get; set; }

            [JsonProperty("manual")]
            public int Manual { get; set; }

            [JsonProperty("auto")]
            public int Auto { get; set; }

            [JsonProperty("last_type")]
            public string LastType { get; set; }

            [JsonProperty("last_timestamp")]
            public long? LastTimestamp { get; set; }
        }

        public class ChargebacksJson
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("fraudulent")]
            public int Fraudulent { get; set; }

            [JsonProperty("other")]
            public int Other { get; set; }

            [JsonProperty("last_timestamp")]
            public long? LastTimestamp { get; set; }

            [JsonProperty("last_fraudulent_timestamp")]
            public long? LastFraudulentTimestamp { get; set; }
        }

        public class OrdersJson
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("blocked")]
            public int Blocked { get; set; }

            [JsonProperty("watched")]
            public int Watched { get; set; }

            [JsonProperty("accepted")]
            public int Accepted { get; set; }

            [JsonProperty("last_timestamp")]
            public long? LastTimestamp { get; set; }

            [JsonProperty("last_blocked_timestamp")]
            public long? LastBlockedTimestamp { get; set; }
        }

        public class TransactionsJson
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("failed_fraud")]
            public int FailedFraud { get; set; }

            [JsonProperty("failed_other")]
            public int FailedOther { get; set; }

            [JsonProperty("successful")]
            public int Successful { get; set; }

            [JsonProperty("last_timestamp")]
            public long? LastTimestamp { get; set; }

            [JsonProperty("last_failed_fraud_timestamp")]
            public long? LastFailedFraudTimestamp { get; set; }
        }

        public class LocationsJson
        {
            [JsonProperty("unique_billing_addresses")]
            public int UniqueBillingAddresses { get; set; }

            [JsonProperty("unique_shipping_addresses")]
            public int UniqueShippingAddresses { get; set; }

            [JsonProperty("distinct_countries_count")]
            public int DistinctCountriesCount { get; set; }

            [JsonProperty("distinct_regions_count")]
            public int DistinctRegionsCount { get; set; }

            [JsonProperty("location_connected_accounts")]
            public List<LocationConnectedAccountJson> LocationConnectedAccounts { get; set; }

            [JsonProperty("location_last_used_timestamp")]
            public long? LocationLastUsedTimestamp { get; set; }
        }

        public class LocationConnectedAccountJson
        {
            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }
        }
    }
}
