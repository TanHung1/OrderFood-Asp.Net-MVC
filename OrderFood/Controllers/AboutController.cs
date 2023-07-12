using Microsoft.AspNetCore.Mvc;

namespace OrderFood.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
