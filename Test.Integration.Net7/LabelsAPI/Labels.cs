using Sift;
using Test.Integration.Net7.Uitlities;
using Xunit;


namespace Test.Integration.Net7.LabelsAPI
{
    public class Labels
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string UserId;
        public Labels()
        {
            ApiKey = environmentVariable.ApiKey;
            UserId = environmentVariable.user_id;
        }

        //[Fact]
        public void LabelRequest()
        {
            var sift = new Client(ApiKey);
            LabelRequest labelRequest = new LabelRequest
            {
                UserId = UserId,
                ApiKey = ApiKey,
                IsBad = true,
                AbuseType = "payment_abuse",
                Description = "The user was testing cards repeatedly for a valid card",
                Source = "manual review",
                Analyst = "someone@your-site.com"
            };

            SiftResponse labelResponse = sift.SendAsync(labelRequest).Result;
            Assert.Equal("OK", labelResponse.ErrorMessage);
        }

        //[Fact]
        public void UnLabelRequest()
        {
            var sift = new Client(ApiKey);
            UnlabelRequest unlabelRequest = new UnlabelRequest
            {
                UserId = UserId,
                ApiKey = ApiKey,
                AbuseType = "payment_abuse"
            };

            SiftResponse labelResponse = sift.SendAsync(unlabelRequest).Result;
            Assert.Equal("OK", labelResponse.ErrorMessage ?? "OK");
        }
    }
}
