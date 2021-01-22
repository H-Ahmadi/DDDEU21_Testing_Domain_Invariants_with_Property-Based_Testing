using System;

namespace Sales.Domain.Model.Discounts
{
    public class ValueBasedDiscount : DiscountStrategy
    {
        private readonly long _discountValue;
        public ValueBasedDiscount(long discountValue)
        {
            _discountValue = discountValue;
        }

        public override long CalculateDiscount(long totalPrice)
        {
            return _discountValue;
        }
    }
}