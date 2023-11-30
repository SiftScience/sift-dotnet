using Sift;
using System;
using System.Collections.Generic;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.ScoreAPI
{
    public class Scores
    {
        private readonly EnvironmentVariable environmentVariable = new();
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
            Console.WriteLine("ScoresRequests - GetScoreRequest - start");
            var sift = new Client(ApiKey);
            ScoreRequest scoreRequest = new ScoreRequest
            {
                UserId = UserId,
                AbuseTypes = new List<string>() { "payment_abuse" }
            };
            ScoreResponse res = sift.SendAsync(scoreRequest).Result;
            Assert.Equal("0", res.Status.ToString());
            Console.WriteLine("ScoresRequests - GetScoreRequest - end");
        }

        [Fact]
        public void ReScoreRequest()
        {
            Console.WriteLine("ScoresRequests - ReScoreRequest - start");
            var sift = new Client(ApiKey);
            RescoreRequest rescoreRequest = new RescoreRequest
            {
                UserId = UserId,
                AbuseTypes = new List<string>() { "payment_abuse", "promotion_abuse" }
            };
            ScoreResponse res = sift.SendAsync(rescoreRequest).Result;
            Assert.Equal("0", res.Status.ToString());
            Console.WriteLine("ScoresRequests - ReScoreRequest - end");
        }
    }
}
