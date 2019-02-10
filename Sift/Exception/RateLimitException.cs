namespace Sift
{
    public class RateLimitException : SiftException
    {
        public RateLimitException(string message) : base(message)
        {
        }

        public RateLimitException(SiftResponse response) : base(response)
        {
        }
    }
}
