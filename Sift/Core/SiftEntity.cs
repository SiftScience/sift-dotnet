using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sift
{
    public class SiftEntity
    {
        [JsonExtensionData]
        Dictionary<string, object> fields;

        public void AddField(string key, long value)
        {
            AddField(key, (object)value);
        }

        public void AddField(string key, double value)
        {
            AddField(key, (object)value);
        }

        public void AddField<T>(string key, T value) where T : class
        {
            if (fields == default(Dictionary<string, object>))
            {
                this.fields = new Dictionary<string, object>();
            }
            this.fields[key] = value;
        }

        public void AddFields(Dictionary<string, object> fields)
        {
            foreach (var field in fields)
            {
                AddField(field.Key, field.Value);
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}