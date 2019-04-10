using System;
using System.Net.Http;

namespace Sift
{
    public abstract class SiftRequest
    {
        public virtual string ApiKey { get; set; }
        public abstract HttpRequestMessage Request { get; }
        protected abstract Uri Url { get; }
    }
}
