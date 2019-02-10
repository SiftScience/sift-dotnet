namespace Sift
{
    public class ServerException : SiftException
    {
        public ServerException(string message) : base(message)
        {
        }

        public ServerException(SiftResponse response) : base(response)
        {
        }
    }
}
