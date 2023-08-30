using Newtonsoft.Json;

namespace Sift
{
    public class VerificationCheckResponse : SiftResponse
    {

        [JsonProperty("$checked_at")]
        public string CheckedAt { get; set; }
    }
    public class VerificationSendResponse : SiftResponse
    {
        [JsonProperty("$sent_at")]
        public string SentAt { get; set; }
    }

    public class VerificationReSendResponse : SiftResponse
    {
        [JsonProperty("$sent_at")]
        public string SentAt { get; set; }
    }

}
