using Microsoft.AspNetCore.Mvc;
using VideoRentShop.Services.Interfaces.ShopServices;

namespace VideoRentShop.WEB.Controllers.API.Admin
{
	[Route("api/file/")]
	public class FileController : Controller
	{
		private readonly IFileAttachmentService _fileAttachmentService;

		public FileController(IFileAttachmentService fileAttachmentService)
		{
			_fileAttachmentService = fileAttachmentService;
		}

		[HttpPost]
		[Route("upload")]
		public ActionResult Upload([FromQuery] Guid itemId, [FromForm] List<IFormFile> files, [FromForm] int? mainFileIndex = null)
		{
			_fileAttachmentService.UploadFiles(itemId, files, mainFileIndex);
			return Ok();
		}
	}
}
