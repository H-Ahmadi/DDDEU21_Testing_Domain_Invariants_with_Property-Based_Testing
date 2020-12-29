using System;

namespace Sales.Domain.Model.Discounts
{
    public class ValueBasedDiscount : DiscountCalculation
    {
        private readonly double _discountValue;
        public ValueBasedDiscount(int discountValue)
        {
            _discountValue = discountValue;
        }

        public override double CalculateDiscount(double totalPrice)
        {
            throw new NotImplementedException();
        }
    }
}