using Newtonsoft.Json;

namespace Sift
{
    public class VerificationCheckResponse : SiftResponse
    {
        [JsonProperty("$status")]
        public string Status { get; set; }

        [JsonProperty("$error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("$checked_at")]
        public string CheckedAt { get; set; }
    }
    public class VerificationSendResponse : SiftResponse
    {
        [JsonProperty("$status")]
        public string Status { get; set; }

        [JsonProperty("$error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("$sent_at")]
        public string SentAt { get; set; }
    }

    public class VerificationReSendResponse : SiftResponse
    {
        [JsonProperty("$status")]
        public string Status { get; set; }

        [JsonProperty("$error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("$sent_at")]
        public string SentAt { get; set; }
    }

}
