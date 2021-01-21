using System;

namespace Sales.Domain.Model.Orders
{
    public class OrderItem
    {
        public long ProductId { get; private set; }
        public long Quantity { get; private set; }
        public long EachPrice { get; private set; }
        public OrderItem(long productId, long quantity, long eachPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            EachPrice = eachPrice;
        }
        public long TotalPrice()
        {
            return 0;
        }
    }
}