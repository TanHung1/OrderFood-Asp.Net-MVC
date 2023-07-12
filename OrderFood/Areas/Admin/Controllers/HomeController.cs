using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderFood.Areas.Identity.Data;

namespace OrderFood.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private readonly SignInManager<AccountUser> _signInManager;
        public HomeController(SignInManager<AccountUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return LocalRedirect("/identity/account/login");
        }
    }
}
