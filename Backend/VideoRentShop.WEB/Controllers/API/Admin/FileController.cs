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
		public ActionResult Upload([FromQuery] Guid itemId, [FromQuery] int mainFileId, [FromForm] List<IFormFile> files)
		{
			_fileAttachmentService.UploadFiles(itemId, files, mainFileId);
			return Ok();
		}
	}
}
