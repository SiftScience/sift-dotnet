//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sift
{
    
    
    public partial class CreateContent : SiftEvent
    {
    }
}
//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v9.13.28.0 (Newtonsoft.Json v9.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------

namespace Sift
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.13.28.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CreateContent 
    {
        [Newtonsoft.Json.JsonProperty("$type", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string type { get; set; } = "$create_content";
    
        [Newtonsoft.Json.JsonProperty("$user_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string user_id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$content_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string content_id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$session_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string session_id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string status { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$ip", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ip { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$comment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Comment comment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$listing", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Listing listing { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Message message { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$post", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Post post { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$profile", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Profile profile { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$review", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Review review { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$app", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public App app { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$browser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Browser browser { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    
        public static CreateContent FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CreateContent>(data);
        }
    
    }
}