using Newtonsoft.Json;
using Sift;
using Sift.Core;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace Test
{
    public class Test
    {
        [Fact]
        public void TestApplyDecisionRequest()
        {
            var applyDecisionRequest = new ApplyOrderDecisionRequest
            {
                AccountId = "123",
                UserId = "gary",
                OrderId = "1",
                DecisionId = "abc",
                Source = "AUTOMATED_RULE"
            };

            applyDecisionRequest.ApiKey = "key";

            Assert.Equal("https://api.sift.com/v3/accounts/123/users/gary/orders/1/decisions",
                         applyDecisionRequest.Request.RequestUri!.ToString());

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes("key")),
                         applyDecisionRequest.Request.Headers.Authorization!.Parameter);

        }

        [Fact]
        public void TestEventRequest()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_booking_with_all_fields",
                order_id = "oid",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = sessionId,
                user_email = "bill@gmail.com",
                bookings = new ObservableCollection<Booking>()
                {
                    new Booking()
                    {
                        booking_type = "$flight",
                        title = "SFO - LAS, 2 Adults",
                        start_time= 2038412903,
                        end_time= 2038412903,
                        price = 49900000,
                        currency_code = "USD",
                        quantity = 1,
                        venue_id = "venue-123",
                        event_id = "event-123",
                        room_type = "deluxe",
                        category = "pop",
                        guests = new ObservableCollection<Guest>()
                        {
                            new Guest()
                            {
                                name = "John Doe",
                                birth_date = "1985-01-19",
                                loyalty_program = "skymiles",
                                loyalty_program_id = "PSOV34DF",
                                phone = "1-415-555-6040",
                                email = "jdoe@domain.com"
                            },
                            new Guest()
                            {
                                name = "John Doe"
                            }
                        },
                        segments = new ObservableCollection<Segment>()
                        {
                            new Segment()
                            {
                                departure_address = new Address
                                {
                                    name = "Bill Jones",
                                    phone =  "1-415-555-6040",
                                    address_1 = "2100 Main Street",
                                    address_2 = "Apt 3B",
                                    city = "New London",
                                    region = "New Hampshire",
                                    country = "US",
                                    zipcode = "03257"
                                },
                                arrival_address = new Address
                                {
                                    name = "Bill Jones",
                                    phone =  "1-415-555-6040",
                                    address_1 = "2100 Main Street",
                                    address_2 = "Apt 3B",
                                    city = "New London",
                                    region = "New Hampshire",
                                    country = "US",
                                    zipcode = "03257"
                                },
                                start_time = 203841290300L,
                                end_time = 2038412903,
                                vessel_number = "LH454",
                                fare_class = "Premium Economy",
                                departure_airport_code = "SFO",
                                arrival_airport_code = "LAS"
                            }
                        },
                        location = new Address
                        {
                            name = "Bill Jones",
                            phone =  "1-415-555-6040",
                            address_1 = "2100 Main Street",
                            address_2 = "Apt 3B",
                            city = "New London",
                            region = "New Hampshire",
                            country = "US",
                            zipcode = "03257"
                        },
                        tags = new ObservableCollection<string>() { "tag-123", "tag-321"}
                    }
                },
                billing_address = new Address
                {
                    name = "gary",
                    city = "san francisco"
                },
                app = new App
                {
                    app_name = "my app",
                    app_version = "1.0",
                    client_language = "en-US"
                },
                ordered_from = new OrderedFrom
                {
                    store_id = "123",
                    store_address = new Address
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
                site_country = "US",
                site_domain = "sift.com",
                brand_name = "sift"
            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_booking_with_all_fields\"," +
                         "\"$session_id\":\"sessionId\",\"$order_id\":\"oid\",\"$user_email\":\"bill@gmail.com\"," +
                         "\"$amount\":1000000000000,\"$currency_code\":\"USD\",\"$billing_address\":{\"$name\":\"gary\",\"$city\":\"san francisco\"}," +
                         "\"$bookings\":[{\"$booking_type\":\"$flight\",\"$title\":\"SFO - LAS, 2 Adults\",\"$start_time\":2038412903," +
                         "\"$end_time\":2038412903,\"$price\":49900000,\"$currency_code\":\"USD\",\"$quantity\":1,\"$guests\":[{\"$name\":\"John Doe\"," +
                         "\"$email\":\"jdoe@domain.com\",\"$phone\":\"1-415-555-6040\",\"$loyalty_program\":\"skymiles\",\"$loyalty_program_id\":\"PSOV34DF\"," +
                         "\"$birth_date\":\"1985-01-19\"},{\"$name\":\"John Doe\"}],\"$segments\":[{\"$start_time\":203841290300,\"$end_time\":2038412903," +
                         "\"$vessel_number\":\"LH454\",\"$departure_airport_code\":\"SFO\",\"$arrival_airport_code\":\"LAS\",\"$fare_class\":\"Premium Economy\"," +
                         "\"$departure_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\"," +
                         "\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}," +
                         "\"$arrival_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\"," +
                         "\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}}],\"$room_type\":\"deluxe\"," +
                         "\"$event_id\":\"event-123\",\"$venue_id\":\"venue-123\",\"$location\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\"," +
                         "\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\"," +
                         "\"$phone\":\"1-415-555-6040\"},\"$category\":\"pop\",\"$tags\":[\"tag-123\",\"tag-321\"]}],\"$app\":{\"$app_name\":\"my app\"," +
                         "\"$app_version\":\"1.0\",\"$client_language\":\"en-US\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"," +
                         "\"$ordered_from\":{\"$store_id\":\"123\",\"$store_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\"," +
                         "\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\"," +
                         "\"$phone\":\"1-415-555-6040\"}},\"foo\":\"bar\"}",
                         createOrder.ToJson());


            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true,
                ReturnRouteInfo = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true&return_route_info=true",
                         Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestCustomEventRequest()
        {
            // Construct custom events with required fields
            var makeCall = new CustomEvent
            {
                type = "make_call",
                user_id = "gary"
            };

            // Augment with custom fields
            makeCall.AddFields(new Dictionary<string, object>
            {
                ["foo"] = "bar",
                ["payment_status"] = "$success"
            });

            Assert.Equal("{\"$type\":\"make_call\",\"$user_id\":\"gary\",\"foo\":" +
                              "\"bar\",\"payment_status\":\"$success\"}",
                              makeCall.ToJson());
        }

        [Fact]
        public void TestEventWithBrowser()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_browser_field",
                order_id = "oid",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = sessionId,
                user_email = "bill@gmail.com",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                }
            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_browser_field\",\"$session_id\":\"sessionId\"," +
                         "\"$order_id\":\"oid\",\"$user_email\":\"bill@gmail.com\",\"$amount\":1000000000000,\"$currency_code\":\"USD\"," +
                         "\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\"," +
                         "\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"foo\":\"bar\"}",
                         createOrder.ToJson());


            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                         Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestTransactionEvent()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var transaction = new Transaction
            {
                user_id = "test_dotnet_transaction_event",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = sessionId,
                transaction_type = "$sale",
                transaction_status = "$failure",
                decline_category = "$invalid"
            };

            // Augment with custom fields
            transaction.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$transaction\",\"$user_id\":\"test_dotnet_transaction_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$transaction_type\":\"$sale\",\"$transaction_status\":\"$failure\",\"$amount\":1000000000000,\"$currency_code\":\"USD\"," +
                                 "\"$decline_category\":\"$invalid\",\"foo\":\"bar\"}", transaction.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = transaction
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = transaction,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestTransactionEventWithCryptoFields()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var transaction = new Transaction
            {
                user_id = "test_dotnet_transaction_event",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = sessionId,
                transaction_type = "$sale",
                transaction_status = "$failure",
                payment_method = new PaymentMethod
                {
                    wallet_address = "ZplYVmchAoywfMvC8jCiKlBLfKSBiFtHU6",
                    wallet_type = "$crypto"
                }
                ,
                digital_orders = new ObservableCollection<DigitalOrder>()
                {
                    new DigitalOrder
                    {
                        digital_asset="BTC",
                        pair="BTC_USD",
                        asset_type="$crypto",
                        order_type="$market",
                        volume="6.0"
                    }
                },
                receiver_wallet_address = "jx17gVqSyo9m4MrhuhuYEUXdCicdof85Bl",
                receiver_external_address = true

            };

            // Augment with custom fields
            transaction.AddField("foo", "bar");
            Assert.Equal("{" +
            "\"$type\":\"$transaction\"," +
            "\"$user_id\":\"test_dotnet_transaction_event\"," +
            "\"$session_id\":\"sessionId\"," +
            "\"$transaction_type\":\"$sale\"," +

            "\"$transaction_status\":\"$failure\"," +
            "\"$amount\":1000000000000," +
            "\"$currency_code\":\"USD\"," +
            "" +
            "\"$payment_method\":{" +
            "\"$wallet_address\":\"ZplYVmchAoywfMvC8jCiKlBLfKSBiFtHU6\"," +
            "\"$wallet_type\":\"$crypto\"" +
            "}," +
            "\"$digital_orders\":[" +
            "{" +
            "\"$digital_asset\":\"BTC\"," +
            "\"$pair\":\"BTC_USD\"," +
            "\"$asset_type\":\"$crypto\"," +
            "\"$order_type\":\"$market\"," +
            "\"$volume\":\"6.0\"" +
            "}" +
            "]," +
            "\"$receiver_wallet_address\":\"jx17gVqSyo9m4MrhuhuYEUXdCicdof85Bl\"," +
            "\"$receiver_external_address\":true," +
            "\"foo\":\"bar\"" +
            "}", transaction.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = transaction
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = transaction,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestCreateOrderEventWithSepaPaymentMethodFields()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_sepa_payment_method_fields",
                session_id = sessionId,
                order_id = "12345",
                payment_methods = new ObservableCollection<PaymentMethod>()
                {
                    new PaymentMethod
                    {
                        payment_type = "$sepa_instant_credit",
                        shortened_iban_first6 = "FR7630",
                        shortened_iban_last4 = "1234",
                        sepa_direct_debit_mandate = true
                    }
                }
            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_sepa_payment_method_fields\",\"$session_id\":\"sessionId\"," +
                                 "\"$order_id\":\"12345\",\"$payment_methods\":[{\"$payment_type\":\"$sepa_instant_credit\",\"$shortened_iban_first6\":\"FR7630\"," +
                                 "\"$shortened_iban_last4\":\"1234\",\"$sepa_direct_debit_mandate\":true}],\"foo\":\"bar\"}",
                                 createOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestCreateOrderEventWithMerchantProfileField()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_merchant_profile_field",
                session_id = sessionId,
                order_id = "12345",
                payment_methods = new ObservableCollection<PaymentMethod>()
                {
                    new PaymentMethod
                    {
                        payment_type = "$sepa_instant_credit",
                        shortened_iban_first6 = "FR7630",
                        shortened_iban_last4 = "1234",
                        sepa_direct_debit_mandate = true
                    }
                },
                merchant_profile = new MerchantProfile
                {
                    merchant_id = "123",
                    merchant_category_code = "9876",
                    merchant_name = "ABC Merchant",
                    merchant_address = new Address
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
                }
            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_merchant_profile_field\",\"$session_id\":\"sessionId\"," +
                                 "\"$order_id\":\"12345\",\"$payment_methods\":[{\"$payment_type\":\"$sepa_instant_credit\",\"$shortened_iban_first6\":\"FR7630\"," +
                                 "\"$shortened_iban_last4\":\"1234\",\"$sepa_direct_debit_mandate\":true}],\"$merchant_profile\":{\"$merchant_id\":\"123\"," +
                                 "\"$merchant_category_code\":\"9876\",\"$merchant_name\":\"ABC Merchant\",\"$merchant_address\":{\"$name\":\"Bill Jones\"," +
                                 "\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\"," +
                                 "\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}},\"foo\":\"bar\"}",
                                 createOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestCreateOrderEventWithCryptoFields()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_merchant_profile_field",
                session_id = sessionId,
                order_id = "12345",
                payment_methods = new ObservableCollection<PaymentMethod>()
                {
                    new PaymentMethod
                    {
                        wallet_address = "ZplYVmchAoywfMvC8jCiKlBLfKSBiFtHU6",
                        wallet_type = "$crypto"
                    }
                },
                digital_orders = new ObservableCollection<DigitalOrder>()
                {
                    new DigitalOrder
                    {
                        digital_asset="BTC",
                        pair="BTC_USD",
                        asset_type="$crypto",
                        order_type="$market",
                        volume="6.0"
                    }
                },

            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_merchant_profile_field\",\"$session_id\":\"sessionId\"," +
            "\"$order_id\":\"12345\"," +
            "\"$payment_methods\":[" +
            "{" +
            "\"$wallet_address\":\"ZplYVmchAoywfMvC8jCiKlBLfKSBiFtHU6\"," +
            "\"$wallet_type\":\"$crypto\"" +
            "}" +
            "]," +
            "\"$digital_orders\":[" +
            "{" +
            "\"$digital_asset\":\"BTC\"," +
            "\"$pair\":\"BTC_USD\"," +
            "\"$asset_type\":\"$crypto\"," +
            "\"$order_type\":\"$market\"," +
            "\"$volume\":\"6.0\"" +
            "}" +
            "]," +
            "\"foo\":\"bar\"}",
            createOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestUpdateOrderEventWithCryptoFields()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var updateOrder = new UpdateOrder
            {
                user_id = "test_dotnet_merchant_profile_field",
                session_id = sessionId,
                order_id = "12345",
                payment_methods = new ObservableCollection<PaymentMethod>()
                {
                    new PaymentMethod
                    {
                        wallet_address = "ZplYVmchAoywfMvC8jCiKlBLfKSBiFtHU6",
                        wallet_type = "$crypto"
                    }
                },
                digital_orders = new ObservableCollection<DigitalOrder>()
                {
                    new DigitalOrder
                    {
                        digital_asset="BTC",
                        pair="BTC_USD",
                        asset_type="$crypto",
                        order_type="$market",
                        volume="6.0"
                    }
                },

            };

            // Augment with custom fields
            updateOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$update_order\",\"$user_id\":\"test_dotnet_merchant_profile_field\",\"$session_id\":\"sessionId\"," +
            "\"$order_id\":\"12345\"," +
            "\"$payment_methods\":[" +
            "{" +
            "\"$wallet_address\":\"ZplYVmchAoywfMvC8jCiKlBLfKSBiFtHU6\"," +
            "\"$wallet_type\":\"$crypto\"" +
            "}" +
            "]," +
            "\"$digital_orders\":[" +
            "{" +
            "\"$digital_asset\":\"BTC\"," +
            "\"$pair\":\"BTC_USD\"," +
            "\"$asset_type\":\"$crypto\"," +
            "\"$order_type\":\"$market\"," +
            "\"$volume\":\"6.0\"" +
            "}" +
            "]," +
            "\"foo\":\"bar\"}",
            updateOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestTransactionEventWithFintechFields()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var transaction = new Transaction
            {
                user_id = "test_dotnet_transaction_event",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = sessionId,
                transaction_type = "$sale",
                transaction_status = "$failure",
                decline_category = "$invalid",
                merchant_profile = new MerchantProfile
                {
                    merchant_id = "123",
                    merchant_category_code = "9876",
                    merchant_name = "ABC Merchant",
                    merchant_address = new Address
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
                sent_address = new Address
                {
                    name = "Bill Jones",
                    phone = "1-415-555-6040",
                    address_1 = "2100 Main Street",
                    address_2 = "Apt 3B",
                    city = "New London",
                    region = "New Hampshire",
                    country = "US",
                    zipcode = "03257"
                },
                received_address = new Address
                {
                    name = "Bill Jones",
                    phone = "1-415-555-6040",
                    address_1 = "2100 Main Street",
                    address_2 = "Apt 3B",
                    city = "New London",
                    region = "New Hampshire",
                    country = "US",
                    zipcode = "03257"
                },
                payment_method = new PaymentMethod
                {
                    payment_type = "$sepa_instant_credit",
                    shortened_iban_first6 = "FR7630",
                    shortened_iban_last4 = "1234",
                    sepa_direct_debit_mandate = true
                },
                status_3ds = "$successful",
                triggered_3ds = "$processor",
                merchant_initiated_transaction = true
            };
            Assert.Equal("{\"$type\":\"$transaction\",\"$user_id\":\"test_dotnet_transaction_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$transaction_type\":\"$sale\",\"$transaction_status\":\"$failure\",\"$amount\":1000000000000,\"$currency_code\":\"USD\"," +
                                 "\"$payment_method\":{\"$payment_type\":\"$sepa_instant_credit\",\"$shortened_iban_first6\":\"FR7630\"," +
                                 "\"$shortened_iban_last4\":\"1234\",\"$sepa_direct_debit_mandate\":true},\"$decline_category\":\"$invalid\"," +
                                 "\"$sent_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\"," +
                                 "\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}," +
                                 "\"$received_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\"," +
                                 "\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}," +
                                 "\"$status_3ds\":\"$successful\",\"$triggered_3ds\":\"$processor\",\"$merchant_initiated_transaction\":true," +
                                 "\"$merchant_profile\":{\"$merchant_id\":\"123\",\"$merchant_category_code\":\"9876\",\"$merchant_name\":\"ABC Merchant\"," +
                                 "\"$merchant_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\"," +
                                 "\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}}}",
                                 transaction.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = transaction
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = transaction,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestCreateOrderEventWithWirePaymentMethod()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_wire_payment_methods",
                session_id = sessionId,
                order_id = "12345",
                payment_methods = new ObservableCollection<PaymentMethod>()
            {
                new PaymentMethod
                {
                    payment_type = "$wire_credit",
                    routing_number = "CHASUS33XX",
                    account_number_last5 = "12345",
                    account_holder_name = "John Doe",
                    bank_name = "Chase",
                    bank_country = "US"
                }
            }
            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_wire_payment_methods\",\"$session_id\":\"sessionId\"," +
                                 "\"$order_id\":\"12345\",\"$payment_methods\":[{\"$payment_type\":\"$wire_credit\",\"$routing_number\":\"CHASUS33XX\"," +
                                 "\"$account_number_last5\":\"12345\",\"$account_holder_name\":\"John Doe\",\"$bank_name\":\"Chase\",\"$bank_country\":\"US\"}],\"foo\":\"bar\"}",
                                 createOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestVerificationCheckRequest()
        {
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            var verificationCheckRequest = new VerificationCheckRequest
            {

                ApiKey = apiKey,
                Code = 655543,
                UserId = "haneeshv@exalture.com",
                VerifiedEntityId = "SOME_SESSION_ID",
                VerifiedEvent = "$login"
            };

            verificationCheckRequest.ApiKey = apiKey;

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes(apiKey)),
                verificationCheckRequest.Request.Headers.Authorization!.Parameter);

            Assert.Equal("https://api.sift.com/v1/verification/check",
                         verificationCheckRequest.Request.RequestUri!.ToString());
        }

        [Fact]
        public void TestVerificationSendRequest()
        {
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var verificationSendRequest = new VerificationSendRequest
            {
                UserId = "haneeshv@exalture.com",
                ApiKey = apiKey,
                BrandName = "all",
                VerificationType = "$email",
                SendTo = "haneeshv@exalture.com",
                Language = "en",
                SiteCountry = "IN",
                Event = new VerificationSendEvent()
                {
                    Browser = new Browser()
                    {
                        user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                        content_language = "en-US",
                        accept_language = "en-GB",
                    },
                    IP = "192.168.1.1",
                    Reason = "$automated_rule",
                    SessionId = sessionId,
                    VerifiedEvent = "$login",
                    VerifiedEntityId = "SOME_SESSION_ID"
                }
            };

            verificationSendRequest.ApiKey = apiKey;

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes(apiKey)),
                verificationSendRequest.Request.Headers.Authorization!.Parameter);

            Assert.Equal("https://api.sift.com/v1/verification/send",
                         verificationSendRequest.Request.RequestUri!.ToString());
        }

        [Fact]
        public void TestVerificationReSendRequest()
        {
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            var verificationResendRequest = new VerificationReSendRequest
            {
                UserId = "haneeshv@exalture.com",
                ApiKey = apiKey,
                VerifiedEntityId = "SOME_SESSION_ID",
                VerifiedEvent = "$login"
            };
            verificationResendRequest.ApiKey = apiKey;

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes(apiKey)),
                verificationResendRequest.Request.Headers.Authorization!.Parameter);

            Assert.Equal("https://api.sift.com/v1/verification/resend",
                         verificationResendRequest.Request.RequestUri!.ToString());
        }


        [Fact]
        public void TestWebHookValidation()
        {
            //Please provide the valid secret key in place of 'key'
            String secretKey = "key";
            String requestBody = "{" +
                "\"entity\": {" +
                "\"type\": \"user\"," +
                "\"id\": \"USER123\"" +
                "}," +
                "\"decision\": {" +
                "\"id\": \"block_user_payment_abuse\"" +
                "}," +
                "\"time\": 1461963439151" +
                "}";
            byte[] key = Encoding.ASCII.GetBytes(secretKey);
            HMACSHA1 myhmacsha1 = new HMACSHA1(key);
            byte[] byteArray = Encoding.ASCII.GetBytes(requestBody);
            MemoryStream stream = new MemoryStream(byteArray);
            string signatureCore = myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
            String signature = "sha1=" + signatureCore;
            WebhookValidator webhook = new WebhookValidator();
            Assert.True(webhook.IsValidWebhook(requestBody, secretKey, signature));

        }

        [Fact]
        public void TestWebHookValidationForInvalidSecretKey()
        {
            //Please provide the secret api key in place of 'key'
            String secretKey = "key";
            String requestBody = "{" +
                "\"entity\": {" +
                "\"type\": \"user\"," +
                "\"id\": \"USER123\"" +
                "}," +
                "\"decision\": {" +
                "\"id\": \"block_user_payment_abuse\"" +
                "}," +
                "\"time\": 1461963439151" +
                "}";

            WebhookValidator webhook = new WebhookValidator();
            Assert.False(webhook.IsValidWebhook(requestBody, secretKey, "InValid Key"));


        }

        [Fact]
        public void TestGetMerchantsRequest()
        {
            //Please provide the valid account id in place of dummy number;
            var accountId = "12345678";
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            var getMerchantRequest = new GetMerchantsRequest
            {
                AccountId = accountId
            };
            getMerchantRequest.ApiKey = apiKey;

            Assert.Equal("https://api.sift.com/v3/accounts/" + accountId + "/psp_management/merchants",
                         getMerchantRequest.Request.RequestUri!.ToString());

        }

        [Fact]
        public void TestCreateMerchantRequest()
        {
            //Please provide the valid account id in place of dummy number;
            var accountId = "12345678";
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            var createMerchantRequest = new CreateMerchantRequest
            {
                AccountId = accountId,
                ApiKey = apiKey,
                Id = "test-vineeth-5",
                Name = "Wonderful Payments Inc",
                Description = "Wonderful Payments payment provider",
                Address = new MerchantAddress
                {
                    Name = "Alany",
                    Address1 = "Big Payment blvd, 22",
                    Address2 = "apt, 8",
                    City = "New Orleans",
                    Country = "US",
                    Phone = "0394888320",
                    Region = "NA",
                    ZipCode = "76830"

                },
                Category = "1002",
                ServiceLevel = "Platinum",
                Status = "active",
                RiskProfile = new MerchantRiskProfile
                {
                    Level = "low",
                    Score = 10
                }
            };

            createMerchantRequest.ApiKey = apiKey;

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes(apiKey)),
                createMerchantRequest.Request.Headers.Authorization!.Parameter);


            Assert.Equal("https://api.sift.com/v3/accounts/" + accountId + "/psp_management/merchants",
                         createMerchantRequest.Request.RequestUri!.ToString());
        }

        [Fact]
        public void TestUpdateMerchantRequest()
        {
            //Please provide the valid account id in place of dummy number;
            var accountId = "12345678";
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            var updateMerchantRequest = new UpdateMerchantRequest
            {
                AccountId = accountId,
                MerchantId = "test2",
                ApiKey = apiKey,
                Id = "test-vineeth-5",
                Name = "Wonderful Payments Inc",
                Description = "Wonderful Payments payment provider",
                Address = new MerchantAddress
                {
                    Name = "Alany",
                    Address1 = "Big Payment blvd, 22",
                    Address2 = "apt, 8",
                    City = "New Orleans",
                    Country = "US",
                    Phone = "0394888320",
                    Region = "NA",
                    ZipCode = "76830"

                },
                Category = "1002",
                ServiceLevel = "Platinum",
                Status = "active",
                RiskProfile = new MerchantRiskProfile
                {
                    Level = "low",
                    Score = 10
                }
            };
            updateMerchantRequest.ApiKey = apiKey;

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes(apiKey)),
                updateMerchantRequest.Request.Headers.Authorization!.Parameter);

            Assert.Equal("https://api.sift.com/v3/accounts/" + accountId + "/psp_management/merchants/test2",
                         updateMerchantRequest.Request.RequestUri!.ToString());


            Assert.Equal("{\"id\":\"test-vineeth-5\"," +
                "\"name\":\"Wonderful Payments Inc\"," +
                "\"description\":\"Wonderful Payments payment provider\"," +
                "\"address\":{\"name\":\"Alany\"," +
                    "\"address_1\":\"Big Payment blvd, 22\"," +
                    "\"address_2\":\"apt, 8\"," +
                    "\"city\":\"New Orleans\"," +
                    "\"region\":\"NA\"," +
                    "\"country\":\"US\"," +
                    "\"zipcode\":\"76830\"," +
                    "\"phone\":\"0394888320\"}," +
                "\"category\":\"1002\"," +
                "\"service_level\":\"Platinum\"," +
                "\"status\":\"active\"," +
                "\"risk_profile\":{\"level\":\"low\",\"score\":10}}",
                               Newtonsoft.Json.JsonConvert.SerializeObject(updateMerchantRequest));

        }

        [Fact]
        public void TestGetMerchantDetailsRequest()
        {
            //Please provide the valid account id in place of dummy number;
            var accountId = "12345678";
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            var getMerchantDetailRequest = new GetMerchantDetailsRequest
            {
                AccountId = accountId,
                MerchantId = "test-merchat-id",
            };
            getMerchantDetailRequest.ApiKey = apiKey;

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes(apiKey)),
                getMerchantDetailRequest.Request.Headers.Authorization!.Parameter);

            Assert.Equal("https://api.sift.com/v3/accounts/" + accountId + "/psp_management/merchants/test-merchat-id",
             getMerchantDetailRequest.Request.RequestUri!.ToString());
        }

        [Fact]
        public void TestChargebackEvent()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var chargeback = new Chargeback
            {
                user_id = "test_dotnet_chargeback_event",
                session_id = sessionId,
                transaction_id = "719637215",
                order_id = "ORDER-123124124",
                chargeback_state = "$lost",
                chargeback_reason = "$duplicate",

                merchant_profile = new MerchantProfile
                {
                    merchant_id = "123",
                    merchant_category_code = "9876",
                    merchant_name = "ABC Merchant",
                    merchant_address = new Address
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
                ach_return_code = "B02"
            };

            // Augment with custom fields
            chargeback.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$chargeback\",\"$user_id\":\"test_dotnet_chargeback_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$order_id\":\"ORDER-123124124\",\"$transaction_id\":\"719637215\",\"$chargeback_state\":\"$lost\",\"$chargeback_reason\":\"$duplicate\"," +
                                 "\"$merchant_profile\":{\"$merchant_id\":\"123\",\"$merchant_category_code\":\"9876\",\"$merchant_name\":\"ABC Merchant\",\"$merchant_address\":" +
                                 "{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\"," +
                                 "\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}}," +
                                 "\"$ach_return_code\":\"B02\",\"foo\":\"bar\"}",
                                 chargeback.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = chargeback
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = chargeback,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestCreateAccountEvent()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createAccount = new CreateAccount
            {
                user_id = "test_dotnet_create_account_event",
                session_id = sessionId,
                user_email = "bill@gmail.com",
                name = "Bill Jones",
                referrer_user_id = "janejane101",
                social_sign_on_type = "$twitter",
                merchant_profile = new MerchantProfile
                {
                    merchant_id = "123",
                    merchant_category_code = "9876",
                    merchant_name = "ABC Merchant",
                    merchant_address = new Address
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
                account_types = new ObservableCollection<string>() { "merchant", "premium" }
            };

            // Augment with custom fields
            createAccount.AddField("foo", "bar");

            Assert.Equal("{\"$type\":\"$create_account\",\"$user_id\":\"test_dotnet_create_account_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$user_email\":\"bill@gmail.com\",\"$name\":\"Bill Jones\",\"$referrer_user_id\":\"janejane101\",\"$social_sign_on_type\":" +
                                 "\"$twitter\",\"$merchant_profile\":{\"$merchant_id\":\"123\",\"$merchant_category_code\":\"9876\",\"$merchant_name\":\"ABC Merchant\"," +
                                 "\"$merchant_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\"," +
                                 "\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}},\"$account_types\":" +
                                 "[\"merchant\",\"premium\"],\"foo\":\"bar\"}",
                                 createAccount.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createAccount
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createAccount,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestUpdateAccountEvent()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var updateAccount = new UpdateAccount
            {
                user_id = "test_dotnet_update_account_event",
                session_id = sessionId,
                user_email = "bill@gmail.com",
                name = "Bill Jones",
                referrer_user_id = "janejane101",
                social_sign_on_type = "$twitter",
                merchant_profile = new MerchantProfile
                {
                    merchant_id = "123",
                    merchant_category_code = "9876",
                    merchant_name = "ABC Merchant",
                    merchant_address = new Address
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
                account_types = new ObservableCollection<string>() { "merchant", "premium" }
            };

            // Augment with custom fields
            updateAccount.AddField("foo", "bar");

            Assert.Equal("{\"$type\":\"$update_account\",\"$user_id\":\"test_dotnet_update_account_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$user_email\":\"bill@gmail.com\",\"$name\":\"Bill Jones\",\"$referrer_user_id\":\"janejane101\",\"$social_sign_on_type\":" +
                                 "\"$twitter\",\"$merchant_profile\":{\"$merchant_id\":\"123\",\"$merchant_category_code\":\"9876\",\"$merchant_name\":\"ABC Merchant\"," +
                                 "\"$merchant_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":" +
                                 "\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}}," +
                                 "\"$account_types\":[\"merchant\",\"premium\"],\"foo\":\"bar\"}",
                                 updateAccount.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateAccount
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateAccount,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestLoginEvent()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var login = new Login
            {
                user_id = "test_dotnet_login_event",
                session_id = sessionId,
                user_email = "bill@gmail.com",
                login_status = "$success",
                ip = "128.148.1.135",
                failure_reason = "$account_unknown",
                social_sign_on_type = "$facebook",
                username = "test_user_name",
                site_country = "US",
                site_domain = "sift.com",
                brand_name = "sift",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                account_types = new ObservableCollection<string>() { "merchant", "premium" }
            };

            Assert.Equal("{\"$type\":\"$login\",\"$user_id\":\"test_dotnet_login_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$user_email\":\"bill@gmail.com\",\"$login_status\":\"$success\",\"$failure_reason\":\"$account_unknown\"," +
                                 "\"$social_sign_on_type\":\"$facebook\",\"$username\":\"test_user_name\",\"$ip\":\"128.148.1.135\",\"$browser\":" +
                                 "{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) " +
                                 "Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":" +
                                 "\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\",\"$account_types\":[\"merchant\",\"premium\"]}",
                                 login.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = login
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = login,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestScorePercentile()
        {
            var sessionId = "sessionId";
            var transaction = new Transaction
            {
                user_id = "vineethk@exalture.com",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = sessionId,
                transaction_type = "$sale",
                transaction_status = "$failure",
                decline_category = "$invalid"
            };

            EventRequest eventRequest = new EventRequest
            {
                Event = transaction,
                AbuseTypes = { "legacy", "payment_abuse" },
                IncludeScorePercentile = true,
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&fields=SCORE_PERCENTILES&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        //UpdateContentComment
        [Fact]
        public void TestUpdateContentComment()
        {
            var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "comment-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                comment = new Comment()
                {
                    body = "Congrats on the new role!",
                    contact_email = "alex_301@domain.com",
                    parent_comment_id = "comment-23407",
                    root_content_id = "listing-12923213",
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "An old picture"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    }
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
            };

            string updateCommentBody = "{\"$type\":\"$update_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"comment-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$comment\":{\"$body\":\"Congrats on the new role!\",\"$contact_email\":\"alex_301@domain.com\",\"$parent_comment_id\":\"comment-23407\",\"$root_content_id\":\"listing-12923213\",\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"An old picture\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}]},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"}";

            Assert.Equal(updateCommentBody, updateContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        //UpdateContentListing
        [Fact]
        public void TestUpdateContentListing()
        {
            var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "listing-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                listing = new Listing()
                {
                    subject = "2 Bedroom Apartment for Rent",
                    body = "Capitol Hill Seattle brand new condo. 2 bedrooms and 1 full bath.",
                    contact_email = "alex_301@domain.com",
                    contact_address = new Address()
                    {
                        name = "Bill Jones",
                        address_1 = "abc",
                        address_2 = "xyz",
                        city = "New London",
                        region = "New Hampshire",
                        country = "US",
                        zipcode = "03257",
                        phone = "1-415-555-6041"


                    },
                    locations = new ObservableCollection<Address>()
                    {
                        new Address()
                        {
                            name = "Bill Jones",
                            address_1 = "abc",
                            address_2 = "xyz",
                            city = "Seattle",
                            region = "Washington",
                            country = "US",
                            zipcode = "98112",
                            phone = "1-415-555-6041"
                        },
                        new Address()
                        {
                            name = "Bill Jones"
                        }

                    },
                    listed_items = new ObservableCollection<Item>()
                    {
                        new Item()
                        {
                            item_id = "0cc175b9c0f1b6a831c399e269772661",
                            product_title = "https://www.domain.com/file.png",
                            price = 2950000000,
                            currency_code = "USD",
                            quantity = 1,
                            upc = "6786211451001",
                            sku = "abc",
                            isbn = "0446576220",
                            brand = "abc",
                            manufacturer = "abc",
                            category = "abc",
                            tags = new ObservableCollection<string>() { "heat","washer/dryer" },
                            color = "ab",
                            size = "ab"
                        }
                    },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "Billy's picture"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
                    expiration_time = 1549063157000
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
            };

            string updateListingBody = "{\"$type\":\"$update_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"listing-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$listing\":{\"$subject\":\"2 Bedroom Apartment for Rent\",\"$body\":\"Capitol Hill Seattle brand new condo. 2 bedrooms and 1 full bath.\",\"$contact_email\":\"alex_301@domain.com\",\"$contact_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"abc\",\"$address_2\":\"xyz\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6041\"},\"$locations\":[{\"$name\":\"Bill Jones\",\"$address_1\":\"abc\",\"$address_2\":\"xyz\",\"$city\":\"Seattle\",\"$region\":\"Washington\",\"$country\":\"US\",\"$zipcode\":\"98112\",\"$phone\":\"1-415-555-6041\"},{\"$name\":\"Bill Jones\"}],\"$listed_items\":[{\"$item_id\":\"0cc175b9c0f1b6a831c399e269772661\",\"$product_title\":\"https://www.domain.com/file.png\",\"$price\":2950000000,\"$currency_code\":\"USD\",\"$quantity\":1,\"$upc\":\"6786211451001\",\"$sku\":\"abc\",\"$isbn\":\"0446576220\",\"$brand\":\"abc\",\"$manufacturer\":\"abc\",\"$category\":\"abc\",\"$tags\":[\"heat\",\"washer/dryer\"],\"$color\":\"ab\",\"$size\":\"ab\"}],\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"Billy's picture\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}],\"$expiration_time\":1549063157000},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"}";

            Assert.Equal(updateListingBody, updateContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        //UpdateContentMessage
        [Fact]
        public void TestUpdateContentMessage()
        {
            var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "message-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                message = new Message()
                {
                    body = "Lets meet at 5pm",
                    contact_email = "alex_301@domain.com",
                    root_content_id = "listing-123",
                    recipient_user_ids = new ObservableCollection<string>() { "fy9h989sjphh71" },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "My hike today!"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
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
            };

            string updateMessageBody = "{\"$type\":\"$update_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"message-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$message\":{\"$body\":\"Lets meet at 5pm\",\"$contact_email\":\"alex_301@domain.com\",\"$root_content_id\":\"listing-123\",\"$recipient_user_ids\":[\"fy9h989sjphh71\"],\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"My hike today!\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}]},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"}";

            Assert.Equal(updateMessageBody, updateContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        //UpdateContentPost
        [Fact]
        public void TestUpdateContentPost()
        {
            var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "post-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                post = new Post()
                {
                    subject = "My new apartment!",
                    body = "Moved into my new apartment yesterday.",
                    contact_email = "alex_301@domain.com",
                    contact_address = new Address()
                    {
                        name = "Bill Jones",
                        address_1 = "abc",
                        address_2 = "xyz",
                        city = "New London",
                        region = "New Hampshire",
                        country = "US",
                        zipcode = "03257",
                        phone = "1-415-555-6041"
                    },
                    locations = new ObservableCollection<Address>()
                    {
                        new Address()
                        {
                            name = "Bill Jones",
                            address_1 = "abc",
                            address_2 = "xyz",
                            city = "Seattle",
                            region = "Washington",
                            country = "US",
                            zipcode = "98112",
                            phone = "1-415-555-6041"
                        },
                        new Address()
                        {
                            name = "Bill Jones"
                        }

                    },
                    categories = new ObservableCollection<string>() { "Personal" },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "View from the window!"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
                    expiration_time = 1549063157000
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
            };

            string updatePostBody = "{\"$type\":\"$update_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"post-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$post\":{\"$subject\":\"My new apartment!\",\"$body\":\"Moved into my new apartment yesterday.\",\"$contact_email\":\"alex_301@domain.com\",\"$contact_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"abc\",\"$address_2\":\"xyz\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6041\"},\"$locations\":[{\"$name\":\"Bill Jones\",\"$address_1\":\"abc\",\"$address_2\":\"xyz\",\"$city\":\"Seattle\",\"$region\":\"Washington\",\"$country\":\"US\",\"$zipcode\":\"98112\",\"$phone\":\"1-415-555-6041\"},{\"$name\":\"Bill Jones\"}],\"$categories\":[\"Personal\"],\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"View from the window!\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}],\"$expiration_time\":1549063157000},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"}";

            Assert.Equal(updatePostBody, updateContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        //UpdateContentProfile
        [Fact]
        public void TestUpdateContentProfile()
        {
            var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "listing-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                profile = new Profile()
                {
                    body = "Hi! My name is Alex and I just moved to New London!",
                    contact_email = "alex_301@domain.com",
                    contact_address = new Address()
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
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description = "Alexs picture"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
                    categories = new ObservableCollection<string>() { "Friends", "Long-term dating" }
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
            };

            string updateProfileBody = "{\"$type\":\"$update_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"listing-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$profile\":{\"$body\":\"Hi! My name is Alex and I just moved to New London!\",\"$contact_email\":\"alex_301@domain.com\",\"$contact_address\":{\"$name\":\"Alex Smith\",\"$address_1\":\"abc\",\"$address_2\":\"xyz\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6041\"},\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"Alexs picture\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}],\"$categories\":[\"Friends\",\"Long-term dating\"]},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"}";

            Assert.Equal(updateProfileBody, updateContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        //UpdateContent.Review
        [Fact]
        public void TestUpdateContentReview()
        {
            var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "review-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                review = new Review()
                {
                    subject = "Amazing Tacos!",
                    body = "I ate the tacos.",
                    contact_email = "alex_301@domain.com",
                    locations = new ObservableCollection<Address>()
                    {
                        new Address()
                        {
                            name = "Bill Jones",
                            address_1 = "abc",
                            address_2 = "xyz",
                            city = "Seattle",
                            region = "Washington",
                            country = "US",
                            zipcode = "98112",
                            phone = "1-415-555-6041"
                        },
                        new Address()
                        {
                            name = "Bill Jones"
                        }

                    },
                    item_reviewed = new Item()
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
                        size = "6",
                    },

                    reviewed_content_id = "listing-234234",
                    rating = 4.5,
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description = "Calamari tacos."
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
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
            };

            string updateReviewBody = "{\"$type\":\"$update_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"review-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$review\":{\"$subject\":\"Amazing Tacos!\",\"$body\":\"I ate the tacos.\",\"$contact_email\":\"alex_301@domain.com\",\"$locations\":[{\"$name\":\"Bill Jones\",\"$address_1\":\"abc\",\"$address_2\":\"xyz\",\"$city\":\"Seattle\",\"$region\":\"Washington\",\"$country\":\"US\",\"$zipcode\":\"98112\",\"$phone\":\"1-415-555-6041\"},{\"$name\":\"Bill Jones\"}],\"$item_reviewed\":{\"$item_id\":\"B004834GQO\",\"$product_title\":\"The Slanket Blanket-Texas Tea\",\"$price\":39990000,\"$currency_code\":\"USD\",\"$upc\":\"6786211451001\",\"$sku\":\"004834GQ\",\"$isbn\":\"0446576220\",\"$brand\":\"Slanket\",\"$manufacturer\":\"Slanket\",\"$category\":\"Blankets & Throws\",\"$tags\":[\"Awesome\",\"Wintertime specials\"],\"$color\":\"Texas Tea\",\"$size\":\"6\"},\"$reviewed_content_id\":\"listing-234234\",\"$rating\":4.5,\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"Calamari tacos.\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}]},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"}";

            Assert.Equal(updateReviewBody, updateContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }


        [Fact]
        public void TestAdditemtocartEvent()
        {
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
                user_email = "billjones1@example.com",
                verification_phone_number = "+123456789012"
            };

            string addItemToCartBody = "{\"$type\":\"$add_item_to_cart\",\"$user_id\":\"billy_jones_301\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\",\"$item\":{\"$item_id\":\"B004834GQO\",\"$product_title\":\"The Slanket Blanket-Texas Tea\",\"$price\":39990000,\"$currency_code\":\"USD\",\"$quantity\":16,\"$upc\":\"6786211451001\",\"$sku\":\"004834GQ\",\"$isbn\":\"0446576220\",\"$brand\":\"Slanket\",\"$manufacturer\":\"Slanket\",\"$category\":\"Blankets & Throws\",\"$tags\":[\"Awesome\",\"Wintertime specials\"],\"$color\":\"Texas Tea\"},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\",\"$user_email\":\"billjones1@example.com\",\"$verification_phone_number\":\"+123456789012\"}";

            Assert.Equal(addItemToCartBody, addItemToCart.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = addItemToCart
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = addItemToCart,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestAddPromotionEvent()
        {
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
                user_email = "billjones1@example.com",
                verification_phone_number = "+123456789012"
            };

            string addPromotionbody = "{\"$type\":\"$add_promotion\",\"$user_id\":\"billy_jones_301\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\",\"$promotions\":[{\"$promotion_id\":\"NewCustomerReferral2016\",\"$status\":\"$success\",\"$failure_reason\":\"$already_used\",\"$description\":\"$5 off your first 5 rides\",\"$referrer_user_id\":\"elon-m93903\",\"$discount\":{\"$percentage_off\":0.2,\"$amount\":5000000,\"$currency_code\":\"USD\",\"$minimum_purchase_amount\":50000000},\"$credit_point\":{\"$amount\":5000,\"$credit_point_type\":\"character xp points\"}},{\"$promotion_id\":\"NewCustomerReferral2016\"}],\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\",\"$user_email\":\"billjones1@example.com\",\"$verification_phone_number\":\"+123456789012\"}";

            Assert.Equal(addPromotionbody, addPromotion.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = addPromotion
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = addPromotion,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestContentStatusEvent()
        {
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
                user_email = "billjones1@example.com",
                verification_phone_number = "+123456789012"
            };

            string contentStatusbody = "{\"$type\":\"$content_status\",\"$user_id\":\"billy_jones_301\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\",\"$content_id\":\"9671500641\",\"$status\":\"$paused\",\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\",\"$user_email\":\"billjones1@example.com\",\"$verification_phone_number\":\"+123456789012\"}";

            Assert.Equal(contentStatusbody, contentStatus.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = contentStatus
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = contentStatus,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestFlagContentEvent()
        {
            var flagContent = new FlagContent
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                content_id = "9671500641",
                flagged_by = "jamieli89",
                reason = "$toxic",
                user_email = "billjones1@example.com",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                verification_phone_number = "+123456789012"
            };

            string flagcontentbody = "{\"$type\":\"$flag_content\",\"$user_id\":\"billy_jones_301\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\",\"$content_id\":\"9671500641\",\"$flagged_by\":\"jamieli89\",\"$reason\":\"$toxic\",\"$user_email\":\"billjones1@example.com\",\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$verification_phone_number\":\"+123456789012\"}";

            Assert.Equal(flagcontentbody, flagContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = flagContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = flagContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestRemoveItemFromCartEvent()
        {
            var removeItemFromCart = new RemoveItemFromCart
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
                    quantity = 2
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
                user_email = "billjones1@example.com",
                verification_phone_number = "+123456789012"
            };

            string removeitemfromcartbody = "{\"$type\":\"$remove_item_from_cart\",\"$user_id\":\"billy_jones_301\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\",\"$item\":{\"$item_id\":\"B004834GQO\",\"$product_title\":\"The Slanket Blanket-Texas Tea\",\"$price\":39990000,\"$currency_code\":\"USD\",\"$quantity\":2,\"$upc\":\"6786211451001\",\"$sku\":\"004834GQ\",\"$isbn\":\"0446576220\",\"$brand\":\"Slanket\",\"$manufacturer\":\"Slanket\",\"$category\":\"Blankets & Throws\",\"$tags\":[\"Awesome\",\"Wintertime specials\"],\"$color\":\"Texas Tea\"},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\",\"$user_email\":\"billjones1@example.com\",\"$verification_phone_number\":\"+123456789012\"}";

            Assert.Equal(removeitemfromcartbody, removeItemFromCart.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = removeItemFromCart
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = removeItemFromCart,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestCreateOrderEvent()
        {
            var createOrder = new CreateOrder
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                order_id = "ORDER-28168441",
                user_email = "billjones1@example.com",
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
                shipping_carrier = "UPS",
                shipping_tracking_numbers = new ObservableCollection<string>() { "1Z204E380338943508", "1Z204E380338943509" },
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
            string createorderbody = "{\"$type\":\"$create_order\",\"$user_id\":\"billy_jones_301\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\",\"$order_id\":\"ORDER-28168441\",\"$user_email\":\"billjones1@example.com\",\"$amount\":115940000,\"$currency_code\":\"USD\",\"$billing_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6041\"},\"$payment_methods\":[{\"$payment_type\":\"$credit_card\",\"$payment_gateway\":\"$braintree\",\"$card_bin\":\"542486\",\"$card_last4\":\"4444\"},{\"$payment_type\":\"$credit_card\"}],\"$shipping_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6041\"},\"$expedited_shipping\":true,\"$items\":[{\"$item_id\":\"12344321\",\"$product_title\":\"Microwavable Kettle Corn: Original Flavor\",\"$price\":4990000,\"$currency_code\":\"USD\",\"$quantity\":4,\"$upc\":\"097564307560\",\"$sku\":\"03586005\",\"$isbn\":\"0446576220\",\"$brand\":\"Peters Kettle Corn\",\"$manufacturer\":\"Peters Kettle Corn\",\"$category\":\"Food and Grocery\",\"$tags\":[\"Popcorn\",\"Snacks\",\"On Sale\"],\"$color\":\"Texas Tea\"},{\"$item_id\":\"12344321\"}],\"$seller_user_id\":\"slinkys_emporium\",\"$promotions\":[{\"$promotion_id\":\"FirstTimeBuyer\",\"$status\":\"$success\",\"$description\":\"$5 off\",\"$discount\":{\"$amount\":5000000,\"$currency_code\":\"USD\",\"$minimum_purchase_amount\":25000000}}],\"$shipping_method\":\"$physical\",\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\",\"$ordered_from\":{\"$store_id\":\"123\",\"$store_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}},\"$verification_phone_number\":\"+123456789012\",\"$shipping_carrier\":\"UPS\",\"$shipping_tracking_numbers\":[\"1Z204E380338943508\",\"1Z204E380338943509\"]}";

            Assert.Equal(createorderbody, createOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                            Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestUpdateOrderEvent()
        {
            var updateOrder = new UpdateOrder
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                order_id = "ORDER-28168441",
                user_email = "billjones1@example.com",
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
                shipping_carrier = "UPS",
                shipping_tracking_numbers = new ObservableCollection<string>() { "1Z204E380338943508", "1Z204E380338943509" },
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
                },
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
            string updateorderbody = "{\"$type\":\"$update_order\",\"$user_id\":\"billy_jones_301\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\",\"$order_id\":\"ORDER-28168441\",\"$user_email\":\"billjones1@example.com\",\"$amount\":115940000,\"$currency_code\":\"USD\",\"$billing_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6041\"},\"$payment_methods\":[{\"$payment_type\":\"$credit_card\",\"$payment_gateway\":\"$braintree\",\"$card_bin\":\"542486\",\"$card_last4\":\"4444\"},{\"$payment_type\":\"$credit_card\"}],\"$shipping_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6041\"},\"$expedited_shipping\":true,\"$items\":[{\"$item_id\":\"12344321\",\"$product_title\":\"Microwavable Kettle Corn: Original Flavor\",\"$price\":4990000,\"$currency_code\":\"USD\",\"$quantity\":4,\"$upc\":\"097564307560\",\"$sku\":\"03586005\",\"$isbn\":\"0446576220\",\"$brand\":\"Peters Kettle Corn\",\"$manufacturer\":\"Peters Kettle Corn\",\"$category\":\"Food and Grocery\",\"$tags\":[\"Popcorn\",\"Snacks\",\"On Sale\"],\"$color\":\"Texas Tea\"},{\"$item_id\":\"12344321\"}],\"$seller_user_id\":\"slinkys_emporium\",\"$promotions\":[{\"$promotion_id\":\"FirstTimeBuyer\",\"$status\":\"$success\",\"$description\":\"$5 off\",\"$discount\":{\"$amount\":5000000,\"$currency_code\":\"USD\",\"$minimum_purchase_amount\":25000000}}],\"$shipping_method\":\"$physical\",\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\",\"$ordered_from\":{\"$store_id\":\"123\",\"$store_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}},\"$verification_phone_number\":\"+123456789012\",\"$shipping_carrier\":\"UPS\",\"$shipping_tracking_numbers\":[\"1Z204E380338943508\",\"1Z204E380338943509\"],\"$merchant_profile\":{\"$merchant_id\":\"AX527123\",\"$merchant_category_code\":\"1234\",\"$merchant_name\":\"Dream Company\",\"$merchant_address\":{\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}}}";

            Assert.Equal(updateorderbody, updateOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                            Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }


        [Fact]
        public void TestCreateContentCommentEvent()
        {
            var createContent = new CreateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "comment-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                comment = new Comment()
                {
                    body = "Congrats on the new role!",
                    contact_email = "alex_301@domain.com",
                    parent_comment_id = "comment-23407",
                    root_content_id = "listing-12923213",
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "An old picture"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    }
                },
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
            };

            string createcontentbody = "{\"$type\":\"$create_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"comment-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$comment\":{\"$body\":\"Congrats on the new role!\",\"$contact_email\":\"alex_301@domain.com\",\"$parent_comment_id\":\"comment-23407\",\"$root_content_id\":\"listing-12923213\",\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"An old picture\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}]},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"}}";

            Assert.Equal(createcontentbody, createContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestVerificationEvent()
        {
            var sessionId = "sessionId";
            var verification = new Verification
            {
                user_id = "billy_jones_301",
                session_id = sessionId,
                status = "$pending",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-GB",
                    content_language = "en-US"
                },
                verified_event = "$login",
                verified_entity_id = "123",
                verification_type = "$sms",
                verified_value = "14155551212",
                reason = "$user_setting",
                brand_name = "xyz",
                site_country = "AU",
                site_domain = "somehost.example.com"
            };

            Assert.Equal("{\"$type\":\"$verification\",\"$user_id\":\"billy_jones_301\",\"$session_id\":\"sessionId\",\"$status\":\"$pending\",\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-GB\",\"$content_language\":\"en-US\"},\"$verified_event\":\"$login\",\"$verified_entity_id\":\"123\",\"$verification_type\":\"$sms\",\"$verified_value\":\"14155551212\",\"$reason\":\"$user_setting\",\"$brand_name\":\"xyz\",\"$site_country\":\"AU\",\"$site_domain\":\"somehost.example.com\"}",
                                 verification.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = verification
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = verification,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestUpdatePasswordEvent()
        {
            var updatePassword = new UpdatePassword
            {
                user_id = "billy_jones_301",
                reason = "$forced_reset",
                status = "$success",
                session_id = "gigtleqddo84l8cm15qe4il",
                ip = "128.148.1.135",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },                
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
                user_email = "billjones1@example.com",
                verification_phone_number = "+123456789012"
            };

            string updatePasswordBody = "{\"$type\":\"$update_password\",\"$user_id\":\"billy_jones_301\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\",\"$reason\":\"$forced_reset\",\"$status\":\"$success\",\"$ip\":\"128.148.1.135\",\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\",\"$user_email\":\"billjones1@example.com\",\"$verification_phone_number\":\"+123456789012\"}";

            Assert.Equal(updatePasswordBody, updatePassword.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updatePassword
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updatePassword,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestGetScoreRequest()
        {
            ScoreRequest scoreRequest = new ScoreRequest
            {
                UserId = "123",
                ApiKey = "345",
                AbuseTypes = new List<string>() { "payment_abuse", "promotion_abuse" },
                IncludeScorePercentile = true
            };

            Assert.Equal("https://api.sift.com/v205/users/123/score?api_key=345&abuse_types=payment_abuse,promotion_abuse&fields=SCORE_PERCENTILES",
                        Uri.UnescapeDataString(scoreRequest.Request.RequestUri!.ToString()));
        }

        //TestWarnings
        [Fact]
        public void TestWarnings()
        {
            var sessionId = "sessionId";
            var transaction = new Transaction
            {
                user_id = "vineethk@exalture.com",
                amount = 1000000000000L,
                currency_code = "@#$",
                session_id = sessionId,
                transaction_type = "$sale",
                transaction_status = "$failure",
                decline_category = "$invalid"
            };

            EventRequest eventRequest = new EventRequest
            {
                Event = transaction,
                ReturnWarnings = true
            };

            Assert.Equal("https://api.sift.com/v205/events?fields=warnings",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

    }

}
