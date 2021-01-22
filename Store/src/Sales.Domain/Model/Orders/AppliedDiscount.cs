namespace Sales.Domain.Model.Orders
{
    public class AppliedDiscount
    {
        public long DiscountId { get; private set; }
        public long Value { get; private set; }
        internal AppliedDiscount(long discountId, long value)
        {
            DiscountId = discountId;
            Value = value;
        }
    }
}