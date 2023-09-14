using Sift;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace Test.Integration.Net7.CustomEvents
{
    public class DecisionsRequests
    {
        [Fact]
        public void IntegrationTest_GetDecisionStatusRequest()
        {
            var sift = new Client("ccd68efbe25809bc");
            GetDecisionStatusRequest getDecisionStatusRequest = new GetDecisionStatusRequest
            {
                AccountId = "5f053f004025ca08a187fad3",
                UserId = "haneeshv@exalture.com"
            };
            GetDecisionStatusResponse res = sift.SendAsync(getDecisionStatusRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }

        [Fact]
        public void IntegrationTest_ApplyDecisionRequest()
        {
            var sift = new Client("ccd68efbe25809bc");
            ApplyDecisionRequest applyDecisionRequest = new ApplyDecisionRequest
            {
                ApiKey = "ccd68efbe25809bc",
                DecisionId = "block_user_payment_abuse",
                Source = "MANUAL_REVIEW",
                Analyst = "analyst@example.com",
                Time = 1231234123,
                Description = "compromised account reported to customer service",
                AccountId = "5f053f004025ca08a187fad3",
                UserId = "haneeshv@exalture.com"
            };
            ApplyDecisionResponse res = sift.SendAsync(applyDecisionRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }

        [Fact]
        public void IntegrationTest_GetDecisionRequest()
        {
            var sift = new Client("ccd68efbe25809bc");
            GetDecisionsRequest getDecisionsRequest = new GetDecisionsRequest
            {
                ApiKey = "ccd68efbe25809bc",
                AccountId = "5f053f004025ca08a187fad3",
                EntityType = "user",
                Limit = 10,
                From = 0
            };
            GetDecisionsResponse res = sift.SendAsync(getDecisionsRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }

    }
}
