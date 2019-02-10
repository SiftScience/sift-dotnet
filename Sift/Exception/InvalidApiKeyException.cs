namespace Sift
{
    public class InvalidApiKeyException : SiftException
    {
        public InvalidApiKeyException(string message) : base(message)
        {
        }

        public InvalidApiKeyException(SiftResponse response) : base(response)
        {
        }
    }
}
