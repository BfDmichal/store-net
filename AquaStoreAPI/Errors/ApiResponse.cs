namespace AquaStoreAPI.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDeafultMessageForStatusCode(statusCode);
        }

        private string GetDeafultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request",
                401 => "No Authorized",
                404 => "Not FOUND",
                500 => "Server error",
                _ => null
            };
        }
    }
}
