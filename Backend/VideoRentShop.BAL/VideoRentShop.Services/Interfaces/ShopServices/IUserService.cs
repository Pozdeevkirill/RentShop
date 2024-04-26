using VideoRentShop.HttpModels.Requests;
using VideoRentShop.HttpModels.Responses;
using VideoRentShop.HttpModels.ViewObjects;

namespace VideoRentShop.Services.Interfaces.ShopServices
{
    public interface IUserService : IService
    {
        PaginationResponse<UserVo> GetAll(PaginationRequest req);
    }
}
