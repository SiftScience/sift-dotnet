using Sift;
using System.Collections.ObjectModel;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.EventsAPI
{
    public class Account
    {
        private readonly EnvironmentVariable environmentVariable = new();
        [Fact]
        public void IntegrationTest_CreateAccount()
        {
            var sift = new Client(environmentVariable.ApiKey);
            var createAccount = new CreateAccount
            {
                user_id = environmentVariable.user_id,
                session_id = environmentVariable.session_id,
                user_email = environmentVariable.user_email,
                name = "Bill Jones",
                phone = "1-415-555-6040",
                referrer_user_id = environmentVariable.referrer_user_id,
                payment_methods = new ObservableCollection<PaymentMethod>()
                {
                    new PaymentMethod()
                    {
                        payment_type = "$credit_card",
                        payment_gateway = "$braintree",
                        card_bin = "542486",
                        card_last4 = "4444"
                    },
                    new PaymentMethod()
                    {
                        payment_type = "$credit_card"
                    }

                },
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
                promotions = new ObservableCollection<Promotion>()
                {
                    new Promotion()
                    {
                        promotion_id = "FirstTimeBuyer",
                        status = "$success",
                        description = "$5 off",
                        discount = new Discount()
                        {
                            amount = 5000000,
                            currency_code = "USD",
                            minimum_purchase_amount = 25000000
                        }
                    }
                },
                social_sign_on_type = "$twitter",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                account_types = new ObservableCollection<string>() { "merchant", "premium" },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
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
                Event = createAccount
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }

        [Fact]
        public void IntegrationTest_UpdateAccount()
        {
            var sift = new Client(environmentVariable.ApiKey);
            var updateAccount = new UpdateAccount
            {
                user_id = environmentVariable.user_id,
                session_id = environmentVariable.session_id,
                changed_password = true,
                user_email = environmentVariable.user_email,
                verification_phone_number = "+123456789012",
                name = "Bill Jones",
                phone = "1-415-555-6040",
                referrer_user_id = environmentVariable.referrer_user_id,
                payment_methods = new ObservableCollection<PaymentMethod>()
                {
                    new PaymentMethod()
                    {
                        payment_type = "$credit_card",
                        payment_gateway = "$braintree",
                        card_bin = "542486",
                        card_last4 = "4444"
                    },
                    new PaymentMethod()
                    {
                        payment_type = "$credit_card"
                    }
                },
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
                social_sign_on_type = "$twitter",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                account_types = new ObservableCollection<string>() { "merchant", "premium" },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
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
                Event = updateAccount
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }
    }
}
