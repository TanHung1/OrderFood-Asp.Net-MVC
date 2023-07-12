using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFood.Models
{
    public class OrderItem
    {
        [Key]
       
        public Guid OrderItemId { get; set; }
        public string NameDish { get; set; }

        public int Quantity { get; set; }

        public Guid OrderId { get; set; }
        
        public DateTime OrderDate { get; set; }
        public string? Status { get; set; }

        public float Total { get; set; }
 
    

    }
}

