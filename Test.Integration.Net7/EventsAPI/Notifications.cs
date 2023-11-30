using Sift;
using System;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.EventsAPI
{
    public class Notifications
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string UserId;
        private readonly string SessionId;
        private readonly string NotifiedValue;
        public Notifications()
        {
            ApiKey = environmentVariable.ApiKey;
            UserId = environmentVariable.user_id;
            SessionId = environmentVariable.session_id;
            NotifiedValue = environmentVariable.notified_value;
        }
        [Fact]
        public void SecurityNotificationTest()
        {
            Console.WriteLine("Notifications - SecurityNotificationTest - start");
            var sift = new Client(ApiKey);
            var securityNotification = new SecurityNotification
            {
                user_id = UserId,
                session_id = SessionId,
                notification_type = "$email",
                notified_value = NotifiedValue,
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
            Assert.Equal("0", res.Status.ToString());
            Console.WriteLine("Notifications - SecurityNotificationTest - end");
        }
    }
}
