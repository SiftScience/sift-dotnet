using Newtonsoft.Json;
using Sift.Response;
using System.Collections.Generic;

namespace Sift
{
    public class EventResponse : SiftResponse
    {
        [JsonProperty("score_response")]
        public ScoreResponse ScoreResponse { get; set; }
        [JsonProperty("warnings")]
        public WarningsResponse Warnings { get; set; }
    }

}
