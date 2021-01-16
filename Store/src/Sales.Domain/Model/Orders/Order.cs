using System;
using System.Collections.Generic;
using System.Linq;
using Sales.Domain.Model.Discounts;

namespace Sales.Domain.Model.Orders
{
    public class Order
    {
        private List<OrderItem> _items;
        public long Id { get; private set; }
        public AppliedDiscount AppliedDiscount { get;private set; }
        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
        public Order(long id, List<OrderItem> items)
        {
            this.Id = id;
            this._items = items;
        }
        public double TotalPrice()
        {
            throw new NotImplementedException();
        }
        public void ApplyDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }
    }
}