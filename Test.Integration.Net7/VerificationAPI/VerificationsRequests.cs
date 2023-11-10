using Sift;
using System;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.VerificationAPI
{
    public class VerificationRequests
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string UserId;
        private readonly string SendTo;
        public VerificationRequests()
        {
            ApiKey = environmentVariable.ApiKey;
            UserId = environmentVariable.UserId;
            SendTo = environmentVariable.SendTo;
        }

        [Fact]
        public void VerificationSend()
        {
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
            Assert.Equal("OK", verificationSendResponse.ErrorMessage);
        }

        [Fact]
        public void VerificationReSend()
        {
            var sift = new Client(ApiKey + ":");
            var sessionId = "SOME_SESSION_ID";
            VerificationSendRequest verificationSendRequest = new VerificationSendRequest
            {
                UserId = UserId,
                SendTo = SendTo,
                VerificationType = "$email",
                BrandName = "MyTopBrand",
                Language = "en",
                Event = new VerificationSendEvent()
                {
                    SessionId = sessionId,
                    VerifiedEvent = "$login",
                    VerifiedEntityId = sessionId,
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
            Assert.Equal("OK", verificationSendResponse.ErrorMessage);

            VerificationReSendRequest verificationReSendRequest = new VerificationReSendRequest
            {
                UserId = UserId,
                VerifiedEvent = "$login",
                VerifiedEntityId = sessionId
            };
            VerificationReSendResponse verificationReSendResponse = sift.SendAsync(verificationReSendRequest).Result;
            Assert.Equal("OK", verificationReSendResponse.ErrorMessage);
        }

        [Theory]
        [InlineData(990941)]
        public void VerificationCheck(int code)
        {
            var sift = new Client(ApiKey + ":");
            VerificationCheckRequest verificationCheckRequest = new VerificationCheckRequest
            {
                UserId = UserId,
                Code = code,
                VerifiedEvent = "$login"
            };
            VerificationCheckResponse verificationCheckResponse = sift.SendAsync(verificationCheckRequest).Result;
            Assert.Equal("OK", verificationCheckResponse.ErrorMessage);
        }
    }
}
