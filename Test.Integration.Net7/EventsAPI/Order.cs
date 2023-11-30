using Sift;
using System;
using System.Collections.ObjectModel;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.EventsAPI
{
    public class Order
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string UserId;
        private readonly string SessionId;
        private readonly string OrderId;
        private readonly string UserEmail;
        private readonly string ItemId;
        private readonly string SellerUserId;
        private readonly string PromotionId;
        private readonly string WebhookId;
        public Order()
        {
            ApiKey = environmentVariable.ApiKey;
            UserId = environmentVariable.user_id;
            SessionId = environmentVariable.session_id;
            UserEmail = environmentVariable.user_email;
            ItemId = environmentVariable.item_id;
            SellerUserId = environmentVariable.seller_user_id;
            PromotionId = environmentVariable.promotion_id;
            WebhookId = environmentVariable.webhook_id;

            long nowMills = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            OrderId = environmentVariable.order_id + nowMills;
        }

        [Fact]
        public void OrderTest()
        {
            var sift = new Client(ApiKey);
            EventResponse createOrderResp = CreateOrder(sift);
            Assert.Equal("0", createOrderResp.Status.ToString());

            EventResponse updateOrderResp = UpdateOrder(sift);
            Assert.Equal("0", updateOrderResp.Status.ToString());

            EventResponse orderStatusResp = OrderStatus(sift);
            Assert.Equal("0", orderStatusResp.Status.ToString());
        }

        private EventResponse CreateOrder(Client sift)
        {
            var createOrder = new CreateOrder
            {
                user_id = UserId,
                session_id = SessionId,
                order_id = OrderId,
                user_email = UserEmail,
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
                        item_id = ItemId,
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
                        item_id = ItemId
                    }
                },
                seller_user_id = SellerUserId,
                promotions = new ObservableCollection<Promotion>()
                {
                    new Promotion()
                    {
                        promotion_id = PromotionId,
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
            EventResponse res = sift.SendAsync(eventRequest).Result;
            return res;
        }

        private EventResponse UpdateOrder(Client sift)
        {
            var updateOrder = new UpdateOrder
            {
                user_id = UserId,
                session_id = SessionId,
                order_id = OrderId,
                user_email = UserEmail,
                verification_phone_number = "+123456789012",
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
                        item_id = ItemId,
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
                        item_id = ItemId
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
                Event = updateOrder
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            return res;
        }

        private EventResponse OrderStatus(Client sift)
        {
            var orderStatus = new OrderStatus
            {
                user_id = UserId,
                order_id = OrderId,
                order_status = "$canceled",
                reason = "$payment_risk",
                source = "$manual_review",
                analyst = "someone@your-site.com",
                webhook_id = WebhookId,
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
            EventResponse res = sift.SendAsync(eventRequest).Result;
            return res;
        }
    }
}
