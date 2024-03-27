using VideoRentShop.HttpModels.Common.Identity;

namespace VideoRentShop.HttpModels.Requests.Identity
{
    /// <summary>
    /// Запрос на обновление токена
    /// </summary>
    public class RefreshTokenRequest : TokenModel, IBaseRequest
    {
    }
}
