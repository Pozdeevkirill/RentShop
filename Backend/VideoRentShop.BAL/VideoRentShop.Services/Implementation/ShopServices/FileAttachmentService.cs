using Microsoft.AspNetCore.Http;
using VideoRentShop.Common;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.Models.Shop;
using VideoRentShop.Services.Interfaces.ShopServices;

namespace VideoRentShop.Services.Implementation.ShopServices
{
	public class FileAttachmentService : IFileAttachmentService
	{
		private readonly IRepository<ItemFile> _fileAttachmentService;

		public FileAttachmentService(IRepository<ItemFile> fileAttachmentService)
		{
			_fileAttachmentService = fileAttachmentService;
		}

		public void UploadFiles(Guid itemId, List<IFormFile> files, int? mainFileIndex = null)
		{
			_fileAttachmentService.UnitOfWork.Execute(() =>
			{
				List<ItemFile> _files = new();
				for (var i = 0; i < files.Count; i++)
				{
					_files.Add(new()
					{
						File = files[i].GetBytes().GetAwaiter().GetResult(),
						FileName = files[i].GetFriendlyName(),
						MimeType = files[i].ContentType,
						SystemName = files[i].FileName,
						ItemId = itemId,
					});
				}

				_fileAttachmentService.AddRange(_files);
			});
		}
	}
}
