package store.sales.domain.model.orders;

public class AppliedDiscount {
    private final long discountId;
    private final double value;

    public AppliedDiscount(long discountId, double value) {
        this.discountId = discountId;
        this.value = value;
    }

    public long getDiscountId() {
        return discountId;
    }

    public double getValue() {
        return value;
    }
}
