using System;
using System.Runtime.CompilerServices;
using Sales.Domain.Model.Orders;

namespace Sales.Domain.Model.Discounts
{
    public class Discount
    {
        public long Id { get; private set; }
        public DateTime ExpirationTime { get; private set; }
        public DiscountStrategy Strategy { get; private set; }
        public long? MaxDiscountValue { get; private set; }
        public Discount(long id, DateTime expirationTime, DiscountStrategy strategy, long? maxDiscountValue)
        {
            Id = id;
            ExpirationTime = expirationTime;
            Strategy = strategy;
            MaxDiscountValue = maxDiscountValue;
        }
        public long CalculateDiscountFor(Order order)
        {
            var discount = Strategy.CalculateDiscount(order.TotalPrice());
            if (DiscountExceedsMaximumValue(discount))
                return this.MaxDiscountValue.Value;
            return discount;
        }

        private bool DiscountExceedsMaximumValue(long discount)
        {
            if (!MaxDiscountValue.HasValue) return false;
            return MaxDiscountValue.Value < discount;
        }
    }
}