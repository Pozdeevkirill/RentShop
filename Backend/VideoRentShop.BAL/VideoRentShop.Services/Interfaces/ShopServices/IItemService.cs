	using VideoRentShop.HttpModels.Requests;
using VideoRentShop.HttpModels.Requests.Admin;
using VideoRentShop.HttpModels.Responses;
using VideoRentShop.HttpModels.ViewObjects;
using VideoRentShop.HttpModels.ViewObjects.Shop;

namespace VideoRentShop.Services.Interfaces.ShopServices
{
	public interface IItemService : IService
	{
		/// <summary>
		/// Создать товар
		/// </summary>
		IdWithNameVo Create(AddItemRequest request);

		/// <summary>
		/// Получить список товаров пагинацией
		/// </summary>
		PaginationResponse<ItemVo> GetItems(PaginationRequest request);

		/// <summary>
		/// Удалить товар
		/// </summary>
		void RemoveItem(Guid itemId);
	}
}
