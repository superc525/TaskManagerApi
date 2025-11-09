namespace TaskManager.Errors
{
    public class ApiErrorResponse
    {

        public ApiErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMensajStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetMensajStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Se ha realizado una solicitud no valida",
                401 => "No esta autorizado para este recurso",
                404 => "Recurso no encontrado",
                500 => "Error interno del servido",
                _ => null
            };
        }
    }
}
