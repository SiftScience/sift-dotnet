using Sift;
using System;
using System.Collections.ObjectModel;
using Xunit;

namespace Test.Integration.Net7
{
    public class Tests
    {
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

            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
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

        [Fact]
        public void IntegrationTest_CreateOrder()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                order_id = "ORDER-28168441",
                user_email = "billjones1@example.com",
                amount = 115940000,
                currency_code = "USD",
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
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US",
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
                expedited_shipping = true,
                shipping_method = "$physical",
                items = new ObservableCollection<Item>()
                {
                    new Item()
                    {
                        item_id = "12344321",
                        product_title = "Microwavable Kettle Corn: Original Flavor",
                        price = 4990000,
                        currency_code = "USD",
                        upc = "097564307560",
                        sku = "03586005",
                        isbn = "0446576220",
                        brand = "Peters Kettle Corn",
                        manufacturer = "Peters Kettle Corn",
                        category = "Food and Grocery",
                        tags = new ObservableCollection<string>() { "Popcorn", "Snacks", "On Sale" },
                        color = "Texas Tea",
                        quantity = 4
                    },
                    new Item()
                    {
                        item_id = "12344321"
                    }
                },
                seller_user_id = "slinkys_emporium",
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
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                }
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = createOrder
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
        public void IntegrationTest_FlagContent()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var flagContent = new FlagContent
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                content_id = "9671500641",
                flagged_by = "jamieli89",
                reason = "$toxic",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                verification_phone_number = "+123456789012"
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = flagContent
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
        public void IntegrationTest_LinkSessionToUser()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var linkSessionToUser = new LinkSessionToUser
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il"
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = linkSessionToUser
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
        public void IntegrationTest_Login()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var login = new Login
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                login_status = "$success",
                ip = "128.148.1.135",
                user_email = "billjones1@example.com",
                account_types = new ObservableCollection<string>() { "merchant", "premium" },
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                username = "billjones1@example.com",
                failure_reason = "$account_unknown",
                verification_phone_number = "+123456789012"

            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = login
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
        public void IntegrationTest_Logout()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var logout = new Logout
            {
                user_id = "billy_jones_301",
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                }

            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = logout
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
        public void IntegrationTest_OrderStatus()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var orderStatus = new OrderStatus
            {
                user_id = "billy_jones_301",
                order_id = "ORDER-28168441",
                order_status = "$canceled",
                reason = "$payment_risk",
                source = "$manual_review",
                analyst = "someone@your-site.com",
                webhook_id = "3ff1082a4aea8d0c58e3643ddb7a5bb87ffffeb2492dca33",
                description = "Canceling because multiple fraudulent users on device",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com"
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = orderStatus
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