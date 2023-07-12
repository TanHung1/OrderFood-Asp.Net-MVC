using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderFood.Areas.Identity.Data;
using OrderFood.Repository;

namespace OrderFood.Controllers
{
    public class ProfileController : Controller
    {
        private readonly SignInManager<AccountUser> _signInManager;
        private readonly UserManager<AccountUser> _userManager;
        private readonly IAccountRepository _accountRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public ProfileController(SignInManager<AccountUser> signInManager,
            UserManager<AccountUser> userManager,
            IAccountRepository accountRepository,
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _accountRepository = accountRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<IActionResult> Index()
        {
            //lấy thông tin đang đăng nhập
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                //ko tìm thấy chuyển đến trang đăng nhập
                return RedirectToAction("Login", "Account");
            }
            //truyền thông tin tài khoản vào view
            return View(user);
        }

        //public IActionResult EditProfile(string id)
        //{
        //    var account = _accountRepository.findbyId(id);
        //    return View(account);
        //}
        [HttpPost]
        public IActionResult UpdateProfile(AccountUser accountUser)
        {
            _accountRepository.UpdateAccount(accountUser);
            return RedirectToAction("Index");
        }

        public IActionResult MyOrder()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));

            // Lấy danh sách Order của người dùng hiện tại
            var orders = _orderRepository.GetOrderByUserId(userId)
                .OrderByDescending(o => o.PaymentMethods)
                .ToList();

            foreach (var order in orders)
            {
                // Lấy danh sách OrderItem của từng Order
                var orderItems = _orderItemRepository.GetOrderItemsByOrderId(order.OrderId)
                    .OrderByDescending(oi => oi.OrderDate)
                    .ToList();
                order.OrderItems = orderItems;
            }

            return View(orders);
        }
    }
}
