using System.Collections.Generic;
using System.Linq;
using FsCheck;
using FsCheck.Xunit;
using Sales.Domain.Model.Orders;
using Sales.Domain.Tests.Generators;

namespace Sales.Domain.Tests
{
    public class When_calculating_total_price_of_order
    {
        public When_calculating_total_price_of_order()
        {
            Arb.Register<OrderItemGenerator>();
        }

        [Property]
        public Property total_price_of_order_is_equal_to_total_price_of_item_when_there_is_only_one_item(OrderItem item)
        {
            var orderItems = new List<OrderItem> { item };
            var order = new Order(1, orderItems);
            return (order.TotalPrice() == item.TotalPrice()).ToProperty();
        }

        [Property]
        public Property total_price_of_order_is_sum_of_all_order_items(List<OrderItem> items)
        {
            var order = new Order(1, items);
            var totalPriceOfOrder = order.TotalPrice();
            items.ForEach(a=> totalPriceOfOrder -= a.TotalPrice());
            return (totalPriceOfOrder == 0).ToProperty();
        }
    }
}