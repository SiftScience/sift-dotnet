using Sift;
using System.Collections.Generic;
using System;
using Xunit;

namespace Test.Integration.Net7.CustomEvents
{
    public class Scores
    {
        [Fact]
        public void IntegrationTest_GetScoreRequest()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            //var scoreResponse = new ScoreResponse
            //{
            //    decision_id = "session_looks_fraud_account_takeover",
            //    source = "MANUAL_REVIEW",

            //};

            ScoreRequest scoreRequest = new()
            {
                ApiKey = "ccd68efbe25809bc",
                AbuseTypes = new List<string> { "payment_abuse", "promotion_abuse" },
                UserId = "haneeshv@exalture.com",
            };
            ScoreResponse res = sift.SendAsync(scoreRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }

















        [Fact]
        public void TestGetScoreRequest()
        {
            var sift = new Client("ccd68efbe25809bc");
            ScoreRequest scoreRequest = new ScoreRequest
            {
                UserId = "haneeshv@exalture.com",
                //ApiKey = "345",
                AbuseTypes = new List<string>() { "payment_abuse", "promotion_abuse" }
            };


            ScoreResponse res = sift.SendAsync(scoreRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }

    }
}
