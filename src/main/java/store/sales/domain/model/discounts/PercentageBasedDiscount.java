package store.sales.domain.model.discounts;

public class PercentageBasedDiscount extends DiscountStrategy {

    private final int percent;

    public PercentageBasedDiscount(int percent) {
        this.percent = percent;
    }

    @Override
    public int calculateDiscount(int totalPrice) {
        throw new UnsupportedOperationException();
    }
}
