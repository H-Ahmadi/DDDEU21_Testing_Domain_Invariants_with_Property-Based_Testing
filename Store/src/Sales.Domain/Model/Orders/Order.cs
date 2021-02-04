using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Sales.Domain.Model.Discounts;

namespace Sales.Domain.Model.Orders
{
    public class Order
    {
        private List<OrderItem> _items;
        public long Id { get; private set; }
        public AppliedDiscount AppliedDiscount { get; private set; }
        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
        public Order(long id, List<OrderItem> items)
        {
            this.Id = id;
            this._items = items;
        }
        public long TotalPrice()
        {
            var totalPrice = Items.Sum(a => a.TotalPrice());
            if (this.AppliedDiscount == null) return totalPrice;
            if (this.AppliedDiscount.Value > totalPrice) return 0;
            return totalPrice - AppliedDiscount.Value;
        }
        public void ApplyDiscount(Discount discount)
        {
            if (discount.ExpirationTime < DateTime.Now) return;
            var discountValue = discount.CalculateDiscountFor(this);
            this.AppliedDiscount = new AppliedDiscount(discount.Id, discountValue);
        }
    }
}