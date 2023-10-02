using Sift;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.EventsAPI
{
    public class Notifications
    {
        private readonly EnvironmentVariable environmentVariable = new();
        [Fact]
        public void SecurityNotificationTest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            var securityNotification = new SecurityNotification
            {
                user_id = environmentVariable.user_id,
                session_id = environmentVariable.session_id,
                notification_type = "$email",
                notified_value = environmentVariable.notified_value,
                notification_status = "$sent",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = securityNotification
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);

        }
    }
}
