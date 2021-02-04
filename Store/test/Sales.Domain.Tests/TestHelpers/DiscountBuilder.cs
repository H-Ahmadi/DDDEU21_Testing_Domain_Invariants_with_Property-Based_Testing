using System;
using Sales.Domain.Model.Discounts;

namespace Sales.Domain.Tests.TestHelpers
{
    public class DiscountBuilder
    {
        private long _id;
        private DateTime _expirationDate;
        private DiscountStrategy _discountStrategy;
        private long? maxDiscountValue;
        public DiscountBuilder()
        {
            _id = new Random().Next(1, int.MaxValue);
            _expirationDate = DateTime.Now.AddYears(1);
            _discountStrategy = new ValueBasedDiscount(0);
            maxDiscountValue = null;
        }

        public DiscountBuilder AsValueBasedDiscount(long value)
        {
            _discountStrategy = new ValueBasedDiscount(value);
            return this;
        }

        public DiscountBuilder AsPercentageBasedDiscount(float percent)
        {
            _discountStrategy = new PercentageBasedDiscount(percent);
            return this;
        }

        public DiscountBuilder WithMaxDiscountValue(long value)
        {
            maxDiscountValue = value;
            return this;
        }

        public DiscountBuilder WithExpireDateAs(DateTime date)
        {
            this._expirationDate = date;
            return this;
        }

        public Discount Build()
        {
            return new Discount(_id, _expirationDate, _discountStrategy, maxDiscountValue);
        }
    }
}