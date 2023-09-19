using Sift;
using System.Collections.Generic;
using System;
using Xunit;
using Test.Integration.Net7.Uitlities;

namespace Test.Integration.Net7.ScoreAPI
{
    public class VerificationsRequests
    {
        private readonly EnvironmentVariable environmentVariable = new();

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

        //remove
        [Fact]
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
