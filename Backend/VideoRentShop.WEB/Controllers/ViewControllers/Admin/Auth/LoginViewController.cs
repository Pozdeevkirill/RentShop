using Microsoft.AspNetCore.Mvc;

namespace VideoRentShop.WEB.Controllers.ViewControllers.Admin.Auth
{
    [Route("admin")]
    public class LoginViewController : BaseViewController
    {
        [Route("login")]
        public ActionResult Login()
        {
            return View("Admin/Auth/LoginView");
        }
    }
}
