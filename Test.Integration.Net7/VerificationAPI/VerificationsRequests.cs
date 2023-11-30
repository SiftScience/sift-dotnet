using Sift;
using System;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.VerificationAPI
{
    public class VerificationsRequests
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string UserId;
        private readonly string SendTo;
        public VerificationsRequests()
        {
            ApiKey = environmentVariable.ApiKey;
            UserId = environmentVariable.UserId;
            SendTo = environmentVariable.SendTo;
        }

        [Fact]
        public void VerificationSend()
        {
            Console.WriteLine("VerificationRequests - VerificationSend - start");
            var sift = new Client(ApiKey + ":");
            VerificationSendRequest verificationSendRequest = new VerificationSendRequest
            {
                UserId = UserId,
                SendTo = SendTo,
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
            VerificationSendResponse verificationSendResponse = sift.SendAsync(verificationSendRequest).Result;
            Assert.Equal(0, verificationSendResponse.Status);
            Console.WriteLine("VerificationRequests - VerificationSend - end");
        }

        [Fact]
        public void VerificationCheck()
        {
            Console.WriteLine("VerificationRequests - VerificationCheck - start");
            var sift = new Client(ApiKey + ":");
            VerificationCheckRequest verificationCheckRequest = new VerificationCheckRequest
            {
                UserId = UserId,
                Code = 1, // incorrect code, we expect an exception
                VerifiedEvent = "$login"
            };
            try
            {
                var resp = sift.SendAsync(verificationCheckRequest).Result;
                Assert.True(false);
            }
            catch (Exception exception)
            {
            }
            finally
            {
                Console.WriteLine("VerificationRequests - VerificationCheck - end");
            }
        }
    }
}
