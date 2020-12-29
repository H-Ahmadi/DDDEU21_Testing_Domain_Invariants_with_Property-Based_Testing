using System;

namespace Sales.Domain.Model.Discounts
{
    public class PercentageBasedDiscount : DiscountCalculation
    {
        private readonly double _percent;
        public PercentageBasedDiscount(float percent)
        {
            _percent = percent;
        }

        public override double CalculateDiscount(double totalPrice)
        {
            throw new NotImplementedException();   
        }
    }
}