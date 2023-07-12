namespace OrderFood.Models
{
    public class CartModel
    {
        private List<CarttItem> _cartItems = new List<CarttItem>();

        public string CartId { get; set; }
        
        public decimal Total { get; set; }

        public  decimal getTotal()
        {
            decimal total = 0;
            foreach (var item in _cartItems)
            {
                total += item.LineTotal;
            }
            return total;
        }
        public int addCartItem(CarttItem cartItem)
        {
            foreach(var item in _cartItems)
            {
                if(item.Id == cartItem.Id)
                {
                    item.Quantity += cartItem.Quantity;
                    item.LineTotal = item.Quantity * item.Price;
                    return _cartItems.Count;
                }

            }
            _cartItems.Add(cartItem);
            Total = 0;
            foreach(var item in _cartItems)
            {
                Total += item.LineTotal;

            }
            return _cartItems.Count;
        }
        public void RemoveCartItem(string id)
        {
            Guid itemid = Guid.Parse(id);
            CarttItem item = _cartItems.FirstOrDefault(i => i.Id == itemid);
            if (item != null)
            {
                _cartItems.Remove(item);
            }
        }
        public void UpdateQuantity(string id, int qty, string btnCmd)
        {
            Guid itemId = Guid.Parse(id);
            foreach (CarttItem item in _cartItems)
            {
                if (item.Id == itemId)
                {
                    if (btnCmd == "+")
                    {
                        item.Quantity += qty;
                        item.LineTotal = item.Quantity * item.Price;
                    }
                    else
                    {
                        item.Quantity -= qty;
                        item.LineTotal = item.Quantity * item.Price;
                        if(item.Quantity <= 0)
                        {
                            _cartItems.Remove(item);
                        }
                    }
                    return;

                }
            }
            //Total
            Total = 0;
            foreach (var it in _cartItems)
            {
                Total += it.LineTotal;
            }
        }
        public List<CarttItem> getAllItems()
        {
            return _cartItems;
        }
        public void setAllItems(List<CarttItem> cartItems)
        {
            _cartItems = cartItems;
        }
        
    }
}
