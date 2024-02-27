namespace ChatApi.Exceptions
{
    public class ErrorMessageException : Exception
    {
        public string Message { get; set; }
        public ErrorMessageException(string message)
        {
            Message = message;
        }
    }
}
