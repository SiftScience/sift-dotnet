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
    
    
    public partial class Discount : SiftEntity
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
    public partial class Discount 
    {
        [Newtonsoft.Json.JsonProperty("$percentage_off", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? percentage_off { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$amount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? amount { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$currency_code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string currency_code { get; set; }
    
        [Newtonsoft.Json.JsonProperty("$minimum_purchase_amount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? minimum_purchase_amount { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    
        public static Discount FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Discount>(data);
        }
    
    }
}