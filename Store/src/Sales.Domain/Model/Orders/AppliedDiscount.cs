namespace Sales.Domain.Model.Orders
{
    public class AppliedDiscount
    {
        public long  DiscountId { get; private set; }
        public double Value { get; private set; }
        public AppliedDiscount(long discountId, double value)
        {
            DiscountId = discountId;
            Value = value;
        }
    }
}