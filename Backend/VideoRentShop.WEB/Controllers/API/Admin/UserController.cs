using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoRentShop.HttpModels.Requests;
using VideoRentShop.HttpModels.Requests.Admin;
using VideoRentShop.Services.Interfaces.Identity;
using VideoRentShop.Services.Interfaces.ShopServices;

namespace VideoRentShop.WEB.Controllers.API.Admin
{
	[Route("api/user/")]
	public class UserController : Controller
	{
		private readonly IAuthService _authService;
		private readonly IUserService _userService;

		public UserController(IAuthService authService, IUserService userService)
		{
			_authService = authService;
			_userService = userService;
		}

		[HttpPost]
		[Route("add")]
		[Authorize(Roles = "Admin")]
		public ActionResult Add([FromForm]AddUserRequest req)
		{
			_authService.AddUser(req);
			return Ok();
		}

		[HttpGet]
		[Route("get")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetUsers([FromQuery] PaginationRequest req)
		{
			return Ok(_userService.GetAll(req));
		}
	}
}
