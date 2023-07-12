using System.ComponentModel.DataAnnotations;

namespace OrderFood.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PaymentMethods { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}

