namespace OrderFood.Models
{
    public class CarttItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal LineTotal { get; set; }
        public string ImagePath { get; set; }


    }
}
