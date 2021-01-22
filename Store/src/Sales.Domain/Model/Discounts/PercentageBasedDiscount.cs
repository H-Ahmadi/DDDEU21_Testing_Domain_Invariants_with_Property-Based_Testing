using System;

namespace Sales.Domain.Model.Discounts
{
    public class PercentageBasedDiscount : DiscountCalculation
    {
        private readonly float _percent;
        public PercentageBasedDiscount(float percent)
        {
            _percent = percent;
        }

        public override long CalculateDiscount(long totalPrice)
        {
            throw new NotImplementedException();   
        }
    }
}