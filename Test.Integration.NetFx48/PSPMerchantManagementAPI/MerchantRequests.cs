using Sift;
using System;
using Test.Integration.NetFx48.Uitlities;
using Xunit;

namespace Test.Integration.NetFx48.PSPMerchantManagementAPI
{
    public class MerchantRequests
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();
        [Fact]
        public void IntegrationTest_GetMerchantRequest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            GetMerchantsRequest getMerchantRequest = new GetMerchantsRequest
            {
                AccountId = environmentVariable.AccountId,
                BatchSize = 10,
                BatchToken = null,
            };
            GetMerchantsResponse getMerchantResponse = sift.SendAsync(getMerchantRequest).Result;
            Assert.Equal("OK", getMerchantResponse.ErrorMessage ?? "OK");
        }

        [Fact]
        public void IntegrationTest_UpdateMerchantRequest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            UpdateMerchantRequest updateMerchantRequest = new UpdateMerchantRequest
            {
                AccountId = environmentVariable.AccountId,
                MerchantId = environmentVariable.MerchantId,
                Name = "Watson and Holmes",
                Id = environmentVariable.Id,
                ApiKey = environmentVariable.ApiKey,
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
        public void IntegrationTest_CreateMerchantRequest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            CreateMerchantRequest createMerchantRequest = new CreateMerchantRequest
            {
                AccountId = environmentVariable.AccountId,
                Name = "Watson and Holmes",
                ApiKey = environmentVariable.ApiKey,
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
        public void IntegrationTest_GetMerchantDetailsRequest()
        {
            var sift = new Client("ccd68efbe25809bc:");
            GetMerchantDetailsRequest getMerchantDetailsRequest = new GetMerchantDetailsRequest
            {
                AccountId = "cf51f0ec-6078-46e9-a796-700af25e668c",
                ApiKey = "ccd68efbe25809bc",
                MerchantId = "cf51f0ec-6078-46e9-a796-700af25e668c"
            };
            SiftResponse getMerchantDetailsResponse = sift.SendAsync(getMerchantDetailsRequest).Result;
            Assert.Equal("OK", getMerchantDetailsResponse.ErrorMessage);
        }

    }
}
