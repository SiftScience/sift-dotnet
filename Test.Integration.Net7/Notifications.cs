using Sift;
using Xunit;

namespace Test
{
    public class Sessions
    {
        [Fact]
        public void IntegrationTest_LinkSessionToUser()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var linkSessionToUser = new LinkSessionToUser
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il"
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
