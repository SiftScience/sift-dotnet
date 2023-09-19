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
            var sift = new Client(environmentVariable.ApiKey);//configuration only
            ScoreRequest scoreRequest = new ScoreRequest
            {
                //UserId = "haneeshv@exalture.com",
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
            var sift = new Client("febabe52c8887d8b");
            RescoreRequest rescoreRequest = new RescoreRequest
            {
                UserId = "billy_jones_301",
                AbuseTypes = new List<string>() { "payment_abuse", "promotion_abuse" }
            };
            ScoreResponse res = sift.SendAsync(rescoreRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }
    }
}
