package store.sales.domain.model.discounts;

import static java.lang.Math.round;

public class PercentageBasedDiscount extends DiscountStrategy {

    private final int percent;

    public PercentageBasedDiscount(int percent) {
        this.percent = percent;
    }

    @Override
    public int calculateDiscount(int totalPrice) {
        var discount = percent * totalPrice / 100;
        return round(discount);
    }
}
