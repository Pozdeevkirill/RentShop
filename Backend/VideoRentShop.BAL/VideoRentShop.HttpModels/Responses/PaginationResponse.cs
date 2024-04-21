namespace VideoRentShop.HttpModels.Responses
{
    public class PaginationResponse<T> : IBaseResponse
    {
        public List<T>? Data{ get; set; }
        public int CountAll { get; set; }
    }
}
