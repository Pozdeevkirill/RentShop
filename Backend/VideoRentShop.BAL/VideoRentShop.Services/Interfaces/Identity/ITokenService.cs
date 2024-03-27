using System.Security.Claims;
using VideoRentShop.HttpModels.Requests.Identity;
using VideoRentShop.HttpModels.Responses.Identity;

namespace VideoRentShop.Services.Interfaces.Identity
{
    public interface ITokenService : IService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        TokenResponse RefreshToken(RefreshTokenRequest request);
    }
}
