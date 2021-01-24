package store.sales.domain.model.discounts;

public abstract class DiscountStrategy {
    public abstract int calculateDiscount(int totalPrice);
}
