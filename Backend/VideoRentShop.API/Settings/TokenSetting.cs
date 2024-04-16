namespace VideoRentShop.API.Settings
{
    public class TokenSetting
    {
        public string Secret { get; set; }
        public int RefreshTokenTTL { get; set; }
    }
}
