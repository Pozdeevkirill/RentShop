using VideoRentShop.Common;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.HttpModels.Requests;
using VideoRentShop.HttpModels.Responses;
using VideoRentShop.HttpModels.ViewObjects;
using VideoRentShop.Models.Identity;
using VideoRentShop.Services.Interfaces.ShopServices;

namespace VideoRentShop.Services.Implementation.ShopServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public PaginationResponse<UserVo> GetAll(PaginationRequest req)
        {
            var users = _userRepository.ListToPagin(req.Take, req.Skip).Where(x => !x.IsDeleted).Select(x => new UserVo(x.Id, x.Login, x.Name, x.Role.GetEnumDescription())).ToList();
            var count = _userRepository.Count();

            return new(users, count);
        }

        public void RemoveUser(Guid id)
        {
			var user = _userRepository.Get(id);

			if (user == null) throw new Exception("Пользователь с таким ИД не найден.");

			_userRepository.UnitOfWork.Execute(() =>
			{
				user.Delete();
			});
		}
    }
}
