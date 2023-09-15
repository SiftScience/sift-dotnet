using Sift;
using System.Collections.ObjectModel;
using Xunit;

namespace EventsAPI
{
    public class Flags
    {
        [Fact]
        public void IntegrationTest_FlagContent()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var flagContent = new FlagContent
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                content_id = "9671500641",
                flagged_by = "jamieli89",
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
