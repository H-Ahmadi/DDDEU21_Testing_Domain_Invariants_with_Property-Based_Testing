namespace Sales.Domain.Model.Discounts
{
    public abstract class DiscountCalculation
    {
        public abstract double CalculateDiscount(double totalPrice);
    }
}