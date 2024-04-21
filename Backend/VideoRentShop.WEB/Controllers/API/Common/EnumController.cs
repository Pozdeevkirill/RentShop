using Microsoft.AspNetCore.Mvc;
using VideoRentShop.Common;
using VideoRentShop.HttpModels.ViewObjects;
using VideoRentShop.Models.Enums;

namespace VideoRentShop.WEB.Controllers.API.Common
{
	/// <summary>
	/// Контроллер для получения значений енамов
	/// </summary>
	[Route("api/enum/")]
	public class EnumController : Controller
	{
		[HttpGet("roles")]
		public ActionResult Roles()
		{
			return Ok(ConvertDictinary(EnumHelper.GetEnumValues<Role>()));
		}

		private List<IdIntWithNameVo> ConvertDictinary(Dictionary<int, string> dict)
		{
			return dict.Select(x => new IdIntWithNameVo(x.Key, x.Value)).ToList();
		}
	}
}
