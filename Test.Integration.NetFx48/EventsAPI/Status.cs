using Sift;
using Test.Integration.NetFx48.Uitlities;
using Xunit;

namespace Test.Integration.NetFx48.EventsAPI
{
    public class Status
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();
        [Fact]
        public void IntegrationTest_ContentStatus()
        {
            var sift = new Client(environmentVariable.ApiKey);
            var contentStatus = new ContentStatus
            {
                user_id = environmentVariable.user_id,
                session_id = environmentVariable.session_id,
                content_id = environmentVariable.content_id,
                status = "$paused",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
                verification_phone_number = "+123456789012"
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = contentStatus
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
            Assert.Equal("0", res.Status.ToString());
        }

        [Fact]
        public void IntegrationTest_OrderStatus()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var orderStatus = new OrderStatus
            {
                user_id = "billy_jones_301",
                order_id = "ORDER-28168441",
                order_status = "$canceled",
                reason = "$payment_risk",
                source = "$manual_review",
                analyst = "someone@your-site.com",
                webhook_id = "3ff1082a4aea8d0c58e3643ddb7a5bb87ffffeb2492dca33",
                description = "Canceling because multiple fraudulent users on device",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = orderStatus
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
            Assert.Equal("0", res.Status.ToString());
        }
    }
}
