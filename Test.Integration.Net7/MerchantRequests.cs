using Sift;
using System;
using Xunit;

namespace Test.Integration.Net7.CustomEvents
{
    public class MerchantRequests
    {
        [Fact]
        public void IntegrationTest_GetMerchantsRequest()
        {
            var sift = new Client("ccd68efbe25809bc:");
            GetMerchantsRequest getMerchantRequest = new GetMerchantsRequest
            {
                AccountId = "cf51f0ec-6078-46e9-a796-700af25e668c",
                ApiKey = "ccd68efbe25809bc",
                BatchSize = 10,
                BatchToken = null                               
            };
            GetMerchantsResponse getMerchantResponse = sift.SendAsync(getMerchantRequest).Result;
            Assert.Equal("OK", getMerchantResponse.ErrorMessage);
        }
    }
}
