using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoRentShop.HttpModels.Requests.Admin;
using VideoRentShop.Models.Enums;
using VideoRentShop.Services.Interfaces.Identity;

namespace VideoRentShop.WEB.Controllers.API.Admin
{
	[Route("api/user/")]
	public class UserController : Controller
	{
		private readonly IAuthService _authService;

		public UserController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost]
		[Route("add")]
		[Authorize(Roles = "Admin")]
		public ActionResult Add([FromForm]AddUserRequest req)
		{
			_authService.AddUser(req);
			return Ok();
		}
	}
}
