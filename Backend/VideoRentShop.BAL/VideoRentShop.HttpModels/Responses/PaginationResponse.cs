namespace VideoRentShop.HttpModels.Responses
{
    public class PaginationResponse<T> : IBaseResponse
    {
        public PaginationResponse(List<T>? data, int countAll)
        {
            Data = data;
            CountAll = countAll;
        }

        public List<T>? Data{ get; set; }
        public int CountAll { get; set; }
    }
}
