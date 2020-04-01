namespace AurNet.Http
{
    public class SearchApiResponse : ApiResponse<SearchResult>
    {
        public override ApiResponseType Type => ApiResponseType.Search;
    }
}