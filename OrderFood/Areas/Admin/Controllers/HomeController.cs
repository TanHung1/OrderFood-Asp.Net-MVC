using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderFood.Areas.Identity.Data;
using OrderFood.Repository;

namespace OrderFood.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private readonly SignInManager<AccountUser> _signInManager;
        private IDishRepository _dishRepository;
        private ICategoryRepository _categoryRepository;
        private IOrderItemRepository _orderItemRepository;
        public HomeController(SignInManager<AccountUser> signInManager,
            IDishRepository dishRepository,
            ICategoryRepository categoryRepository, IOrderItemRepository orderItemRepository)
        {
            _signInManager = signInManager;
            _dishRepository = dishRepository;
            _categoryRepository = categoryRepository;
            _orderItemRepository = orderItemRepository;
        }
        public IActionResult Index()
        {
            int count = _dishRepository.CountDishes();
            ViewBag.Count = count;

            int countCategory = _categoryRepository.CountCategory();
            ViewBag.CountCategory = countCategory;

            int countOrderItem = _orderItemRepository.CountOrderItem();

            ViewBag.CountOrderItem = countOrderItem;

            float sumTotal = _orderItemRepository.SumTotal();
            ViewBag.SumTotal = sumTotal;

            var orderItems = _orderItemRepository.GetAll().Where(o => o.Status == "Đã giao");
            var chartData = orderItems.Select(oi => new { OrderDate = oi.OrderDate.ToString("yyyy-MM-dd"), Total = oi.Total })
                                      .OrderBy(x => x.OrderDate)
                                      .ToList();

            var orderDates = chartData.Select(x => x.OrderDate).ToList();
            var totals = chartData.Select(x => x.Total).ToList();

            ViewBag.OrderDates = orderDates;
            ViewBag.Totals = totals;

            return View();


        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return LocalRedirect("/identity/account/login");
        }
    }
}
