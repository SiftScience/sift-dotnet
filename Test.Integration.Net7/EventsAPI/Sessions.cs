using Sift;
using System;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.EventsAPI
{
    public class Sessions
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string UserId;
        private readonly string SessionId;
        public Sessions()
        {
            ApiKey = environmentVariable.ApiKey;
            UserId = environmentVariable.user_id;
            SessionId = environmentVariable.session_id;
        }
        [Fact]
        public void LinkSessionToUserTest()
        {
            Console.WriteLine("Sessions - LinkSessionToUserTest - start");
            var sift = new Client(ApiKey);
            var linkSessionToUser = new LinkSessionToUser
            {
                user_id = UserId,
                session_id = SessionId
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = linkSessionToUser
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("0", res.Status.ToString());
            Console.WriteLine("Sessions - LinkSessionToUserTest - end");
        }
    }
}
