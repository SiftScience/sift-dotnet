using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Sift
{
    public class SiftException : HttpRequestException
    {
        SiftResponse response;

        public string Description { get; set; }
        public Dictionary<string, string> Issues { get; set; }

        public SiftException(string message) : base(message)
        {
        }

        public SiftException(SiftResponse response) : base(responseErrorMessage(response))
        {
            this.response = response;
            this.Description = response.Description;
            this.Issues = response.Issues;
        }

        public SiftResponse getSiftResponse()
        {
            return this.response;
        }

        private static string responseErrorMessage(SiftResponse response)
        {
            if (response.ErrorMessage != null)
            {
                return response.ErrorMessage;
            }

            if (response.Error != null)
            {
                return response.Error;
            }

            return "Unexpected API error.";
        }

        public string getErrorMessage()
        {
            return responseErrorMessage(response);
        }
    }
}
