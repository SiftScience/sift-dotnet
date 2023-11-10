using Sift;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.EventsAPI
{
    public class Transactions
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string UserId;
        private readonly string UserEmail;
        private readonly string OrderId;
        private readonly string TransactionId;
        private readonly string SessionId;
        private readonly string SellerUserId;
        private readonly string MerchantId;
        public Transactions()
        {
            ApiKey = environmentVariable.ApiKey;
            UserId = environmentVariable.user_id;
            UserEmail = environmentVariable.user_email;
            OrderId = environmentVariable.order_id;
            TransactionId = environmentVariable.transaction_id;
            SessionId = environmentVariable.session_id;
            SellerUserId = environmentVariable.seller_user_id;
            MerchantId = environmentVariable.merchant_id;
        }
        [Fact]
        public void TransactionTest()
        {
            var sift = new Client(ApiKey);
            var transaction = new Transaction
            {
                user_id = UserId,
                user_email = UserEmail,
                verification_phone_number = "+123456789012",
                transaction_type = "$sale",
                transaction_status = "$failure",
                amount = 506790000,
                currency_code = "USD",
                order_id = OrderId,
                transaction_id = TransactionId,
                billing_address = new Address()
                {
                    name = "Bill Jones",
                    phone = "1-415-555-6041",
                    address_1 = "2100 Main Street",
                    address_2 = "Apt 3B",
                    city = "New London",
                    region = "New Hampshire",
                    country = "US",
                    zipcode = "03257"
                },
                payment_method = new PaymentMethod()
                {
                    payment_type = "$ach_credit",
                    payment_gateway = "$stripe",
                    card_bin = "542486",
                    card_last4 = "4242",
                    cvv_result_code = "M",
                    avs_result_code = "Y",
                    stripe_address_line1_check = "pass",
                    stripe_address_line2_check = "pass",
                    stripe_address_zip_check = "pass",
                    verification_status = "$success",
                    routing_number = "4444333333",
                    sepa_direct_debit_mandate = true,
                    wallet_type = "$crypto",
                    account_holder_name = "John Smith",
                    account_number_last5 = "44144"
                },
                shipping_address = new Address()
                {
                    name = "Bill Jones",
                    phone = "1-415-555-6041",
                    address_1 = "2100 Main Street",
                    address_2 = "Apt 3B",
                    city = "New London",
                    region = "New Hampshire",
                    country = "US",
                    zipcode = "03257"
                },
                session_id = SessionId,
                seller_user_id = SellerUserId,
                decline_category = "$fraud",
                ordered_from = new OrderedFrom()
                {
                    store_id = "123",
                    store_address = new Address()
                    {
                        name = "Bill Jones",
                        phone = "1-415-555-6040",
                        address_1 = "2100 Main Street",
                        address_2 = "Apt 3B",
                        city = "New London",
                        region = "New Hampshire",
                        country = "US",
                        zipcode = "03257"
                    }
                },
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US",
                status_3ds = "$attempted",
                triggered_3ds = "$processor",
                merchant_initiated_transaction = false,
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
                },
                sent_address = new Address()
                {
                    name = "Alex Smith",
                    address_1 = "abc",
                    address_2 = "xyz",
                    city = "New London",
                    region = "New Hampshire",
                    country = "US",
                    zipcode = "03257",
                    phone = "1-415-555-6041"
                },
                received_address = new Address()
                {
                    name = "Alex Smith",
                    address_1 = "abc",
                    address_2 = "xyz",
                    city = "New London",
                    region = "New Hampshire",
                    country = "US",
                    zipcode = "03257",
                    phone = "1-415-555-6041"
                },
                digital_orders = new ObservableCollection<DigitalOrder>()
                {
                    new DigitalOrder()
                    {
                        digital_asset = "BTC",
                        pair = "BTC_USD",
                        asset_type = "$crypto",
                        order_type = "$market",
                        volume = "6.0"
                    },
                    new DigitalOrder()
                    {
                        digital_asset = "BTC"
                    }
                },
                receiver_external_address = true
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = transaction
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }
    }
}
