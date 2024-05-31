using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sift.Response
{
    public class WarningsResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public List<WarningItem> Items { get; set; }

        public class WarningItem
        {
            [JsonProperty("message")]
            public string Message { get; set; }
        }
    }
}
