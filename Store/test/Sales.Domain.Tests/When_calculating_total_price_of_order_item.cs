using System;
using System.Collections.Generic;
using System.Linq;
using FsCheck;
using FsCheck.Xunit;
using Sales.Domain.Model.Orders;
using Sales.Domain.Tests.TestHelpers;

namespace Sales.Domain.Tests
{
    public class When_calculating_total_price_of_order_item
    {
        [Property]
        public Property each_price_of_zero_always_results_in_total_price_of_zero(PositiveInt amount)
        {
            var orderItem = new OrderItem(TestProducts.Laptop, amount.Get, 0);
            return (orderItem.TotalPrice() == 0).ToProperty();
        }

        [Property]
        public Property total_price_is_equal_to_each_price_when_amount_is_one(PositiveInt price)
        {
            var orderItem = new OrderItem(TestProducts.Laptop, 1, price.Get);
            return (orderItem.TotalPrice() == price.Get).ToProperty();
        }

        [Property]
        public Property total_price_is_equal_to_add_each_price_to_itself_amount_times(PositiveInt amount, PositiveInt eachPrice)
        {
            var orderItem = new OrderItem(TestProducts.Laptop, amount.Get, eachPrice.Get);
            var expectedTotalPrice = Enumerable.Repeat(eachPrice.Get, amount.Get).Aggregate((a,b) => a + b);

            return (orderItem.TotalPrice() == expectedTotalPrice).ToProperty();
        }
    }
}