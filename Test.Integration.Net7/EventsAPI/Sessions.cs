using Sift;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.EventsAPI
{
    public class Sessions
    {
        private readonly EnvironmentVariable environmentVariable = new();
        [Fact]
        public void IntegrationTest_LinkSessionToUser()
        {
            var sift = new Client(environmentVariable.ApiKey);
            var linkSessionToUser = new LinkSessionToUser
            {
                user_id = environmentVariable.user_id,
                session_id = environmentVariable.session_id
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = linkSessionToUser
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }
    }
}
