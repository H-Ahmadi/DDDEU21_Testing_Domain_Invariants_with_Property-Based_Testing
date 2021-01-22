using System;

namespace Sales.Domain.Model.Discounts
{
    public class ValueBasedDiscount : DiscountCalculation
    {
        private readonly int _discountValue;
        public ValueBasedDiscount(int discountValue)
        {
            _discountValue = discountValue;
        }

        public override long CalculateDiscount(long totalPrice)
        {
            throw new NotImplementedException();
        }
    }
}