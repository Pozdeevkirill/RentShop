using Microsoft.AspNetCore.Http;

namespace VideoRentShop.Services.Interfaces.ShopServices
{
	public interface IFileAttachmentService : IService
	{
		/// <summary>
		/// Загрузить файлы для товара
		/// </summary>
		void UploadItemFiles(Guid itemId, List<IFormFile> files, int? mainFileIndex = null);

		/// <summary>
		/// Загрузить файл для любой сущности
		/// </summary>
		void UploadFile(Guid entityId, IFormFile file);

		/// <summary>
		/// Загрузить файлы для любой сущности
		/// </summary>
		void UploadFiles(Guid entityId, List<IFormFile> files);
	}
}
