﻿using System;
using System.Configuration;

namespace Test.Integration.NetFx48.Uitlities
{
    internal class EnvironmentVariable
    {

        public string ApiKey
        {
            get
            {
                var envAPI_KEY = Environment.GetEnvironmentVariable("SIFT_API_KEY");
                if (ConfigurationManager.AppSettings["ApiKey"] == "API_KEY")
                {
                    throw new Exception("Specify API Key");
                }
                return envAPI_KEY ?? ConfigurationManager.AppSettings["ApiKey"];
            }
        }
        public string AccountId
        {
            get
            {
                var envACCOUNT_ID = Environment.GetEnvironmentVariable("SIFT_ACCOUNT_ID");
                if (ConfigurationManager.AppSettings["AccountId"] == "ACCOUNT_ID")
                {
                    throw new Exception("Specify ACCOUNT ID");
                }
                return envACCOUNT_ID ?? ConfigurationManager.AppSettings["AccountId"];
            }
        }

        public string MerchantId
        {
            get
            {
                return ConfigurationManager.AppSettings["MerchantId"];
            }
        }

        public string Id
        {
            get
            {
                return ConfigurationManager.AppSettings["Id"];
            }
        }

        public string UserId
        {
            get
            {
                return ConfigurationManager.AppSettings["UserId"];
            }
        }

        public string WorkflowRunId
        {
            get
            {
                return ConfigurationManager.AppSettings["WorkflowRunId"];
            }
        }

        public string SendTo
        {
            get
            {
                return ConfigurationManager.AppSettings["SendTo"];
            }
        }

        public string user_id
        {
            get
            {
                return ConfigurationManager.AppSettings["user_id"];
            }
        }

        public string session_id
        {
            get
            {
                return ConfigurationManager.AppSettings["session_id"];
            }
        }
        public string user_email
        {
            get
            {
                return ConfigurationManager.AppSettings["user_email"];
            }
        }

        public string referrer_user_id
        {
            get
            {
                return ConfigurationManager.AppSettings["referrer_user_id"];
            }
        }

        public string promotion_id
        {
            get
            {
                return ConfigurationManager.AppSettings["promotion_id"];
            }
        }

        public string merchant_id
        {
            get
            {
                return ConfigurationManager.AppSettings["merchant_id"];
            }
        }

        public string item_id
        {
            get
            {
                return ConfigurationManager.AppSettings["item_id"];
            }
        }

        public string order_id
        {
            get
            {
                return ConfigurationManager.AppSettings["order_id"];
            }
        }

        public string transaction_id
        {
            get
            {
                return ConfigurationManager.AppSettings["transaction_id"];
            }
        }

        public string content_id
        {
            get
            {
                return ConfigurationManager.AppSettings["content_id"];
            }
        }

        public string root_content_id
        {
            get
            {
                return ConfigurationManager.AppSettings["root_content_id"];
            }
        }

        public string md5_hash
        {
            get
            {
                return ConfigurationManager.AppSettings["md5_hash"];
            }
        }

        public string contact_email
        {
            get
            {
                return ConfigurationManager.AppSettings["contact_email"];
            }
        }

        public string flagged_by
        {
            get
            {
                return ConfigurationManager.AppSettings["flagged_by"];
            }
        }

        public string seller_user_id
        {
            get
            {
                return ConfigurationManager.AppSettings["seller_user_id"];
            }
        }

        public string webhook_id
        {
            get
            {
                return ConfigurationManager.AppSettings["webhook_id"];
            }
        }
    }
}
