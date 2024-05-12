using Microsoft.AspNetCore.Mvc;
using VideoRentShop.Services.Interfaces.ShopServices;

namespace VideoRentShop.WEB.Controllers.API.Public
{
	[Route("api/")]
	public class MainPageController : Controller
	{
		private readonly IHeaderService _headerService;

		public MainPageController(IHeaderService headerService)
		{
			_headerService = headerService;
		}

		[HttpGet]
		[Route("initHeader")]
		public ActionResult GetActive()
		{
			return Ok(_headerService.GetActiveHeader());
		}
	}
}
