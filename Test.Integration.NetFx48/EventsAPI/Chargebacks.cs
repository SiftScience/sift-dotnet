using Sift;
using Test.Integration.NetFx48.Uitlities;
using Xunit;

namespace Test.Integration.NetFx48.EventsAPI
{
    public class Chargebacks
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();
        [Fact]
        public void IntegrationTest_Chargeback()
        {
            var sift = new Client(environmentVariable.ApiKey);
            var chargeback = new Chargeback
            {
                user_id = environmentVariable.user_id,
                order_id = environmentVariable.order_id,
                transaction_id = environmentVariable.transaction_id,
                chargeback_state = "$lost",
                chargeback_reason = "$duplicate",
                merchant_profile = new MerchantProfile()
                {
                    merchant_id = environmentVariable.merchant_id,
                    merchant_category_code = "1234",
                    merchant_name = "Dream Company",
                    merchant_address = new Address()
                    {
                        phone = "1-415-555-6040",
                        address_1 = "2100 Main Street",
                        address_2 = "Apt 3B",
                        city = "New London",
                        region = "New Hampshire",
                        country = "US",
                        zipcode = "03257"

                    }
                }
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = chargeback
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
            Assert.Equal("0", res.Status.ToString());
        }
    }
}
