using Microsoft.AspNetCore.Http;
using VideoRentShop.Common;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.Models.Shop;
using VideoRentShop.Models.Shop.File;
using VideoRentShop.Services.Interfaces.ShopServices;

namespace VideoRentShop.Services.Implementation.ShopServices
{
    public class FileAttachmentService : IFileAttachmentService
	{
		private readonly IRepository<FileAttachment> _fileAttachmentRepository;
		private readonly IRepository<ItemFile> _itemFileAttachmentRepository;
		private readonly IRepository<Header> _headerRepository;

		public FileAttachmentService(IRepository<FileAttachment> fileAttachmentRepository, 
									IRepository<ItemFile> itemFileAttachmentRepository,
									IRepository<Header> headerRepository)
		{
			_fileAttachmentRepository = fileAttachmentRepository;
            _itemFileAttachmentRepository = itemFileAttachmentRepository;
			_headerRepository = headerRepository;
		}

        public void UploadFile(Guid entityId, IFormFile file)
        {
			if (file == null) throw new Exception("Файл не может быть пустым");

			_fileAttachmentRepository.UnitOfWork.Execute(() =>
			{
				FileAttachment _file = new(entityId, file.GetFriendlyName(), file.FileName, file.ContentType)
				{
                    File = file.GetBytes().GetAwaiter().GetResult(),
                };
				_fileAttachmentRepository.Add(_file);
			});
        }

        public void UploadFiles(Guid entityId, List<IFormFile> files)
        {
			_fileAttachmentRepository.UnitOfWork.Execute(() =>
			{
                List<FileAttachment> _files = files.Select(x => 
					new FileAttachment(entityId, x.GetFriendlyName(), x.FileName, x.ContentType)
					{
						File = x.GetBytes().GetAwaiter().GetResult(),
					}).ToList();

				_fileAttachmentRepository.AddRange(_files);
			});
        }

        public void UploadItemFiles(Guid itemId, List<IFormFile> files, int? mainFileIndex = null)
		{
            _itemFileAttachmentRepository.UnitOfWork.Execute(() =>
			{
				List<ItemFile> _files = new();
				for (var i = 0; i < files.Count; i++)
				{
					_files.Add(new(itemId, files[i].GetFriendlyName(), files[i].FileName, files[i].ContentType)
					{
						File = files[i].GetBytes().GetAwaiter().GetResult(),
						IsMainFile = i == mainFileIndex
					});
				}

                _itemFileAttachmentRepository.AddRange(_files);
			});
		}
	}
}
