using Sift;
using Test.Integration.NetFx48.Uitlities;
using Xunit;

namespace Test.Integration.NetFx48.DecisionsAPI
{

    public class DecisionsRequests
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();

        //[Fact]
        public void GetDecisionStatusRequest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            GetDecisionStatusRequest getDecisionStatusRequest = new GetDecisionStatusRequest
            {
                AccountId = environmentVariable.AccountId,
                UserId = environmentVariable.UserId
            };
            GetDecisionStatusResponse res = sift.SendAsync(getDecisionStatusRequest).Result;
            Assert.Equal("OK", res.ErrorMessage ?? "OK");
        }

        //[Fact]
        public void ApplyDecisionRequest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            ApplyDecisionRequest applyDecisionRequest = new ApplyDecisionRequest
            {
                ApiKey = environmentVariable.ApiKey,
                DecisionId = "block_user_payment_abuse",
                Source = "MANUAL_REVIEW",
                Analyst = "analyst@example.com",
                Time = 1231234123,
                Description = "compromised account reported to customer service",
                AccountId = environmentVariable.AccountId,
                UserId = environmentVariable.UserId
            };
            ApplyDecisionResponse res = sift.SendAsync(applyDecisionRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }

        //[Fact]
        public void GetDecisionRequest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            GetDecisionsRequest getDecisionsRequest = new GetDecisionsRequest
            {
                ApiKey = environmentVariable.ApiKey,
                AccountId = environmentVariable.AccountId,
                EntityType = "user",
                Limit = 10,
                From = 0
            };
            GetDecisionsResponse res = sift.SendAsync(getDecisionsRequest).Result;
            Assert.Equal("OK", res.ErrorMessage ?? "OK");
        }

    }
}
