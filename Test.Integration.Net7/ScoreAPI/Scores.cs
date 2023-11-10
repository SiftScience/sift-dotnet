using Sift;
using System.Collections.Generic;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.ScoreAPI
{
    public class ScoresRequests
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string UserId;
        public ScoresRequests()
        {
            ApiKey = environmentVariable.ApiKey;
            UserId = environmentVariable.UserId;
        }

        [Fact]
        public void GetScoreRequest()
        {
            var sift = new Client(ApiKey);
            ScoreRequest scoreRequest = new ScoreRequest
            {
                UserId = UserId,
                AbuseTypes = new List<string>() { "payment_abuse" }
            };
            ScoreResponse res = sift.SendAsync(scoreRequest).Result;
            Assert.Equal("0", res.Status.ToString());
        }
                
        //[Fact]
        public void ReScoreRequest()
        {
            var sift = new Client(ApiKey);
            RescoreRequest rescoreRequest = new RescoreRequest
            {
                UserId = UserId,
                AbuseTypes = new List<string>() { "payment_abuse", "promotion_abuse" }
            };
            ScoreResponse res = sift.SendAsync(rescoreRequest).Result;
            Assert.Equal("0", res.Status.ToString());
        }
    }
}
