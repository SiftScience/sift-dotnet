using Sift;
using Test.Integration.NetFx48.Uitlities;
using Xunit;

namespace Test.Integration.NetFx48.EventsAPI
{
    public class Verifications
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();
        private readonly string ApiKey;
        private readonly string SessionId;
        private readonly string UserId;
        public Verifications()
        {
            ApiKey = environmentVariable.ApiKey;
            SessionId = environmentVariable.session_id;
            UserId = environmentVariable.user_id;
        }
        [Fact]
        public void VerificationTest()
        {
            var sift = new Client(ApiKey);
            var sessionId = "sessionId";
            var verification = new Verification
            {
                user_id = UserId,
                session_id = SessionId,
                status = "$pending",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                verified_event = "$login",
                verified_entity_id = sessionId,
                verification_type = "$sms",
                verified_value = "14155551212",
                reason = "$user_setting",
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = verification
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
            Assert.Equal("0", res.Status.ToString());
        }
    }
}
