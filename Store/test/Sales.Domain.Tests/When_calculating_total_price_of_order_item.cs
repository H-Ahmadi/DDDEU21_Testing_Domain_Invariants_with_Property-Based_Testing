using FsCheck;
using FsCheck.Xunit;
using Sales.Domain.Model.Orders;
using Sales.Domain.Tests.TestHelpers;

namespace Sales.Domain.Tests
{
    public class When_calculating_total_price_of_order_item
    {
        [Property]
        public Property each_price_of_zero_always_results_in_total_price_of_zero(PositiveInt quantity)
        {
            var orderItem = new OrderItem(TestProducts.Laptop, quantity.Get, 0);
            return (orderItem.TotalPrice() == 0).ToProperty();
        }

        [Property]
        public Property total_price_is_equal_to_each_price_when_quantity_is_one(PositiveInt price)
        {
            var orderItem = new OrderItem(TestProducts.Laptop, 1, price.Get);
            return (orderItem.TotalPrice() == price.Get).ToProperty();
        }
    }
}