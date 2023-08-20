using Sift;
using System.Collections.ObjectModel;
using Xunit;

namespace Test
{
    public class Logging
    {
        [Fact]
        public void IntegrationTest_Login()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var login = new Login
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                login_status = "$success",
                user_email = "billjones1@example.com",
                verification_phone_number = "+123456789012",
                ip = "128.148.1.135",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                username = "billjones1@example.com",
                social_sign_on_type = "$linkedin",
                account_types = new ObservableCollection<string>() { "merchant", "premium" },
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = login
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }

        [Fact]
        public void IntegrationTest_Logout()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var logout = new Logout
            {
                user_id = "billy_jones_301",                
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
                Event = logout
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }


        [Fact]
        public void IntegrationTest_Login_Response()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var login = new Login
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                login_status = "$success",
                user_email = "billjones1@example.com",
                verification_phone_number = "+123456789012",
                ip = "128.148.1.135",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                username = "billjones1@example.com",
                social_sign_on_type = "$linkedin",
                account_types = new ObservableCollection<string>() { "merchant", "premium" },
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US"
            };
            EventRequest eventRequest = new()
            {
                Event = login
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("0", res.Status.ToString());
        }
    }
}
