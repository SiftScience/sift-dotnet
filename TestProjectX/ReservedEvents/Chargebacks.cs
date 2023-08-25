using Sift;
using Xunit;

namespace TestProjectX.ReservedEvents
{
    public class Chargebacks
    {
        [Fact]
        public void IntegrationTest_Chargeback()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var chargeback = new Chargeback
            {
                user_id = "billy_jones_301",
                order_id = "ORDER-123124124",
                transaction_id = "719637215",
                chargeback_state = "$lost",
                chargeback_reason = "$duplicate",
                merchant_profile = new MerchantProfile()
                {
                    merchant_id = "AX527123",
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
        }
    }
}
