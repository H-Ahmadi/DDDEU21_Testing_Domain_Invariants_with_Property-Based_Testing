using System;
using System.Linq;
using System.Net.Sockets;
using FsCheck;
using Sales.Domain.Model.Orders;
using Random = System.Random;

namespace Sales.Domain.Tests.Generators
{
    public class DiscountValueGenerator
    {
        public static Arbitrary<long> GenerateWithMinimumValueOf(long minimumValue)
        {
            return Arb.From(from value in Arb.Generate<long>()
                            where value >= minimumValue
                            select value
                                );
        }

        public static Arbitrary<long> GenerateWithMaximumValueOf(long maximumValue)
        {
            return Arb.From(from value in Arb.Generate<long>()
                where value <= maximumValue && value > 0
                select value
            );
        }
    }
}