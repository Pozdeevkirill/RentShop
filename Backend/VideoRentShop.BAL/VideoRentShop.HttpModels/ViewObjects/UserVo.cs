namespace VideoRentShop.HttpModels.ViewObjects
{
    public class UserVo
    {
        public UserVo(string login, string name, string roleName)
        {
            Login = login;
            Name = name;
            RoleName = roleName;
        }

        public string Login { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
    }
}
