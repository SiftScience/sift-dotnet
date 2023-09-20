using Microsoft.Extensions.Configuration;
using System.IO;

namespace Test.Integration.Net7.Uitlities
{
    internal class EnvironmentVariable
    {
        private readonly IConfiguration configuration;

        public EnvironmentVariable()
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }

        public string ApiKey
        {
            get
            {
                return configuration["Values:ApiKey"];
            }
        }
        public string AccountId
        {
            get
            {
                return configuration["Values:AccountId"];
            }
        }
        public string MerchantId
        {
            get
            {
                return configuration["Values:MerchantId"];
            }
        }
        public string Id
        {
            get
            {
                return configuration["Values:Id"];
            }
        }

        public string UserId
        {
            get
            {
                return configuration["Values:UserId"];
            }
        }

        public string WorkflowRunId
        {
            get
            {
                return configuration["Values:WorkflowRunId"];
            }
        }

        public string SendTo
        {
            get
            {
                return configuration["Values:SendTo"];
            }

        }

        public string user_id
        {
            get
            {
                return configuration["Values:user_id"];
            }

        }

        public string session_id
        {
            get
            {
                return configuration["Values:session_id"];
            }

        }

        public string referrer_user_id
        {
            get
            {
                return configuration["Values:referrer_user_id"];
            }

        }

        public string merchant_id
        {
            get
            {
                return configuration["Values:merchant_id"];
            }

        }

        public string user_email
        {
            get
            {
                return configuration["Values:user_email"];
            }

        }
        
        public string item_id
        {
            get
            {
                return configuration["Values:item_id"];
            }

        }

        public string order_id
        {
            get
            {
                return configuration["Values:order_id"];
            }

        }

        public string transaction_id
        {
            get
            {
                return configuration["Values:transaction_id"];
            }

        }

        public string content_id
        {
            get
            {
                return configuration["Values:content_id"];
            }

        }

        public string contact_email
        {
            get
            {
                return configuration["Values:contact_email"];
            }

        }

        public string parent_comment_id
        {
            get
            {
                return configuration["Values:parent_comment_id"];
            }

        }

        public string root_content_id
        {
            get
            {
                return configuration["Values:root_content_id"];
            }

        }

        public string md5_hash
        {
            get
            {
                return configuration["Values:md5_hash"];
            }

        }

        public string flagged_by
        {
            get
            {
                return configuration["Values:flagged_by"];
            }

        }
    }
}
