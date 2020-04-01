namespace AurNet.Http
{
    public class ApiResponseWrapper<TSuccessResponse>
    {
        public TSuccessResponse SuccessResponse { get; set; }

        public ApiErrorResponse ErrorResponse { get; set; }

        public bool IsSuccess => this.ErrorResponse != null;

        public bool IsError => !this.IsSuccess;
    }
}