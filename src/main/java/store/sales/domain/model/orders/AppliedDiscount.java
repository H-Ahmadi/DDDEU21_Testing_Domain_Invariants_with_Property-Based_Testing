package store.sales.domain.model.orders;

public class AppliedDiscount {
    private final long discountId;
    private final int value;

    public AppliedDiscount(long discountId, int value) {
        this.discountId = discountId;
        this.value = value;
    }

    public long getDiscountId() {
        return discountId;
    }

    public int getValue() {
        return value;
    }
}
