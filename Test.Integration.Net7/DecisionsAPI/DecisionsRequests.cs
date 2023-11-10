using Sift;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.DecisionsAPI
{
    public class DecisionsRequests
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string AccountId;
        private readonly string UserId;
        public DecisionsRequests()
        {
            ApiKey = environmentVariable.ApiKey;
            AccountId = environmentVariable.AccountId;
            UserId = environmentVariable.user_id;
        }

        //[Fact]
        public void GetDecisionStatusRequest()
        {
            var sift = new Client(ApiKey);
            GetDecisionStatusRequest getDecisionStatusRequest = new GetDecisionStatusRequest
            {
                AccountId = AccountId,
                UserId = UserId
            };
            GetDecisionStatusResponse res = sift.SendAsync(getDecisionStatusRequest).Result;
            Assert.Equal("OK", res.ErrorMessage ?? "OK");
        }

        //[Fact]
        public void ApplyDecisionRequest()
        {
            var sift = new Client(ApiKey);
            ApplyDecisionRequest applyDecisionRequest = new ApplyDecisionRequest
            {
                ApiKey = ApiKey,
                DecisionId = "block_user_payment_abuse",
                Source = "MANUAL_REVIEW",
                Analyst = "analyst@example.com",
                Time = 1231234123,
                Description = "compromised account reported to customer service",
                AccountId = AccountId,
                UserId = UserId
            };
            ApplyDecisionResponse res = sift.SendAsync(applyDecisionRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }

        //[Fact]
        public void GetDecisionRequest()
        {
            var sift = new Client(ApiKey);
            GetDecisionsRequest getDecisionsRequest = new GetDecisionsRequest
            {
                ApiKey = ApiKey,
                AccountId = AccountId,
                EntityType = "user",
                Limit = 10,
                From = 0
            };
            GetDecisionsResponse res = sift.SendAsync(getDecisionsRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }

    }
}
