using VideoRentShop.Common;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.HttpModels.Requests;
using VideoRentShop.HttpModels.Requests.Admin;
using VideoRentShop.HttpModels.Responses;
using VideoRentShop.HttpModels.ViewObjects;
using VideoRentShop.HttpModels.ViewObjects.Shop;
using VideoRentShop.Models.Shop;
using VideoRentShop.Models.Shop.File;
using VideoRentShop.Services.Interfaces.ShopServices;

namespace VideoRentShop.Services.Implementation.ShopServices
{
    public class HeaderService : IHeaderService
	{
		private readonly IRepository<Header> _headerRepository;
		private readonly IRepository<FileAttachment> _fileAttachmentRepository;


		private readonly Func<Header, HeaderVo> _headerVoConverter = x => new HeaderVo()
		{
            Id = x.Id,
            Label = x.Label,
            SubLabel = x.SubLabel,
            Description = x.Description,
            IsActive = x.IsActive
        };

        public HeaderService(IRepository<Header> headerRepository,
							IRepository<FileAttachment> fileAttachmentRepository)
		{
			_headerRepository = headerRepository;
			_fileAttachmentRepository = fileAttachmentRepository;
		}

		public IdWithNameVo CreateHeader(CreateHeaderRequest request)
		{
			if (request == null) throw new Exception(ErrorMessages.RequestEmptyError);

			if (string.IsNullOrEmpty(request.Label)
				|| string.IsNullOrEmpty(request.SubLabel)
				|| string.IsNullOrEmpty(request.Description)) throw new Exception(ErrorMessages.RequiredFieldsError);

			Header header = new(request.Label, request.SubLabel, request.Description, request.IsActive);

			IdWithNameVo result = new(Guid.Empty, request.Label);

			_headerRepository.UnitOfWork.Execute(() =>
			{
				//Если новый банер сразу активный
				if(request.IsActive)
				{
					//Нахожу текущий активный банер
					var currentActiveBanner = _headerRepository.List(x => x.IsActive).Single();
					//..и деактивирую его
					currentActiveBanner.Disable();
					_headerRepository.Update(currentActiveBanner);
				}

				result.Id = _headerRepository.Add(header);
			});

			return result;
		}

        public void EditHeader(EditHeaderRequest request)
        {
            if (request == null) throw new Exception(ErrorMessages.RequestEmptyError);

			var curHeader = _headerRepository.Get(request.Id);

			if (curHeader == null) throw new Exception(ErrorMessages.NotFoundByIdError);

			if (curHeader.Label == request.Label &&
				curHeader.SubLabel == request.SubLabel &&
				curHeader.Description == request.Description) throw new Exception(ErrorMessages.EntityNotChangedError);

			_headerRepository.UnitOfWork.Execute(() =>
			{
				curHeader.Label = request.Label;
				curHeader.SubLabel = request.SubLabel;
				curHeader.Description = request.Description;

				_headerRepository.Update(curHeader);
			});
        }

        public HeaderVo GetActiveHeader()
		{
           var header = _headerRepository.List(x => x.IsActive).Select(_headerVoConverter).Single();
			var file = _fileAttachmentRepository.List(x => x.EntityId == header.Id).FirstOrDefault();


            header.BackgroundFile = file == null ? null : file.File;

			return header;
		}

        public HeaderVo GetHeader(Guid id)
        {
			if (id == Guid.Empty) throw new Exception(ErrorMessages.IdCantBeNullError);

			return _headerRepository.List(x => x.Id == id).Select(_headerVoConverter).Single();
        }

        public PaginationResponse<HeaderVo> GetHeaders(PaginationRequest request)
		{
			if (request == null) throw new Exception(ErrorMessages.RequestEmptyError);

			if (request.Skip < 0) request.Skip = 0;

			if (request.Take <= 0) return new(null, 0);

			var data = _headerRepository.List(x => !x.IsDeleted).OrderByDescending(x => x.IsActive)
													.Skip(request.Skip).Take(request.Take)
													.Select(_headerVoConverter).ToList();

			foreach (var item in data)
			{
				///TODO: Это очень плохо. Как только переделается уровень DAL - исправлю
				var file = _fileAttachmentRepository.List(x => x.EntityId == item.Id).FirstOrDefault();
				item.BackgroundFile = file == null ? null : file.File;
			}

			var countAll = _headerRepository.Count();
			return new(data, countAll);
		}

        public void Remove(Guid id)
        {
            var header = _headerRepository.Get(id);

			if (header == null) throw new Exception(ErrorMessages.NotFoundByIdError);

			if (header.IsActive) throw new Exception("Невозможно удалить активный элемент описания банера.");

			_headerRepository.UnitOfWork.Execute(() =>
			{
				_headerRepository.Delete(header);
			});
        }

        public void SetActive(Guid id)
        {
            var header = _headerRepository.Get(id);

            if (header == null) throw new Exception("Не удалось найти объект с таким Id");

			var activeHeader = _headerRepository.List(x => x.IsActive).Single();

			_headerRepository.UnitOfWork.Execute(() =>
			{
				activeHeader.Disable();
				header.Enable();

				_headerRepository.Update([header, activeHeader]);
			});
        }
    }
}
