using System;
using Xunit;
using Sift;
using System.Collections.Generic;
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
            var createOrder = new Sift.CreateOrder
            {
                user_id = "gary",
                order_id = "oid",
                amount = 1000000,
                currency_code = "USD",
                billing_address = new Address
                {
                    name = "gary",
                    city = "san francisco"
                },
                app = new App
                {
                    app_name = "app",
                    app_version = "1.0"
                }
            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");

            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"gary\"," +
                         "\"$order_id\":\"oid\",\"$amount\":1000000,\"$currency_code\":" +
                         "\"USD\",\"$billing_address\":{\"$name\":\"gary\",\"$city\":" +
                         "\"san francisco\"},\"$app\":{\"$app_name\":\"app\"," +
                         "\"$app_version\":\"1.0\"},\"foo\":\"bar\"}",
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
    }
}
