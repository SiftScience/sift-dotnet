using Sift;
using System;
using Test.Integration.NetFx48.Uitlities;
using Xunit;

namespace Test.Integration.NetFx48.PSPMerchantManagementAPI
{
    public class MerchantRequests
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();
        private readonly string ApiKey;
        private readonly string AccountId;
        private readonly string MerchantId;
        private readonly string Id;
        public MerchantRequests()
        {
            ApiKey = environmentVariable.ApiKey;
            AccountId = environmentVariable.AccountId;
            MerchantId = environmentVariable.MerchantId;
            Id = environmentVariable.Id;
        }
        [Fact]
        public void GetMerchantRequest()
        {
            var sift = new Client(ApiKey);
            GetMerchantsRequest getMerchantRequest = new GetMerchantsRequest
            {
                AccountId = AccountId,
                BatchSize = 10,
                BatchToken = null,
            };
            GetMerchantsResponse getMerchantResponse = sift.SendAsync(getMerchantRequest).Result;
            Assert.Equal("OK", getMerchantResponse.ErrorMessage ?? "OK");
        }

        [Fact]
        public void UpdateMerchantRequest()
        {
            var sift = new Client(ApiKey);
            UpdateMerchantRequest updateMerchantRequest = new UpdateMerchantRequest
            {
                AccountId = AccountId,
                MerchantId = MerchantId,
                Name = "Watson and Holmes",
                Id = Id,
                ApiKey = ApiKey,
                Description = "An example of a PSP Merchant. Illustrative.",
                Address = new MerchantAddress()
                {
                    Name = "Dr Watson",
                    Address1 = "221B, Baker street",
                    Address2 = "apt., 1",
                    City = "London",
                    Region = "London",
                    Country = "GB",
                    ZipCode = "000001",
                    Phone = "0122334455"
                },
                Category = "1002",
                ServiceLevel = "Platinum",
                Status = "active",
                RiskProfile = new MerchantRiskProfile()
                {
                    Level = "low",
                    Score = 10
                }
            };
            UpdateMerchantResponse updateMerchantResponse = sift.SendAsync(updateMerchantRequest).Result;
            Assert.Equal("OK", updateMerchantResponse.ErrorMessage ?? "OK");
        }

        [Fact]
        public void CreateMerchantRequest()
        {
            var sift = new Client(ApiKey);
            CreateMerchantRequest createMerchantRequest = new CreateMerchantRequest
            {
                AccountId = AccountId,
                Name = "Watson and Holmes",
                ApiKey = ApiKey,
                Id = Guid.NewGuid().ToString(),
                Description = "An example of a PSP Merchant. Illustrative.",
                Address = new MerchantAddress()
                {
                    Name = "Dr Watson",
                    Address1 = "221B, Baker street",
                    Address2 = "apt., 1",
                    City = "London",
                    Region = "London",
                    Country = "GB",
                    ZipCode = "000001",
                    Phone = "0122334455"
                },
                Category = "1002",
                ServiceLevel = "Platinum",
                Status = "active",
                RiskProfile = new MerchantRiskProfile()
                {
                    Level = "low",
                    Score = 10
                }
            };
            CreateMerchantResponse createMerchantResponse = sift.SendAsync(createMerchantRequest).Result;
            Assert.Equal("OK", createMerchantResponse.ErrorMessage ?? "OK");
        }

        [Fact]
        public void GetMerchantDetailsRequest()
        {
            var sift = new Client(ApiKey);
            GetMerchantDetailsRequest getMerchantDetailsRequest = new GetMerchantDetailsRequest
            {
                AccountId = AccountId,
                ApiKey = ApiKey,
                MerchantId = MerchantId
            };
            SiftResponse getMerchantDetailsResponse = sift.SendAsync(getMerchantDetailsRequest).Result;
            Assert.Equal("OK", getMerchantDetailsResponse.ErrorMessage ?? "OK");
        }

    }
}
