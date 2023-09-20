using Sift;
using Test.Integration.NetFx48.Uitlities;
using Xunit;

namespace Test.Integration.NetFx48.EventsAPI
{
    public class Flags
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();
        [Fact]
        public void IntegrationTest_FlagContent()
        {
            var sift = new Client(environmentVariable.ApiKey);
            var flagContent = new FlagContent
            {
                user_id = environmentVariable.user_id,
                session_id = environmentVariable.session_id,
                content_id = environmentVariable.content_id,
                flagged_by = environmentVariable.flagged_by,
                reason = "$toxic",
                verification_phone_number = "+123456789012"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = flagContent
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
            Assert.Equal("0", res.Status.ToString());
        }
    }
}
