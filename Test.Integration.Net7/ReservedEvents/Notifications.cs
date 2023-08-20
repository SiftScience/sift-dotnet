using Sift;
using Xunit;

namespace Test.Integration.Net7.ReservedEvents
{
    public class Notifications
    {
        [Fact]
        public void IntegrationTest_SecurityNotification()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var securityNotification = new SecurityNotification
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                notification_type = "$email",
                notified_value = "billy123@domain.com",
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
