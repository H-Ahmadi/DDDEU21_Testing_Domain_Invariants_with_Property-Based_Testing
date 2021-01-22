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
        public Property subtracting_item_from_total_price_of_order_results_in_other_item(OrderItem firstItem, OrderItem secondItem)
        {
            var items = new List<OrderItem> { firstItem, secondItem };
            var order = new Order(1, items);

            return (order.TotalPrice() - firstItem.TotalPrice() == secondItem.TotalPrice()).ToProperty();
        }

        [Property]
        public Property subtracting_all_items_from_total_price_results_in_zero(List<OrderItem> items)
        {
            var order = new Order(1, items);
            var totalPrice = order.TotalPrice();

            items.ForEach(a=> totalPrice -= a.TotalPrice());

            return (totalPrice == 0).ToProperty();
        }
    }
}