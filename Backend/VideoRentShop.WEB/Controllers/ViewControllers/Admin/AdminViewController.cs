using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VideoRentShop.WEB.Controllers.ViewControllers.Admin
{
	[Authorize]
    [Route("admin/")]
	public class AdminViewController : BaseViewController
    {
        private const string _defaultViewFolder = "Admin";

		[Route("")]
        public ActionResult Index()
        {
            return View($"{_defaultViewFolder}/AdminMainPage");
        }

        [Route("allUsers")]
        public ActionResult ViewAllUsers()
        {
            return PartialView($"{_defaultViewFolder}/Users/AllUsers");
        }

        [Route("addUser")]
        public ActionResult ViewAddUser()
        {
            throw new Exception("Тест ошибки");
            return PartialView($"{_defaultViewFolder}/Users/AddUser");
        }

        [Route("addItem")]
        public ActionResult ViewAddItem()
        {
            return PartialView($"{_defaultViewFolder}/Shop/AddItem");
        }
    }
}
