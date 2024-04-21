namespace VideoRentShop.HttpModels.Requests
{
    public class PaginationRequest : IBaseRequest
    {
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
