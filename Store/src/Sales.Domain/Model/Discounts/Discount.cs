using System;
using System.Runtime.CompilerServices;
using Sales.Domain.Model.Orders;

namespace Sales.Domain.Model.Discounts
{
    public class Discount
    {
        public long Id { get; private set; }
        public DateTime ExpirationTime { get; private set; }
        public DiscountCalculation Calculation { get; private set; }
        public double MaxDiscountValue { get; private set; }
        public Discount(long id,DateTime expirationTime, DiscountCalculation calculation, double maxDiscountValue)
        {
            Id = id;
            ExpirationTime = expirationTime;
            Calculation = calculation;
            MaxDiscountValue = maxDiscountValue;
        }
        public float CalculateDiscountFor(Order order)
        {
            throw new NotImplementedException();
        }
    }
}