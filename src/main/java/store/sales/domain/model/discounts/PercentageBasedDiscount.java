package store.sales.domain.model.discounts;

public class PercentageBasedDiscount extends DiscountCalculation {

    private final double percent;

    public PercentageBasedDiscount(double percent) {
        this.percent = percent;
    }

    @Override
    public double calculateDiscount(double totalPrice) {
        throw new UnsupportedOperationException();
    }
}
