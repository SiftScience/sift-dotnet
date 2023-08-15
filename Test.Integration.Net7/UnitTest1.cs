using Sift;
using System.Collections.ObjectModel;
using Xunit;

namespace Test.Integration.Net7
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Fact]
        public void IntegrationTest_AdditemtocartEvent()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var addItemToCart = new AddItemToCart
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                item = new Item()
                {
                    item_id = "B004834GQO",
                    product_title = "The Slanket Blanket-Texas Tea",
                    price = 39990000,
                    currency_code = "USD",
                    upc = "6786211451001",
                    sku = "004834GQ",
                    isbn = "0446576220",
                    brand = "Slanket",
                    manufacturer = "Slanket",
                    category = "Blankets & Throws",
                    tags = new ObservableCollection<string>() { "Awesome", "Wintertime specials" },
                    color = "Texas Tea",
                    quantity = 16,
                },
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
                verification_phone_number = "+123456789012"
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = addItemToCart
            };
            try
            {
                EventResponse res = sift.SendAsync(eventRequest).Result;
            }
            catch (AggregateException ae)
            {
                // Handle InnerException
            }
        }

        [Fact]
        public void IntegrationTest_AddPromotion()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var addPromotion = new AddPromotion
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                promotions = new ObservableCollection<Promotion>()
                {
                    new Promotion()
                    {
                          promotion_id = "NewCustomerReferral2016",
                          status = "$success",
                          failure_reason = "$already_used",
                          description =   "$5 off your first 5 rides",
                          referrer_user_id = "elon-m93903",
                          discount = new Discount()
                          {
                                  percentage_off = 0.2,
                                  amount = 5000000,
                                  currency_code = "USD",
                                  minimum_purchase_amount = 50000000
                          },
                          credit_point = new CreditPoint()
                          {
                                  amount = 5000,
                                  credit_point_type = "character xp points"
                          }
                    },
                    new Promotion()
                    {
                        promotion_id = "NewCustomerReferral2016"
                    }
                },
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
                verification_phone_number = "+123456789012"
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = addPromotion
            };
            try
            {
                EventResponse res = sift.SendAsync(eventRequest).Result;
            }
            catch (AggregateException ae)
            {
                // Handle InnerException
            }
        }

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
                session_id = "gigtleqddo84l8cm15qe4il",
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
            try
            {
                EventResponse res = sift.SendAsync(eventRequest).Result;
            }
            catch (AggregateException ae)
            {
                // Handle InnerException
            }
        }

        [Fact]
        public void IntegrationTest_ContentStatus()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var contentStatus = new ContentStatus
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                content_id = "9671500641",
                status = "$paused",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
                verification_phone_number = "+123456789012"
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = contentStatus
            };
            try
            {
                EventResponse res = sift.SendAsync(eventRequest).Result;
            }
            catch (AggregateException ae)
            {
                // Handle InnerException
            }
        }
    }
}