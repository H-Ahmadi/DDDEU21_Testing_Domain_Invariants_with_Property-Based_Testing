using System.Collections.Generic;
using Sales.Domain.Model.Orders;

namespace Sales.Domain.Tests.TestHelpers
{
    public class OrderTestFactory
    {
        public static Order CreateOrderWithTotalPriceOf(long totalPrice)
        {
            var orderItem = new List<OrderItem>()
            {
                new OrderItem(1, 1, totalPrice)
            };
            return new Order(1, orderItem);
        }
    }
}