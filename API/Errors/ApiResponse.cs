using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request was made",
                401 => "You aren't authorized for the access",
                404 => "Resource not found",
                500 => "Errors are the path to dark side. Errors leads to anger. Anger lead to hate. Hate leads to career change.",
                _ => null
            };
        }
    }
}