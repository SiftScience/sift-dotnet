using System;
using Xunit;
using Sift;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
                         applyDecisionRequest.Request.RequestUri.ToString());

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes("key")),
                         applyDecisionRequest.Request.Headers.Authorization.Parameter);

        }

        [Fact]
        public void TestEventRequest()
        {
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_booking_with_all_fields",
                order_id = "oid",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = "gigtleqddo84l8cm15qe4il",
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
                        tags = new ObservableCollection<string>() { "tag-123", "tag-321" }
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
                         "\"$session_id\":\"gigtleqddo84l8cm15qe4il\",\"$order_id\":\"oid\",\"$user_email\":\"bill@gmail.com\"," +
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

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                         Uri.UnescapeDataString(eventRequest.Request.RequestUri.ToString()));
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
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_browser_field",
                order_id = "oid",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = "gigtleqddo84l8cm15qe4il",
                user_email = "bill@gmail.com",
                browser = new Browser
                {
                    user_agent       = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language  = "en-US",
                    content_language = "en-GB"
                }
            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_browser_field\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\"," +
                         "\"$order_id\":\"oid\",\"$user_email\":\"bill@gmail.com\",\"$amount\":1000000000000,\"$currency_code\":\"USD\"," +
                         "\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\"," +
                         "\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"foo\":\"bar\"}",
                         createOrder.ToJson());


            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                         Uri.UnescapeDataString(eventRequest.Request.RequestUri.ToString()));
        }

        [Fact]
        public void TestTransactionEvent()
        {
            var transaction = new Transaction
            {
                user_id = "test_dotnet_transaction_event",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = "gigtleqddo84l8cm15qe4il",
                transaction_type = "$sale",
                transaction_status = "$failure",
                decline_category = "$invalid"
            };

            // Augment with custom fields
            transaction.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$transaction\",\"$user_id\":\"test_dotnet_transaction_event\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\"," +
                                 "\"$transaction_type\":\"$sale\",\"$transaction_status\":\"$failure\",\"$amount\":1000000000000,\"$currency_code\":\"USD\"," +
                                 "\"$decline_category\":\"$invalid\",\"foo\":\"bar\"}", transaction.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = transaction
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri.ToString());

            eventRequest = new EventRequest
            {
                Event = transaction,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri.ToString()));
        }

        [Fact]
        public void TestCreateOrderEventWithSepaPaymentMethodFields()
        {
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_sepa_payment_method_fields",
                session_id = "gigtleqddo84l8cm15qe4il",
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
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_sepa_payment_method_fields\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\"," +
                                 "\"$order_id\":\"12345\",\"$payment_methods\":[{\"$payment_type\":\"$sepa_instant_credit\",\"$shortened_iban_first6\":\"FR7630\"," +
                                 "\"$shortened_iban_last4\":\"1234\",\"$sepa_direct_debit_mandate\":true}],\"foo\":\"bar\"}",
                                 createOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri.ToString()));
        }

        [Fact]
        public void TestCreateOrderEventWithMerchantProfileField()
        {
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_merchant_profile_field",
                session_id = "gigtleqddo84l8cm15qe4il",
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
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_merchant_profile_field\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\"," +
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

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };
            
            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri.ToString()));
        }

        [Fact]
        public void TestTransactionEventWithFintechFields()
        {
            var transaction = new Transaction
            {
                user_id = "test_dotnet_transaction_event",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = "gigtleqddo84l8cm15qe4il",
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
            Assert.Equal("{\"$type\":\"$transaction\",\"$user_id\":\"test_dotnet_transaction_event\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\"," +
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

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri.ToString());

            eventRequest = new EventRequest
            {
                Event = transaction,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri.ToString()));
        }
    }
}
