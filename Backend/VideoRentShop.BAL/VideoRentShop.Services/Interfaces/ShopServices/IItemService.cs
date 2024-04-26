using VideoRentShop.HttpModels.Requests;
using VideoRentShop.HttpModels.Requests.Admin;
using VideoRentShop.HttpModels.Responses;
using VideoRentShop.HttpModels.ViewObjects;
using VideoRentShop.HttpModels.ViewObjects.Shop;

namespace VideoRentShop.Services.Interfaces.ShopServices
{
	public interface IItemService : IService
	{
		IdWithNameVo Create(AddItemRequest request);

		PaginationResponse<ItemVo> GetItems(PaginationRequest request);

		void RemoveItem(Guid itemId);
	}
}
