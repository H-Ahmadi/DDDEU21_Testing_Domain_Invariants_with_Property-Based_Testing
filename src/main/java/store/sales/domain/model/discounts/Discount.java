package store.sales.domain.model.discounts;

import store.sales.domain.model.orders.Order;

import java.time.LocalDateTime;

public class Discount {
    private final long id;
    private final LocalDateTime expirationTime;
    private final DiscountStrategy strategy;
    private final long maxDiscountValue;

    public Discount(
            long id, LocalDateTime expirationTime, DiscountStrategy strategy, long maxDiscountValue) {
        this.id = id;
        this.expirationTime = expirationTime;
        this.strategy = strategy;
        this.maxDiscountValue = maxDiscountValue;
    }

    public int calculateDiscountFor(Order order) {
        return strategy.calculateDiscount(order.totalPrice());
    }

    public long getId() {
        return id;
    }

    public LocalDateTime getExpirationTime() {
        return expirationTime;
    }

    public DiscountStrategy getStrategy() {
        return strategy;
    }

    public double getMaxDiscountValue() {
        return maxDiscountValue;
    }
}
