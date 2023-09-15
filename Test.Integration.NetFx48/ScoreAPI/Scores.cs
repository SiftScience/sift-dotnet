using Sift;
using System.Collections.Generic;
using System;
using Xunit;

namespace Test.Integration.NetFx48.ScoreAPI
{
    public class VerificationsRequests
    {
        [Fact]
        public void IntegrationTest_GetScoreRequest()
        {
            //var sift = new Client("ccd68efbe25809bc");
            var sift = new Client("febabe52c8887d8b");//configuration only
            ScoreRequest scoreRequest = new ScoreRequest
            {
                //UserId = "haneeshv@exalture.com",
                UserId = "billy_jones_301",//configuration
                //ApiKey = "345",
                AbuseTypes = new List<string>() { "payment_abuse" }
            };

            ScoreResponse res = sift.SendAsync(scoreRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }

        //remove
        [Fact]
        public void IntegrationTest_ReScoreRequest()
        {
            var sift = new Client("ccd68efbe25809bc");
            RescoreRequest rescoreRequest = new RescoreRequest
            {
                UserId = "haneeshv@exalture.com",
                //ApiKey = "345",
                AbuseTypes = new List<string>() { "payment_abuse", "promotion_abuse" }
            };

            ScoreResponse res = sift.SendAsync(rescoreRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }
    }
}
