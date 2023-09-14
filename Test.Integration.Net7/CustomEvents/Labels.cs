using Sift;
using Xunit;


namespace Test.Integration.Net7.CustomEvents
{
    public class Labels
    {
        [Fact]
        public void IntegrationTest_LabelRequest()
        {
            var sift = new Client("ccd68efbe25809bc");
            LabelRequest labelRequest = new LabelRequest
            {
                UserId = "haneeshv@exalture.com",
                ApiKey = "ccd68efbe25809bc",
                IsBad = true,
                AbuseType = "payment_abuse",
                Description = "The user was testing cards repeatedly for a valid card",
                Source = "manual review",
                Analyst = "someone@your-site.com"
            };

            SiftResponse labelResponse = sift.SendAsync(labelRequest).Result;
            Assert.Equal("OK", labelResponse.ErrorMessage);
        }

        [Fact]
        public void IntegrationTest_UnLabelRequest()
        {
            var sift = new Client("ccd68efbe25809bc");
            UnlabelRequest unlabelRequest = new UnlabelRequest
            {
                UserId = "haneeshv@exalture.com",
                ApiKey = "ccd68efbe25809bc",
                AbuseType = "payment_abuse"
            };

            SiftResponse labelResponse = sift.SendAsync(unlabelRequest).Result;
            Assert.Equal("OK", labelResponse.ErrorMessage);
        }

    }
}
