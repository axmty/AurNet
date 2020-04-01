namespace AurNet.Http
{
    public class ErrorApiResponse : ApiResponse<int>
    {
        public override ApiResponseType Type => ApiResponseType.Error;

        public string Error { get; set; }
    }
}