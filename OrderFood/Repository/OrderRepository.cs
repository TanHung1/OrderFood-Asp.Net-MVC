using OrderFood.Models;

namespace OrderFood.Repository
{
    public interface IOrderRepository
    {
        public void AddOrder(Order order);

        public bool DeleteOrder(string OrdersId);
        public bool UpdateOrder(Order order);

        public Order findbyid(string OrderId);
        public List<Order> GetAllOrders();

        public List<Order> GetOrderByUserId(Guid userId);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderFoodDBContext _context;

        public OrderRepository(OrderFoodDBContext dbContext)
        {
            _context = dbContext;
        }
        public void AddOrder(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();

        }
        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Order findbyid(string OrderId)
        {
            Guid OrderIdGuid = Guid.Parse(OrderId);
            Order o = _context.Orders.FirstOrDefault(x => x.OrderId == OrderIdGuid);
            return o;
        }

        public bool UpdateOrder(Order order)
        {
            Order o = _context.Orders.FirstOrDefault(x => x.OrderId == order.OrderId);
            if (o != null)
            {
                _context.Entry(o).CurrentValues.SetValues(order);
                _context.SaveChanges();
            }
            return true;
        }

        public bool DeleteOrder(string OrdersId)
        {
            Guid OrderIdGuid = Guid.Parse(OrdersId);
            Order o = _context.Orders.FirstOrDefault(x => x.OrderId == OrderIdGuid);
            _context.Orders.Remove(o);
            _context.SaveChanges();
            return true;
        }

        public List<Order> GetOrderByUserId(Guid userId)
        {
            return _context.Orders.Where(o => o.UserId == userId).ToList();
        }
    }
}
