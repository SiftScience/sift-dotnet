namespace Sift
{
    public class InvalidFieldException : SiftException
    {
        public InvalidFieldException(string message) : base(message)
        {
        }

        public InvalidFieldException(SiftResponse response) : base(response)
        {
        }
    }
}
