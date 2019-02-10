namespace Sift
{
    public class InvalidRequestException : SiftException
    {
        public InvalidRequestException(string message) : base(message)
        {
        }

        public InvalidRequestException(SiftResponse response) : base(response)
        {
        }
    }
}
