using Newtonsoft.Json;

namespace Sift
{
    public class EventResponse : SiftResponse
    {
        [JsonProperty("score_response")]
        public ScoreResponse ScoreResponse { get; set; }
    }
}
