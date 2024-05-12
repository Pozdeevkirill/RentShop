using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoRentShop.Services.Interfaces.ShopServices;

namespace VideoRentShop.WEB.Controllers.API.Admin
{
	[Route("api/file/")]
	[Authorize]
	public class FileController : Controller
	{
		private readonly IFileAttachmentService _fileAttachmentService;

		public FileController(IFileAttachmentService fileAttachmentService)
		{
			_fileAttachmentService = fileAttachmentService;
		}

		[HttpPost]
		[Route("uploadFiles")]
		public ActionResult Upload([FromQuery] Guid itemId, [FromQuery] int mainFileId, [FromForm] List<IFormFile> files)
		{
			_fileAttachmentService.UploadItemFiles(itemId, files, mainFileId);
			return Ok();
		}

		[HttpPost]
		[Route("upload")]
		public ActionResult Upload([FromQuery] Guid entityId, [FromForm] IFormFile file)
		{
			if (file == null) return Ok();
			_fileAttachmentService.UploadFile(entityId, file);
			return Ok();
		}
	}
}
