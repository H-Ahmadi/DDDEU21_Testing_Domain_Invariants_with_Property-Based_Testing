using System;

namespace Sales.Domain.Model.Orders
{
    public class OrderItem
    {
        public long ProductId { get; private set; }
        public long Amount { get; private set; }
        public double EachPrice { get; private set; }
        public OrderItem(long productId, long amount, double eachPrice)
        {
            ProductId = productId;
            Amount = amount;
            EachPrice = eachPrice;
        }
        public double TotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}