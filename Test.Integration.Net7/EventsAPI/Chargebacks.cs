using Sift;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.EventsAPI
{
    public class Chargebacks
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string UserId;
        private readonly string OrderId;
        private readonly string TransactionId;
        private readonly string MerchantId;
        public Chargebacks()
        {
            ApiKey = environmentVariable.ApiKey;
            UserId = environmentVariable.user_id;
            OrderId = environmentVariable.order_id;
            TransactionId = environmentVariable.transaction_id;
            MerchantId = environmentVariable.merchant_id;
        }
        [Fact]
        public void ChargebackTest()
        {
            var sift = new Client(ApiKey);
            var chargeback = new Chargeback
            {
                user_id = UserId,
                order_id = OrderId,
                transaction_id = TransactionId,
                chargeback_state = "$lost",
                chargeback_reason = "$duplicate",
                merchant_profile = new MerchantProfile()
                {
                    merchant_id = MerchantId,
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
            Assert.Equal("0", res.Status.ToString());
        }
    }
}
