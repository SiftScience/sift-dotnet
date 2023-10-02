using Sift;
using System.Collections.Generic;
using Test.Integration.NetFx48.Uitlities;
using Xunit;

namespace Test.Integration.NetFx48.ScoreAPI
{
    public class VerificationsRequests
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();
        [Fact]
        public void IntegrationTest_GetScoreRequest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            ScoreRequest scoreRequest = new ScoreRequest
            {                
                UserId = environmentVariable.UserId,
                AbuseTypes = new List<string>() { "payment_abuse" }
            };

            ScoreResponse res = sift.SendAsync(scoreRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }
        
        //[Fact]
        public void IntegrationTest_ReScoreRequest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            RescoreRequest rescoreRequest = new RescoreRequest
            {
                UserId = environmentVariable.UserId,
                AbuseTypes = new List<string>() { "payment_abuse", "promotion_abuse" }
            };

            ScoreResponse res = sift.SendAsync(rescoreRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }
    }
}
