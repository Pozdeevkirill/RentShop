using VideoRentShop.HttpModels.Requests;
using VideoRentShop.HttpModels.Responses;
using VideoRentShop.HttpModels.ViewObjects;

namespace VideoRentShop.Services.Interfaces.ShopServices
{
    public interface IUserService : IService
    {
        /// <summary>
        /// Получить всех пользователей пагинацией
        /// </summary>
        PaginationResponse<UserVo> GetAll(PaginationRequest req);

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        void RemoveUser(Guid id);
    }
}
