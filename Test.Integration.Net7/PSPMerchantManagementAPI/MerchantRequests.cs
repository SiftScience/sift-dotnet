using Sift;
using System;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.PSPMerchantManagementAPI
{
    public class MerchantRequests
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string AccountId;
        private readonly string MerchantId;
        private readonly string Id;
        public MerchantRequests()
        {
            ApiKey = environmentVariable.ApiKey;
            AccountId = environmentVariable.AccountId;

            long nowMills = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            MerchantId = environmentVariable.MerchantId + nowMills;
        }

        [Fact]
        public void GetMerchantRequest()
        {
            Console.WriteLine("Merchants - first");
            var sift = new Client(ApiKey);
            GetMerchantsRequest getMerchantRequest = new GetMerchantsRequest
            {
                AccountId = AccountId,
                ApiKey = ApiKey,
                BatchSize = 10,
                BatchToken = null,
            };
            GetMerchantsResponse resp = sift.SendAsync(getMerchantRequest).Result;
            Assert.True(resp.Merchants.Count > 0);
        }

        [Fact]
        public void MerchantOperationsTest()
        {
            Console.WriteLine("Merchants - second");
            var sift = new Client(ApiKey);
            CreateMerchantResponse createMerchantResponse = CreateMerchant(sift);
            Assert.Equal("active", createMerchantResponse.Status);
            Assert.Equal(MerchantId, createMerchantResponse.Id);

            UpdateMerchantResponse updateMerchantResponse = UpdateMerchant(sift);
            Assert.Equal(MerchantId, updateMerchantResponse.Id);
            Assert.Equal("Watson and Holmes updated", updateMerchantResponse.Name);

            GetMerchantDetailsResponse getMerchantDetailsResponse = MerchantDetails(sift);
            Assert.Equal(MerchantId, getMerchantDetailsResponse.Id);
            Assert.Equal("Watson and Holmes updated", getMerchantDetailsResponse.Name);
        }

        private CreateMerchantResponse CreateMerchant(Client sift)
        {
            CreateMerchantRequest createMerchantRequest = new CreateMerchantRequest
            {
                AccountId = AccountId,
                Name = "Watson and Holmes - 111",
                ApiKey = ApiKey,
                Id = MerchantId,
                Description = "Create Merchant Test (sift-dotnet)",
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
            return createMerchantResponse;
        }

        private UpdateMerchantResponse UpdateMerchant(Client sift)
        {
            UpdateMerchantRequest updateMerchantRequest = new UpdateMerchantRequest
            {
                AccountId = AccountId,
                MerchantId = MerchantId,
                Name = "Watson and Holmes updated",
                Id = MerchantId,
                ApiKey = ApiKey,
                Description = "Update Merchant Test (sift-dotnet)",
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
            return updateMerchantResponse;
        }

        private GetMerchantDetailsResponse MerchantDetails(Client sift)
        {
            GetMerchantDetailsRequest getMerchantDetailsRequest = new GetMerchantDetailsRequest
            {
                AccountId = AccountId,
                ApiKey = ApiKey,
                MerchantId = MerchantId
            };
            GetMerchantDetailsResponse getMerchantDetailsResponse = sift.SendAsync(getMerchantDetailsRequest).Result;
            return getMerchantDetailsResponse;
        }
    }
}
