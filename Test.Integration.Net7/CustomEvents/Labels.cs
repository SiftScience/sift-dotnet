using Sift;
using System.Collections.Generic;
using System;
using Xunit;

namespace Test.Integration.Net7.CustomEvents
{
    public class LabelRequest
    {
        [Fact]
        public void IntegrationTest_LabelRequest()
        {
            var sift = new Client("ccd68efbe25809bc");
            LabelRequest labelRequest = new LabelRequest
            {
                ApiKey = "ccd68efbe25809bc",                
                UserId = "haneeshv@exalture.com",
                AbuseTypes = new List<string>() { "payment_abuse", "promotion_abuse" }
            };

            LabelRequest labelrequestResponse = sift.SendAsync(labelResponse).Result;
            Assert.Equal("OK", labelrequestResponse.ErrorMessage);
        }
    }
}
