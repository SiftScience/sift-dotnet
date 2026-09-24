using System;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    // NEB-4783 QA self-serve check, section D (client libraries).
    //
    // IMPORTANT: none of the 6 client library PRs (Java, .NET, Python, PHP, Ruby) are
    // merged or released yet. This only works against a local checkout of this branch -
    // installing the published Sift NuGet package will NOT have these fields.
    //
    // How to run: set SIFT_QA_API_KEY to the shared QA prod key (same one used for the
    // Postman collection in section A - find it in Console under the name
    // "neb-4783-structured-fields-qa"), then either:
    //   - run all 7:  SIFT_QA_API_KEY=... dotnet test --filter StructuredFieldsSelfServeCheck
    //   - or open this file in Rider/Visual Studio and run individual [Fact] methods,
    //     which also lets you use IntelliSense to browse what's available - see the IDE
    //     exploration note below.
    //
    // What this proves:
    //   1. Seven test methods below, one per event type in the attachment matrix, each
    //      reusing the exact payload shapes already verified in section A's Postman
    //      collection - and going through the real Sift.Client.SendAsync path (not a
    //      hand-rolled HTTP call), confirming the .NET client sends the new fields
    //      correctly end to end, not just that the types compile.
    //   2. IDE exploration: open this file in Rider or Visual Studio, place your cursor
    //      after "new Sift.CreateAccount {" and trigger IntelliSense - you'll see kyc,
    //      geo, bot_identification, nationality, year_of_birth in the member list.
    //      Do the same after "new Sift.Login {" - kyc is simply not there, because the
    //      property does not exist on that generated type.
    //   3. TryToAttachKycToLogin() below - commented out on purpose. Uncomment it and
    //      this file will FAIL TO COMPILE with "'Login' does not contain a definition
    //      for 'kyc'" - the same point as #2, proven by the compiler.
    public class StructuredFieldsSelfServeCheck
    {
        const string UserId = "qa_structured_fields_2026";
        const string OrderId = "qa_order_001";

        static Sift.Client Client()
        {
            var apiKey = Environment.GetEnvironmentVariable("SIFT_QA_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException(
                    "Set SIFT_QA_API_KEY first - see the comment at the top of this file.");
            }
            return new Sift.Client(apiKey);
        }

        static async Task SendAndVerify(Sift.SiftEvent evt)
        {
            Console.WriteLine("REQUEST_JSON: " + evt.ToJson());
            var response = await Client().SendAsync(new Sift.EventRequest { Event = evt });
            Console.WriteLine("STATUS: " + response.Status);
            Console.WriteLine("ERROR_MESSAGE: " + response.ErrorMessage);
            Assert.Equal(0, response.Status);
        }

        [Fact]
        public async Task CreateAccount_AllFiveFields()
        {
            await SendAndVerify(new Sift.CreateAccount
            {
                user_id = UserId,
                nationality = "US",
                year_of_birth = 1985,
                kyc = new Sift.Kyc { names_match = true, kyc_level = "$basic", bin_nationality_match = true, provider = "lexisnexis" },
                geo = new Sift.Geo { uuid = "gc-abc-123", provider = "geocomply" },
                bot_identification = new Sift.BotIdentification { result = "$human", provider = "datadome" }
            });
        }

        [Fact]
        public async Task UpdateAccount_AllFiveFields()
        {
            await SendAndVerify(new Sift.UpdateAccount
            {
                user_id = UserId,
                nationality = "US",
                year_of_birth = 1985,
                kyc = new Sift.Kyc { names_match = true, kyc_level = "$full", bin_nationality_match = true, provider = "lexisnexis" },
                geo = new Sift.Geo { uuid = "gc-abc-123", provider = "geocomply" },
                bot_identification = new Sift.BotIdentification { result = "$human", provider = "datadome" }
            });
        }

        [Fact]
        public async Task Login_GeoAndBotIdentificationOnly()
        {
            // No kyc here on purpose - see the class-level comment and
            // TryToAttachKycToLogin() below for why that's not just a choice in this
            // test, it's not possible at all.
            await SendAndVerify(new Sift.Login
            {
                user_id = UserId,
                login_status = "$success",
                geo = new Sift.Geo { uuid = "gc-abc-123", provider = "geocomply" },
                bot_identification = new Sift.BotIdentification { result = "$human", provider = "datadome" }
            });
        }

        [Fact]
        public async Task Transaction_KycGeoAndBotIdentification()
        {
            await SendAndVerify(new Sift.Transaction
            {
                user_id = UserId,
                amount = 15230000,
                currency_code = "USD",
                kyc = new Sift.Kyc { names_match = true, kyc_level = "$full", bin_nationality_match = false, provider = "prove" },
                geo = new Sift.Geo { uuid = "gc-abc-123", provider = "geocomply" },
                bot_identification = new Sift.BotIdentification { result = "$human", provider = "human_security" }
            });
        }

        [Fact]
        public async Task CreateOrder_KycGeoAndBotIdentification()
        {
            await SendAndVerify(new Sift.CreateOrder
            {
                user_id = UserId,
                order_id = OrderId,
                kyc = new Sift.Kyc { names_match = true, kyc_level = "$basic", bin_nationality_match = true, provider = "lexisnexis" },
                geo = new Sift.Geo { uuid = "gc-abc-123", provider = "geocomply" },
                bot_identification = new Sift.BotIdentification { result = "$human", provider = "datadome" }
            });
        }

        [Fact]
        public async Task UpdateOrder_KycGeoAndBotIdentification()
        {
            await SendAndVerify(new Sift.UpdateOrder
            {
                user_id = UserId,
                order_id = OrderId,
                kyc = new Sift.Kyc { names_match = true, kyc_level = "$basic", bin_nationality_match = true, provider = "lexisnexis" },
                geo = new Sift.Geo { uuid = "gc-abc-123", provider = "geocomply" },
                bot_identification = new Sift.BotIdentification { result = "$human", provider = "datadome" }
            });
        }

        [Fact]
        public async Task Verification_KycOnly()
        {
            // No geo/bot_identification here on purpose - $verification only supports
            // $kyc per the attachment matrix.
            await SendAndVerify(new Sift.Verification
            {
                user_id = UserId,
                verification_type = "$kyc",
                status = "$success",
                kyc = new Sift.Kyc { names_match = true, kyc_level = "$basic", bin_nationality_match = false, provider = "lexisnexis" }
            });
        }

        // Uncomment this method to see the compile-time safety point for yourself.
        // Sift.Login has no kyc property, so this will not build.
        //
        // public void TryToAttachKycToLogin()
        // {
        //     var login = new Sift.Login { kyc = new Sift.Kyc { names_match = true } };
        // }
    }
}
