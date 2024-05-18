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
            return PartialView($"{_defaultViewFolder}/Users/AddUser");
        }

        [Route("addItem")]
        public ActionResult ViewAddItem()
        {
            return PartialView($"{_defaultViewFolder}/Shop/AddItem");
        }

        [Route("allItems")]
        public ActionResult ViewAllItem()
        {
            return PartialView($"{_defaultViewFolder}/Shop/AllItems");
        }

        [Route("editItem")]
        public ActionResult EditItem()
        {
            return PartialView($"{_defaultViewFolder}/Shop/EditItem");
        }

        [Route("addHeader")]
        public ActionResult ViewAddHeader()
        {
            return PartialView($"{_defaultViewFolder}/Customize/Header/CreateHeader");
        }

        [Route("allHeaders")]
        public ActionResult ViewAllHeader()
        {
            return PartialView($"{_defaultViewFolder}/Customize/Header/AllHeaders");
        }

        [Route("editHeader")]
        public ActionResult EditHeader()
        {
            return PartialView($"{_defaultViewFolder}/Customize/Header/EditHeader");
        }
    }
}
