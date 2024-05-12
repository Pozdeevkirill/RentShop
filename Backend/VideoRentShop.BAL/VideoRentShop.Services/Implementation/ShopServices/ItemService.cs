using VideoRentShop.Data.Interfaces;
using VideoRentShop.HttpModels.Requests;
using VideoRentShop.HttpModels.Requests.Admin;
using VideoRentShop.HttpModels.Responses;
using VideoRentShop.HttpModels.ViewObjects;
using VideoRentShop.HttpModels.ViewObjects.Shop;
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

		public IdWithNameVo Create(AddItemRequest request)
		{
			Item item = new()
			{
				Count = 0,
				Description = request.Description,
				IsActive = request.IsActive,
				Name = request.Name,
				Price = request.Price,
			};

			IdWithNameVo result = new(Guid.Empty, request.Name);

			_itemRepository.UnitOfWork.Execute(() =>
			{
				result.Id = _itemRepository.Add(item);
			});

			return result;
		}

		public PaginationResponse<ItemVo> GetItems(PaginationRequest request)
		{
			if (request == null) throw new Exception("Запрос не может быть пустым!");

			if(request.Skip < 0) request.Skip = 0;

			if (request.Take <= 0) return new(null, 0);

            var data = _itemRepository.GetAllIncluding(x => x.Files).Where(x => !x.IsDeleted).Skip(request.Skip).Take(request.Take).Select(x => new ItemVo()
            {
                Id = x.Id,
                Count = x.Count,
                Name = x.Name,
                Description = x.Description,
                IsActive = x.IsActive,
                Files = x.Files == null ? new() : x.Files.Select(y => new FileVo()
                {
                    FileName = y.FileName,
                    SystemName = y.SystemName,
                    MimeType = y.MimeType,
                    File = y.File,
                    IsMainFile = y.IsMainFile,
                }).ToList()
            }).ToList();

			var countAll = _itemRepository.Count();
            var result = new PaginationResponse<ItemVo>(data, countAll);

			return result;
		}

		public void RemoveItem(Guid itemId)
		{
			var item = _itemRepository.Get(itemId);

			if (item == null) throw new Exception("Товар с таким ИД не найден.");

			_itemRepository.UnitOfWork.Execute(() =>
			{
				item.Delete();
			});
		}
	}
}
