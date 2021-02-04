using System;
using System.Text.RegularExpressions;
using FsCheck;

namespace Sales.Domain.Tests.Generators
{
    public class DiscountPercentGenerator
    {
        public static Arbitrary<float> Generate()
        {
            return Arb.From(from value in Arb.Generate<float>()
                where value > 0 && value < 100
                select (float)Math.Round(value, 1)
            );
        }
    }
}