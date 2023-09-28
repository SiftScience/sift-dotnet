using Sift;
using System.Collections.ObjectModel;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.EventsAPI
{
    public class LoginLogout
    {
        private readonly EnvironmentVariable environmentVariable = new();
        [Fact]
        public void IntegrationTest_Login()
        {
            var sift = new Client(environmentVariable.ApiKey);
            var login = new Login
            {
                user_id = environmentVariable.user_id,
                session_id = environmentVariable.session_id,
                login_status = "$success",
                user_email = environmentVariable.user_email,
                verification_phone_number = "+123456789012",
                ip = "128.148.1.135",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                username = environmentVariable.username,
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
            var sift = new Client(environmentVariable.ApiKey);
            var logout = new Logout
            {
                user_id = environmentVariable.user_id,
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
            var sift = new Client(environmentVariable.ApiKey);
            var login = new Login
            {
                user_id = environmentVariable.user_id,
                session_id = environmentVariable.session_id,
                login_status = "$success",
                user_email = environmentVariable.user_email,
                verification_phone_number = "+123456789012",
                ip = "128.148.1.135",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                username = environmentVariable.username,
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
