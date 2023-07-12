using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderFood.Areas.Identity.Data;
using OrderFood.Models;
using OrderFood.Repository;
using System.Data;
using System.Text.Json;

namespace OrderFood.Controllers
{
    public class CartController : Controller
    {
        private readonly SignInManager<AccountUser> _signInManager;
        private IDishRepository _dishRepository;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private readonly OrderFoodDBContext _context;
        public CartController(OrderFoodDBContext dbContext, IDishRepository dishRepository, IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, SignInManager<AccountUser> signInManager)
        {
            _signInManager = signInManager;
            _orderRepository = orderRepository;
            _dishRepository = dishRepository;
            _orderItemRepository = orderItemRepository;
            _context = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.sessionId = HttpContext.Session.Id;
            CartModel cartModel = new CartModel();
            cartModel.CartId = HttpContext.Session.Id;
            if (HttpContext.Session.GetString("cart") != null)
            {
                List<CarttItem> items = JsonSerializer.Deserialize<List<CarttItem>>(HttpContext.Session.GetString("cart"));
                cartModel.setAllItems(items);
            }
            return View(cartModel);
        }
        public IActionResult checkout()
        {
            CartModel cartModel = null;
            if (HttpContext.Session.GetString("cart") != null)
            {
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;
                List<CarttItem> items = JsonSerializer.Deserialize<List<CarttItem>>(HttpContext.Session.GetString("cart"));
                cartModel.setAllItems(items);
            }
            ViewBag.CartModel = cartModel;
            return View(cartModel);
        }
        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {

            // Lấy tổng số tiền của đơn hàng
            CartModel cartModel = null;
            if (HttpContext.Session.GetString("cart") != null)
            {
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;
                List<CarttItem> items = JsonSerializer.Deserialize<List<CarttItem>>(HttpContext.Session.GetString("cart"));
                cartModel.setAllItems(items);
            }

            // Lưu đơn hàng vào cơ sở dữ liệu
            var orderRepository = new OrderRepository(_context);
            orderRepository.AddOrder(order);

            // Lưu các mặt hàng vào bảng OrderItem
            if (cartModel != null && cartModel.getAllItems().Count > 0)
            {
                List<CarttItem> cartItems = cartModel.getAllItems();
                string NameDish = string.Join(",", cartItems.Select(item => item.Name));

                var orderItem = new OrderItem
                {
                    OrderId = order.OrderId,
                    NameDish = NameDish,
                    OrderDate = DateTime.Now,
                    Quantity = cartItems.Sum(c => c.Quantity),
                    Status = "Chưa xác nhận",
                    Total = (float)cartItems.Sum(c => c.Quantity * c.Price)
                };

                var orderItemRepository = new OrderItemRepository(_context);
                orderItemRepository.AddOrderItems(orderItem);
            }

            // Xóa giỏ hàng khỏi phiên làm việc
            HttpContext.Session.Remove("cart");

            // Chuyển hướng đến trang cảm ơn
            return RedirectToAction("Index", "Menu");
        }

        public IActionResult AddToCart(string id)
        {
            // Tìm mặt hàng theo id
            Dish dish = _dishRepository.findByDishId(id);
            int quantity = 1;
            CartModel cartModel = null;
            if (HttpContext.Session.GetString("cart") != null)
            {
                // Bước 1: Lấy giỏ hàng từ phiên làm việc
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;

                // Đọc dữ liệu phiên biểu mẫu vào giỏ hàng
                List<CarttItem> items = JsonSerializer.Deserialize<List<CarttItem>>(HttpContext.Session.GetString("cart"));
                cartModel.setAllItems(items);

                // Thêm mặt hàng mới vào giỏ hàng
                CarttItem cartItem = new CarttItem()
                {
                    Id = dish.DishId,
                    Name = dish.NameDish,
                    Price = dish.Price,
                    ImagePath = dish.Image,
                    Quantity = quantity,
                    LineTotal = quantity * dish.Price
                };
                cartModel.addCartItem(cartItem);
                HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartModel.getAllItems()));
            }
            else
            {
                // Tạo giỏ hàng mới nếu chưa có
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;
                CarttItem item = new CarttItem()
                {
                    Id = dish.DishId,
                    Name = dish.NameDish,
                    Price = dish.Price,
                    ImagePath = dish.Image,
                    Quantity = quantity,
                    LineTotal = quantity * dish.Price
                };
                cartModel.addCartItem(item);
                HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartModel.getAllItems()));
            }
            return RedirectToAction("Index", "Menu");
        }


        public IActionResult UpdateQuantity()
        {
            var btn = Request.Form["btnUpdateQuantity"].ToString();
            var id = Request.Form["item.id"].ToString();
            var qty = int.Parse(Request.Form["item.Quantity"]);

            CartModel cartModel = null;
            if (HttpContext.Session.Get("cart") != null)
            {
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;
                string cartJson = HttpContext.Session.GetString("cart");
                List<CarttItem> cartItems = JsonSerializer.Deserialize<List<CarttItem>>(cartJson);
                cartModel.setAllItems(cartItems);

            }
            cartModel.UpdateQuantity(id, 1, btn);

            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartModel.getAllItems()));
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCart(string id)
        {
            CartModel cartModel = null;
            if (HttpContext.Session.GetString("cart") != null)
            {
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;
                List<CarttItem> items = JsonSerializer.Deserialize<List<CarttItem>>(HttpContext.Session.GetString("cart"));
                cartModel.setAllItems(items);
                cartModel.RemoveCartItem(id);
                HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartModel.getAllItems()));
            }
            return RedirectToAction("Index");
        }

    }
}