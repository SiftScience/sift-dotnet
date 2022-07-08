using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sift
{
    public class WorkflowStatusResponse : SiftResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("config")]
        public WorkflowConfigJson Config { get; set; }

        [JsonProperty("config_display_name")]
        public string ConfigDisplayName { get; set; }

        [JsonProperty("abuse_types")]
        public List<string> AbuseTypes { get; set; }

        [JsonProperty("entity")]
        public EntityJson Entity { get; set; }

        [JsonProperty("history")]
        public List<HistoryJson> History { get; set; }

        [JsonProperty("route")]
        public RouteInfoJson Route { get; set; }

        public class WorkflowConfigJson
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }
        }

        public class EntityJson
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public class RouteInfoJson
        {
            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class HistoryJson
        {
            [JsonProperty("app")]
            public string App { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("config")]
            public AppConfigJson Config { get; set; }

            public class AppConfigJson
            {
                [JsonProperty("decision_id")]
                public string DecisionId { get; set; }

                [JsonProperty("buttons")]
                public List<ButtonJson> Buttons { get; set; }

                public class ButtonJson
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }
                }
            }
        }
    }
}
