using System.Security.Claims;
using VideoRentShop.HttpModels.Common.Identity;
using VideoRentShop.HttpModels.Requests.Identity;
using VideoRentShop.HttpModels.Responses.Identity;
using VideoRentShop.Models.Identity;

namespace VideoRentShop.Services.Interfaces.Identity
{
    public interface ITokenService : IService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        TokenResponse RefreshToken(string refreshToken, string ip);
        User GetUserByRefreshToken(string refreshToken);
        User GetUserByToken(string token);
        TokenModel GetTokenByUserId(Guid id);
        void RemoveTokenByUserId(Guid id);
        Guid? ValidateJwtToken(string token);
    }
}
