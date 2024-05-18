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
		[Route("getAll")]
        public ActionResult GetItems([FromQuery]PaginationRequest request)
		{
			return Ok(_itemService.GetItems(request));
		}

		[HttpGet]
		[Route("get")]
		public ActionResult GetItem([FromQuery]Guid itemId)
		{
			return Ok(_itemService.Get(itemId));
		}

		[HttpPost]
		[Route("remove")]
		public ActionResult RemoveItem([FromQuery] Guid itemId)
		{
			_itemService.RemoveItem(itemId);
			return Ok();
		}

		[HttpPost]
		[Route("edit")]
		public ActionResult EditItem([FromBody] EditItemRequest request)
		{
			_itemService.Edit(request);
			return Ok();
		}
	}
}
