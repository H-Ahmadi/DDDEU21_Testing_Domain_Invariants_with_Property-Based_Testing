package store.sales.domain.model.discounts;

import store.sales.domain.model.orders.Order;

import java.time.LocalDateTime;

public class Discount {
    private final long id;
    private final LocalDateTime expirationTime;
    private final DiscountStrategy strategy;
    private final int maxDiscountValue;

    public Discount(
            long id, LocalDateTime expirationTime, DiscountStrategy strategy, int maxDiscountValue) {
        this.id = id;
        this.expirationTime = expirationTime;
        this.strategy = strategy;
        this.maxDiscountValue = maxDiscountValue;
    }

    public int calculateDiscountFor(Order order) {
        var discount = strategy.calculateDiscount(order.totalPrice());
        if (discountExceedsMaximumValue(discount))
            return this.maxDiscountValue;
        return discount;
    }

    private boolean discountExceedsMaximumValue(int discount) {
        if (maxDiscountValue == 0) return false;
        return maxDiscountValue < discount;
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

    public int getMaxDiscountValue() {
        return maxDiscountValue;
    }
}
