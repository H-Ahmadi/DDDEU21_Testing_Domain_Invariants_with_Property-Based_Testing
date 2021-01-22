namespace Sales.Domain.Model.Discounts
{
    public abstract class DiscountStrategy
    {
        public abstract long CalculateDiscount(long totalPrice);
    }
}