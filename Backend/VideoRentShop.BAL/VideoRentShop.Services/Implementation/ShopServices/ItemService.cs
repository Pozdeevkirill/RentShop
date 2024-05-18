using VideoRentShop.Common;
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

        public void Edit(EditItemRequest request)
        {
			if (request == null) throw new Exception(ErrorMessages.RequestEmptyError);

			var curItem = _itemRepository.List(x => x.Id == request.Id).Select(x => new Item()
			{
				Id = x.Id,
				Count = x.Count,
				Description = x.Description,
				IsActive = x.IsActive,
				Name = x.Name,
				Price = x.Price,
			}).Single();

			//Не делаю проверку на нул, т.к. используем сингл

			if (curItem.Name == request.Name &&
				curItem.Description == request.Description &&
				curItem.Price == request.Price) throw new Exception(ErrorMessages.EntityNotChangedError);

			curItem.Name = request.Name;
			curItem.Description = request.Description;
			curItem.Price = request.Price;

			_itemRepository.UnitOfWork.Execute(() =>
			{
				_itemRepository.Update(curItem);
			});
        }

        public ItemVo Get(Guid id)
        {
			if (id == Guid.Empty) throw new Exception(ErrorMessages.IdCantBeNullError);

			var item = _itemRepository.List(x => x.Id == id).Select(x => new ItemVo()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                IsActive = x.IsActive,
                Count = x.Count,
				Price = x.Price,
            }).Single();
			if (item == null) throw new Exception(ErrorMessages.NotFoundByIdError);

			return item;
        }

        public PaginationResponse<ItemVo> GetItems(PaginationRequest request)
		{
			if (request == null) throw new Exception(ErrorMessages.RequestEmptyError);

			if(request.Skip < 0) request.Skip = 0;

			if (request.Take <= 0) return new(null, 0);

            var data = _itemRepository.GetAllIncluding(x => x.Files).Where(x => !x.IsDeleted).Skip(request.Skip).Take(request.Take).Select(x => new ItemVo()
            {
                Id = x.Id,
                Count = x.Count,
                Name = x.Name,
                Description = x.Description,
                IsActive = x.IsActive,
				Price = x.Price,
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

			if (item == null) throw new Exception(ErrorMessages.NotFoundByIdError);

			_itemRepository.UnitOfWork.Execute(() =>
			{
				item.Delete();
			});
		}
	}
}
