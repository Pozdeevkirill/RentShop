namespace VideoRentShop.HttpModels.Requests.Admin
{
	public class AddUserRequest : IBaseRequest
	{
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
