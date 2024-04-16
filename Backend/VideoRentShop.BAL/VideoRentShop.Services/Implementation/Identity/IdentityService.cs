using VideoRentShop.HttpModels.Common.Identity;
using VideoRentShop.Services.Interfaces.Identity;

namespace VideoRentShop.Services.Implementation.Identity
{
    public class IdentityService : IIdentityService
    {
        /// <summary>
        /// UserId to Token
        /// </summary>
        private Dictionary<Guid, TokenModel> UserIdToToken { get; set; }

        public IdentityService()
        {
            UserIdToToken = new();
        }

        public Guid GetUserIdByToken(string refreshToken)
        {
            return UserIdToToken.Where(x => x.Value.AccessToken == refreshToken).FirstOrDefault().Key;
        }

        public Guid GetUserIdByRefreshToken(string refreshToken)
        {
            return UserIdToToken.Where(x => x.Value.RefreshToken == refreshToken).FirstOrDefault().Key;
        }

        public void AddUserWithToken(Guid id, TokenModel token)
        {
            UserIdToToken.Remove(id);
            UserIdToToken.Add(id, token);
        }

        public void UpdateToken(Guid id, string token)
        {
            UserIdToToken[id].AccessToken = token;
        }

        public void UpdateRefreshToken(Guid id, string refreshToken)
        {
            UserIdToToken[id].RefreshToken = refreshToken;
            UserIdToToken[id].Expires = DateTime.Now.AddSeconds(30);
        }

        public void RemoveTokenByUser(Guid id)
        {
            UserIdToToken.Remove(id);
        }

        public TokenModel GetTokenByUser(Guid id)
        {
            return UserIdToToken[id];
        }
    }
}
