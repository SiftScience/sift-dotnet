using Sift;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.EventsAPI
{
    public class Passwords
    {
        private readonly EnvironmentVariable environmentVariable = new();
        [Fact]
        public void UpdatePasswordTest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            var updatePassword = new UpdatePassword
            {
                user_id = environmentVariable.user_id,
                session_id = environmentVariable.session_id,
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
                user_email = environmentVariable.user_email,
                verification_phone_number = "+123456789012"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = updatePassword
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }
    }
}
