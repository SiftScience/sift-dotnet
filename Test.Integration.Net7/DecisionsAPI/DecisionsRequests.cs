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
        private readonly string OrderId;
        private readonly string SessionId;
        private readonly string ContentId;
        public DecisionsRequests()
        {
            ApiKey = environmentVariable.ApiKey;
            AccountId = environmentVariable.AccountId;
            UserId = environmentVariable.user_id;
            SessionId = environmentVariable.session_id;

            long nowMills = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            OrderId = environmentVariable.order_id + nowMills;
            ContentId = environmentVariable.content_id + nowMills;
        }

        [Fact]
        public void GetDecisionStatusRequest()
        {
            var sift = new Client(ApiKey);
            GetDecisionStatusRequest getDecisionStatusRequest = new GetDecisionStatusRequest
            {
                AccountId = AccountId,
                UserId = UserId
            };
            GetDecisionStatusResponse res = sift.SendAsync(getDecisionStatusRequest).Result;
            Assert.NotNull(res.Decisions);
        }

        [Fact]
        public void ApplyUserDecisionRequest()
        {
            var sift = new Client(ApiKey);
            string DecisionId = "integration_app_watch_account_abuse";
            ApplyDecisionRequest applyUserDecisionRequest = new ApplyUserDecisionRequest
            {
                ApiKey = ApiKey,
                DecisionId = DecisionId,
                Source = "MANUAL_REVIEW",
                Analyst = "analyst@example.com",
                Description = "compromised account reported to customer service",
                AccountId = AccountId,
                UserId = UserId
            };
            ApplyDecisionResponse res = sift.SendAsync(applyUserDecisionRequest).Result;
            Assert.Equal(DecisionId, res.Decision.Id);
            Assert.Equal(UserId, res.Entity.Id);
        }

        [Fact]
        public void ApplyOrderDecisionRequest()
        {
            var sift = new Client(ApiKey);
            string DecisionId = "block_order_payment_abuse";
            ApplyDecisionRequest applyOrderDecisionRequest = new ApplyOrderDecisionRequest
            {
                ApiKey = ApiKey,
                DecisionId = DecisionId,
                Source = "AUTOMATED_RULE",
                AccountId = AccountId,
                UserId = UserId,
                OrderId = OrderId
            };
            ApplyDecisionResponse res = sift.SendAsync(applyOrderDecisionRequest).Result;
            Assert.Equal(DecisionId, res.Decision.Id);
            Assert.Equal(OrderId, res.Entity.Id);
        }

        [Fact]
        public void ApplySessionDecisionRequest()
        {
            var sift = new Client(ApiKey);
            string DecisionId = "integration_app_watch_account_takeover";
            ApplyDecisionRequest applySessionDecisionRequest = new ApplySessionDecisionRequest
            {
                ApiKey = ApiKey,
                DecisionId = DecisionId,
                Source = "AUTOMATED_RULE",
                Analyst = "analyst@example.com",
                AccountId = AccountId,
                UserId = UserId,
                SessionId = SessionId
            };
            ApplyDecisionResponse res = sift.SendAsync(applySessionDecisionRequest).Result;
            Assert.Equal(DecisionId, res.Decision.Id);
        }

        [Fact]
        public void ApplyContentDecisionRequest()
        {
            var sift = new Client(ApiKey);
            string DecisionId = "integration_app_watch_content_abuse";
            ApplyDecisionRequest applyContentDecisionRequest = new ApplyContentDecisionRequest
            {
                ApiKey = ApiKey,
                DecisionId = DecisionId,
                Source = "AUTOMATED_RULE",
                Analyst = "analyst@example.com",
                AccountId = AccountId,
                UserId = UserId,
                ContentId = ContentId
            };
            ApplyDecisionResponse res = sift.SendAsync(applyContentDecisionRequest).Result;
            Assert.Equal(DecisionId, res.Decision.Id);
            Assert.Equal(ContentId, res.Entity.Id);
        }

        [Fact]
        public void GetDecisionsRequest()
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
            Assert.True(res.Decisions.Count > 0);
        }
    }
}
