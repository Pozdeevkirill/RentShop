using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.HttpModels.Common.Identity;
using VideoRentShop.HttpModels.Responses.Identity;
using VideoRentShop.Models.Identity;
using VideoRentShop.Services.Interfaces.Identity;

namespace VideoRentShop.Services.Implementation.Identity
{
    public class TokenService : ITokenService
    {
        private readonly IIdentityService _identityService;
        private readonly IRepository<User> _userRepository;

        public TokenService(IIdentityService identityService, IRepository<User> userRepository)
        {
            _identityService = identityService;
            _userRepository = userRepository;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication")),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

        public TokenModel GetTokenByUserId(Guid id)
        {
            return _identityService.GetTokenByUser(id);
        }

        public User GetUserByRefreshToken(string refreshToken)
        {
            return _userRepository.Get(_identityService.GetUserIdByRefreshToken(refreshToken));
        }

        public TokenResponse RefreshToken(string refreshToken, string ip)
        {
            var userId = _identityService.GetUserIdByRefreshToken(refreshToken);

            var token = _identityService.GetTokenByUser(userId);

            if (!token.IsActive)
                throw new Exception("Invalid token");

            token.CreatedByIp = ip;
            token.Created = DateTime.Now;
            token.Expires = DateTime.Now.AddMinutes(30);
            var principial = GetPrincipalFromExpiredToken(token.AccessToken);
            token.RefreshToken = GenerateRefreshToken();
            token.AccessToken = GenerateAccessToken(principial.Claims);

            return new()
            {
                AccessToken = token.AccessToken,
                RefreshToken = token.RefreshToken,
                UserName = token.UserName,
            };
        }

        public User GetUserByToken(string token)
        {
            return _userRepository.Get(_identityService.GetUserIdByToken(token));
        }

        #region Private Methods

        private void revokeRefreshToken(TokenModel token, string ipAddress, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReplacedByToken = replacedByToken;
        }

        public void RemoveTokenByUserId(Guid id)
        {
            _identityService.RemoveTokenByUser(id);
        }

        public Guid? ValidateJwtToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
        #endregion
    }
}
