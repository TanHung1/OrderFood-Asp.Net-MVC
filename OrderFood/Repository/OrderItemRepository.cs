using OrderFood.Models;
namespace OrderFood.Repository
{
    public interface IOrderItemRepository
    {
        List<OrderItem> GetAll();
        public void AddOrderItems(OrderItem orderItem);
        public bool UpdateOrderItem(OrderItem orderItem);
        public bool DeleteOrderItem(string orderItemId);
        public OrderItem findbyId(string OrderItemId);

        List<OrderItem> GetOrderItemsByOrderId(Guid orderId);
        int CountOrderItem();
        float SumTotal();
    }
    public class OrderItemRepository : IOrderItemRepository
    {
        private OrderFoodDBContext _context;
        public OrderItemRepository(OrderFoodDBContext dBContext)
        {
            _context = dBContext;
        }
        public void AddOrderItems(OrderItem orderItems)
        {
            _context.OrderItems.AddRange(orderItems);
            _context.SaveChanges();
        }



        public List<OrderItem> GetAll()
        {
            return _context.OrderItems.ToList();
        }
        public OrderItem findbyId(string OrderItemId)
        {
            Guid OrderItemGuid = Guid.Parse(OrderItemId);
            OrderItem o = _context.OrderItems.FirstOrDefault(x => x.OrderItemId == OrderItemGuid);
            return o;
        }
        public bool UpdateOrderItem(OrderItem orderItem)
        {
            OrderItem o = _context.OrderItems.FirstOrDefault(x => x.OrderItemId == orderItem.OrderItemId);
            if (o != null)
            {
                _context.Entry(o).CurrentValues.SetValues(orderItem);
                _context.SaveChanges();

            }
            return true;
        }

        public bool DeleteOrderItem(string orderItemId)
        {
            Guid OrderItemGuid = Guid.Parse(orderItemId);
            OrderItem o = _context.OrderItems.FirstOrDefault(x => x.OrderItemId == OrderItemGuid);
            _context.OrderItems.Remove(o);
            _context.SaveChanges();
            return true;
        }

        public List<OrderItem> GetOrderItemsByOrderId(Guid orderId)
        {
            return _context.OrderItems.Where(oi => oi.OrderId == orderId).ToList();
        }

        public int CountOrderItem()
        {
            return _context.OrderItems.Count(o => o.Status == "Đã giao");
        }

        public float SumTotal()
        {
            float total = _context.OrderItems.Where(o => o.Status == "Đã giao").Sum(o => o.Total);
            return total;
        }
    }
}
