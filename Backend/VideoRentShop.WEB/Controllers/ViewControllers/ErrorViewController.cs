using Microsoft.AspNetCore.Mvc;

namespace VideoRentShop.WEB.Controllers.ViewControllers
{
    public class ErrorViewController : BaseViewController
    {
        [Route("Error/{statusCode}")]
        public ActionResult Error(int statusCode)
        {
            switch (statusCode)
            {
                case 401:
                    return base.View("ErrorPages/401");
                case 404:
                    return base.View("ErrorPages/404");
                case 500:
                    return base.View("ErrorPages/500");
                default:
                    throw new Exception("Не известный тип ошибки");
            }
        }
    }
}
