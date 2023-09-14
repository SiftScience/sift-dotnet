using Sift;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.Integration.Net7.CustomEvents
{
    public class DecisionsRequests
    {
        [Fact]
        public void IntegrationTest_GetDecisionStatusRequest()
        {
            var sift = new Client("ccd68efbe25809bc");
            GetDecisionStatusRequest getDecisionStatusRequest = new GetDecisionStatusRequest
            {
                AccountId = "5f053f004025ca08a187fad3",
                UserId = "haneeshv@exalture.com"
            };

            GetDecisionStatusResponse res = sift.SendAsync(getDecisionStatusRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }
    }
}
