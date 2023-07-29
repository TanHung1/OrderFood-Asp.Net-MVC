using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderFood.Models;
using OrderFood.Repository;
using X.PagedList;

namespace OrderFood.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;

        public OrderController(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }
        public IActionResult Index(string status, int page = 1, int pageSize = 10)
        {
            var q1 = from c in _orderRepository.GetAllOrders()
                     select new SelectListItem()
                     {
                         Text = $"{c.FirstName} - {c.LastName} - {c.Email} - {c.Address} - {c.PhoneNumber} - {c.PaymentMethods}",
                         Value = c.OrderId.ToString(),
                     };
            ViewBag.OrderId = q1.ToList();

            List<OrderItem> orderItems = _orderItemRepository.GetAll();

            if (!string.IsNullOrEmpty(status))
            {
                orderItems = orderItems.Where(x => x.Status == status).ToList();
            }

            int totalItems = orderItems.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            orderItems = orderItems.OrderByDescending(x => x.OrderDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            return View("Index", orderItems);
        }

        public IActionResult UpdateOrderItem(OrderItem orderItem)
        {

            _orderItemRepository.UpdateOrderItem(orderItem);
            return RedirectToAction("Index");
        }
        public IActionResult EditOrderItem(string id)
        {
            var q = from c in _orderRepository.GetAllOrders()
                    select new SelectListItem()
                    {
                        Text = $"{c.FirstName} - {c.LastName} - {c.Email} - {c.Address} - {c.PhoneNumber} - {c.PaymentMethods}",

                        Value = c.OrderId.ToString(),
                    };
            ViewBag.OrderId = q.ToList();
            return View("EditOrderItem", _orderItemRepository.findbyId(id));
        }

        //delete
        public IActionResult DeleteOrderItem(string id)
        {
            _orderItemRepository.DeleteOrderItem(id);
            return RedirectToAction("Index");
        }

        ///////////////Order///////////////////////////////////
        public IActionResult EditOrder(string id)
        {
            return View("EditOrder", _orderRepository.findbyid(id));
        }
        public IActionResult UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteOrder(string id)
        {
            _orderRepository.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}
