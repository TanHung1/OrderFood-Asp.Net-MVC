using Microsoft.AspNetCore.Mvc;

namespace OrderFood.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
