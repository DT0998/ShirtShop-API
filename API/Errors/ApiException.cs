namespace API.Errors
{
    public class ApiException
    {
        public ApiException(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}