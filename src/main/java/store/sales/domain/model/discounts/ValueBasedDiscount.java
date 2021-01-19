package store.sales.domain.model.discounts;

public class ValueBasedDiscount extends DiscountCalculation {

    private final double discountValue;

    public ValueBasedDiscount(double discountValue) {
        this.discountValue = discountValue;
    }

    @Override
    public double calculateDiscount(double totalPrice) {
        throw new UnsupportedOperationException();
    }
}
