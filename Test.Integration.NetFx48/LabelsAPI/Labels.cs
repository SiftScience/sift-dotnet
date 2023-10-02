using Sift;
using Test.Integration.NetFx48.Uitlities;
using Xunit;


namespace Test.Integration.NetFx48.LabelsAPI
{
    public class Labels
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();
        //[Fact]
        public void IntegrationTest_LabelRequest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            LabelRequest labelRequest = new LabelRequest
            {
                UserId = environmentVariable.UserId,
                ApiKey = environmentVariable.ApiKey,
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
        public void IntegrationTest_UnLabelRequest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            UnlabelRequest unlabelRequest = new UnlabelRequest
            {
                UserId = environmentVariable.UserId,
                ApiKey = environmentVariable.ApiKey,
                AbuseType = "payment_abuse"
            };

            SiftResponse labelResponse = sift.SendAsync(unlabelRequest).Result;
            Assert.Equal("OK", labelResponse.ErrorMessage ?? "OK");
        }

    }
}
