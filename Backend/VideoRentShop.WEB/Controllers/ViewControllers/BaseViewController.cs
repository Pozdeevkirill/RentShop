using Microsoft.AspNetCore.Mvc;

namespace VideoRentShop.WEB.Controllers.ViewControllers
{
    public class BaseViewController : Controller
    {
        protected const string BaseUrlView = "../../Views/";

        public override ViewResult View(string? viewName, object? model)
        {
            return base.View(BaseUrlView + viewName, model);
        }

		public override PartialViewResult PartialView(string? viewName, object? model)
		{
			return base.PartialView(BaseUrlView + viewName, model);
		}
	}
}
