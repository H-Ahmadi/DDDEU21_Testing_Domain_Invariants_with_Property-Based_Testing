package store.sales.domain.model.discounts;

import store.sales.domain.model.orders.Order;

import java.time.LocalDateTime;

public class Discount {
    private final long id;
    private final LocalDateTime expirationTime;
    private final DiscountCalculation calculation;
    private final double maxDiscountValue;

    public Discount(
            long id, LocalDateTime expirationTime, DiscountCalculation calculation, double maxDiscountValue) {
        this.id = id;
        this.expirationTime = expirationTime;
        this.calculation = calculation;
        this.maxDiscountValue = maxDiscountValue;
    }

    public float CalculateDiscountFor(Order order) {
        throw new UnsupportedOperationException();
    }

    public long getId() {
        return id;
    }

    public LocalDateTime getExpirationTime() {
        return expirationTime;
    }

    public DiscountCalculation getCalculation() {
        return calculation;
    }

    public double getMaxDiscountValue() {
        return maxDiscountValue;
    }
}
