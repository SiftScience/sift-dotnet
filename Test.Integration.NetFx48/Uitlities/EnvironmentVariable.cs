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
    }
}
