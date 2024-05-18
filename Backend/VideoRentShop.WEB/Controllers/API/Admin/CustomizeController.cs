using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoRentShop.HttpModels.Requests;
using VideoRentShop.HttpModels.Requests.Admin;
using VideoRentShop.Services.Interfaces.ShopServices;

namespace VideoRentShop.WEB.Controllers.API.Admin
{
	/// <summary>
	/// Контроллер кастомизации публичной части сайта
	/// </summary>
	[Route("api/customize")]
	[Authorize]
	public class CustomizeController : Controller
	{
		private readonly IHeaderService _headerService;

		public CustomizeController(IHeaderService headerService)
		{
			_headerService = headerService;
		}

		#region Header

		[HttpPost]
		[Route("header/create")]
		public ActionResult CreateHeader([FromBody]CreateHeaderRequest request)
		{
			return Ok(_headerService.CreateHeader(request));
		}

		[HttpGet]
		[Route("headers")]
		public ActionResult GetHeaders([FromQuery]PaginationRequest request)
		{
			return Ok(_headerService.GetHeaders(request));
		}

		[HttpPost]
		[Route("header/remove")]
		public ActionResult RemoveHeader(Guid headerId)
		{
			_headerService.Remove(headerId);
            return Ok();
		}

		[HttpPost]
		[Route("header/setActive")]
		public ActionResult SetActive(Guid headerId)
		{
			_headerService.SetActive(headerId);
			return Ok();
		}

		[HttpGet]
		[Route("header/get")]
		public ActionResult GetHeader([FromQuery]Guid headerId)
		{
			return Ok(_headerService.GetHeader(headerId));
		}

		[HttpPost]
		[Route("header/edit")]
		public ActionResult EditHeader([FromBody]EditHeaderRequest request)
		{
			_headerService.EditHeader(request);
			return Ok();
		}

		#endregion
	}
}
