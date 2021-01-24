package store.sales.domain.model.discounts;

public class ValueBasedDiscount extends DiscountStrategy {

    private final int discountValue;

    public ValueBasedDiscount(int discountValue) {
        this.discountValue = discountValue;
    }

    @Override
    public int calculateDiscount(int totalPrice) {
        throw new UnsupportedOperationException();
    }
}
