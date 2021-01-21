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
    }
}