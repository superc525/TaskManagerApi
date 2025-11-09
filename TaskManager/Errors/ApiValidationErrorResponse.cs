namespace TaskManager.Errors
{
    public class ApiValidationErrorResponse:ApiErrorResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {

        }
        public IEnumerable<string> Erros { get; set; }
    }
}
