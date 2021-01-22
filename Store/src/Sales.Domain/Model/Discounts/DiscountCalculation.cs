namespace Sales.Domain.Model.Discounts
{
    public abstract class DiscountCalculation
    {
        public abstract long CalculateDiscount(long totalPrice);
    }
}