using VideoRentShop.Data.Interfaces;
using VideoRentShop.HttpModels.Requests.Admin;
using VideoRentShop.Models.Shop;
using VideoRentShop.Services.Interfaces.ShopServices;

namespace VideoRentShop.Services.Implementation.ShopServices
{
	public class ItemService : IItemService
	{
		private readonly IRepository<Item> _itemRepository;

		public ItemService(IRepository<Item> itemRepository)
		{
			_itemRepository = itemRepository;
		}

		public Guid Create(AddItemRequest request)
		{
			Item item = new()
			{
				Count = 0,
				Description = request.Description,
				IsActive = request.IsActive,
				Name = request.Name
			};

			Guid result = Guid.Empty;

			_itemRepository.UnitOfWork.Execute(() =>
			{
				result = _itemRepository.Add(item);
			});

			return result;
		}
	}
}
