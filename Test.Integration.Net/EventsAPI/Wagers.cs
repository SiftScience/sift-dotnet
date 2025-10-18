using Sift;
using System;
using System.Diagnostics;
using Test.Integration.Net.Uitlities;
using Xunit;

namespace Test.Integration.Net.EventsAPI
{
    public class Wagers
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string UserId;
        private readonly string WagerId;


        public Wagers()
        {
            ApiKey = environmentVariable.ApiKey;
            UserId = environmentVariable.user_id;

            long nowMills = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            WagerId = "wager-" + nowMills;
        }

        [Fact]
        public void WagerTest()
        {
            var sift = new Client(ApiKey);
            var wager = new Wager
            {
                user_id = UserId,
                wager_id = WagerId,
                wager_type = "$parlay",
                wager_status = "$accept",
                amount = 5000,
                currency_code = "EUR",
                exchange_rate = new ExchangeRate
                {
                    quote_currency_code = "USD",
                    rate = 1.14
                },
                minimum_wager_amount = 100L,
                wager_event_type = "NBA",
                wager_event_name = "Bulls-Lakers",
                wager_event_id = "nfl-23-11100"
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = wager
            };

            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("0", res.Status.ToString()); // Check for successful response
        }

    }
}
