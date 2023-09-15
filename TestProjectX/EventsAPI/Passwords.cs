using Sift;
using System.Collections.ObjectModel;
using Xunit;

namespace EventsAPI
{
    public class Passwords
    {
        [Fact]
        public void IntegrationTest_UpdatePassword()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var updatePassword = new UpdatePassword
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
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
                user_email = "billjones1@example.com",
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
