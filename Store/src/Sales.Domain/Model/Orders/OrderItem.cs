using System;

namespace Sales.Domain.Model.Orders
{
    public class OrderItem
    {
        public long ProductId { get; private set; }
        public long Amount { get; private set; }
        public long EachPrice { get; private set; }
        public OrderItem(long productId, long amount, long eachPrice)
        {
            ProductId = productId;
            Amount = amount;
            EachPrice = eachPrice;
        }
        public long TotalPrice()
        {
            return 0;
        }
    }
}