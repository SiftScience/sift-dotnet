namespace Sift
{
    public class MissingFieldException : SiftException
    {
        public MissingFieldException(string message) : base(message)
        {
        }

        public MissingFieldException(SiftResponse response) : base(response)
        {
        }
    }
}
