using Microsoft.AspNetCore.Http;

namespace VideoRentShop.Services.Interfaces.ShopServices
{
	public interface IFileAttachmentService : IService
	{
		void UploadFiles(Guid itemId, List<IFormFile> files, int? mainFileIndex = null); 
	}
}
