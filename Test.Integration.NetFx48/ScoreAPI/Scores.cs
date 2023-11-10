using Sift;
using System.Collections.Generic;
using Test.Integration.NetFx48.Uitlities;
using Xunit;

namespace Test.Integration.NetFx48.ScoreAPI
{
    public class Scores
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();
        private readonly string ApiKey;
        private readonly string UserId;
        public Scores()
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
            Assert.Equal("OK", res.ErrorMessage);
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
            Assert.Equal("OK", res.ErrorMessage);
        }
    }
}
