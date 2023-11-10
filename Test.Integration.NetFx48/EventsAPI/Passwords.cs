using Sift;
using System.Collections.ObjectModel;
using Test.Integration.NetFx48.Uitlities;
using Xunit;

namespace Test.Integration.NetFx48.EventsAPI
{
    public class Passwords
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();
        private readonly string ApiKey;
        private readonly string UserId;
        private readonly string SessionId;
        private readonly string UserEmail;
        public Passwords()
        {
            ApiKey = environmentVariable.ApiKey;
            UserId = environmentVariable.user_id;
            SessionId = environmentVariable.session_id;
            UserEmail = environmentVariable.user_email;
        }
        [Fact]
        public void UpdatePassword()
        {
            var sift = new Client(ApiKey);
            var updatePassword = new UpdatePassword
            {
                user_id = UserId,
                session_id = SessionId,
                status = "$success",
                reason = "$forced_reset",
                ip = "128.148.1.135",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US",
                user_email = UserEmail,
                verification_phone_number = "+123456789012"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = updatePassword
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
            Assert.Equal("0", res.Status.ToString());
        }
    }
}
