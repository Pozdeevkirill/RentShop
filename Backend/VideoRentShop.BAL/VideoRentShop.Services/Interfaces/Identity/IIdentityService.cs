using VideoRentShop.HttpModels.Common.Identity;

namespace VideoRentShop.Services.Interfaces.Identity
{
    public interface IIdentityService : IService
    {
        Guid GetUserIdByToken(string token);

        Guid GetUserIdByRefreshToken(string refreshToken);

        void AddUserWithToken(Guid id, TokenModel token);

        void UpdateToken(Guid id, string token);

        void UpdateRefreshToken(Guid id, string refreshToken);

        void RemoveTokenByUser(Guid id);

        TokenModel GetTokenByUser(Guid id);

    }
}
