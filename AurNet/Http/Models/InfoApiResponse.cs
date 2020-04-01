namespace AurNet.Http
{
    public class InfoApiResponse : ApiResponse<InfoResult>
    {
        public override ApiResponseType Type => ApiResponseType.MultiInfo;
    }
}