using Sift;
using Test.Integration.NetFx48.Uitlities;
using Xunit;

namespace Test.Integration.NetFx48.EventsAPI
{
    public class Sessions
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();
        [Fact]
        public void LinkSessionToUserTest()
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
            Assert.Equal("0", res.Status.ToString());
        }
    }
}
