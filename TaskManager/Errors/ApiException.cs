namespace TaskManager.Errors
{
    public class ApiException : ApiErrorResponse
    {
        public ApiException(int statusCode, string mensaje = null, string detalle = null) : base(statusCode,message:mensaje)
        {
            StatusCode = statusCode;
            Message = mensaje;
            Detail = detalle;
        }

        private string Detail { get; set; }
    }
}
