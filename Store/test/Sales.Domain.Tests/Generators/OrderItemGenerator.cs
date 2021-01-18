using System;
using System.Collections.Generic;
using System.Text;
using FsCheck;
using Sales.Domain.Model.Orders;

namespace Sales.Domain.Tests.Generators
{
    public class OrderItemGenerator
    {
        public static Arbitrary<OrderItem> Generate()
        {
            return Arb.From(from id in Arb.Generate<long>()
                from amount in Arb.Generate<PositiveInt>()
                from eachPrice in Arb.Generate<PositiveInt>()
                select new OrderItem(id, amount.Get, eachPrice.Get));
        }
    }
}
