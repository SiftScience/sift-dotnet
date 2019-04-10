using System;
using System.Web;

namespace Sift
{
    public static class HttpUtil
    {
        public static Uri AddQuery(this Uri uri, string name, string value)
        {
            var httpValueCollection = HttpUtility.ParseQueryString(uri.Query);

            httpValueCollection.Remove(name);
            httpValueCollection.Add(name, value);

            var ub = new UriBuilder(uri);

            // https://stackoverflow.com/a/3866105
            // Basically, HttpUtility.ParseQueryString() returns an undocumented 
            // subclass of NameValueCollection that encodes on ToString()
            ub.Query = httpValueCollection.ToString();

            return ub.Uri;
        }
    }
}
