using VideoRentShop.HttpModels.Requests.Admin;
using VideoRentShop.Models.Shop;

namespace VideoRentShop.Services.Interfaces.ShopServices
{
	public interface IItemService : IService
	{
		Guid Create(AddItemRequest request);
	}
}
