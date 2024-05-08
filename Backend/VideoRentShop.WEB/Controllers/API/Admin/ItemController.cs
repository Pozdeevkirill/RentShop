using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoRentShop.HttpModels.Requests;
using VideoRentShop.HttpModels.Requests.Admin;
using VideoRentShop.Services.Interfaces.ShopServices;

namespace VideoRentShop.WEB.Controllers.API.Admin
{
	[Route("api/item/")]
	[Authorize]
	public class ItemController : Controller
	{
		private readonly IItemService _itemService;

		public ItemController(IItemService itemService)
		{
			_itemService = itemService;
		}

		[HttpPost]
		[Route("addItem")]
		public ActionResult AddItem([FromBody]AddItemRequest request)
		{
			return Ok(_itemService.Create(request));
		}

		[HttpGet]
		[Route("get")]
        public ActionResult GetItems([FromQuery]PaginationRequest request)
		{
			return Ok(_itemService.GetItems(request));
		}

		[HttpPost]
		[Route("remove")]
		public ActionResult RemoveItem([FromQuery]Guid itemId)
		{
			_itemService.RemoveItem(itemId);
			return Ok();
		}
	}
}
