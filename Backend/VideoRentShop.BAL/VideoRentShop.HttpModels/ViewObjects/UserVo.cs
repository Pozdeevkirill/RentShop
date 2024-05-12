namespace VideoRentShop.HttpModels.ViewObjects
{
    public class UserVo : EntityVo
    {
        public UserVo(Guid id,string login, string name, string roleName)
        {
            Id = id;
            Login = login;
            Name = name;
            RoleName = roleName;
        }

        public string Login { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
    }
}
