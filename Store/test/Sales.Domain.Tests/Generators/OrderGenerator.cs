using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using FsCheck;
using Sales.Domain.Model.Orders;

namespace Sales.Domain.Tests.Generators
{
    public class OrderGenerator
    {
        public static Arbitrary<Order> Generate()
        {
            return Arb.From(from id in Arb.Generate<PositiveInt>()
                    from items in OrderItemGenerator.Generate().Generator.ListOf()
                select new Order(id.Get, items.ToList()));
        }
    }
}