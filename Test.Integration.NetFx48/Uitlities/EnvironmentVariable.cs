using System.Configuration;

namespace Test.Integration.NetFx48.Uitlities
{
    internal class EnvironmentVariable
    {

        public string ApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["ApiKey"];
            }
        }
        public string AccountId
        {
            get
            {
                return ConfigurationManager.AppSettings["AccountId"];
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
    }
}
