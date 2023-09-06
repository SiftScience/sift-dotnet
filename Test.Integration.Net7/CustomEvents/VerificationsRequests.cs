using Sift;
using System;
using Xunit;

namespace Test.Integration.Net7.CustomEvents
{
    public class VerificationRequests
    {
        [Fact]
        public void IntegrationTest_VerificationSend()
        {
            var sift = new Client("ccd68efbe25809bc:");
            VerificationSendRequest verificationSendRequest = new VerificationSendRequest
            {
                UserId = "binishb@exalture.com",
                SendTo = "binishb@exalture.com",
                VerificationType = "$email", 
                BrandName = "MyTopBrand",
                Language = "en",
                Event = new VerificationSendEvent()
                {
                    SessionId = "SOME_SESSION_ID",
                    VerifiedEvent = "$login",
                    VerifiedEntityId = "SOME_SESSION_ID",
                    Reason = "$automated_rule",
                    IP = "192.168.1.1",
                    Browser = new Browser
                    {
                        user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                        accept_language = "en-US",
                        content_language = "en-GB"
                    }
                }
            };
            try
            {
                VerificationSendResponse res = sift.SendAsync(verificationSendRequest).Result;
                Assert.Equal("OK", res.ErrorMessage);
            }
            catch (Exception ex)
            {

            }
        }



    }
}
