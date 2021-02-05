package store.sales.domain.model.discounts;

import java.time.LocalDateTime;

public class DiscountBuilder {
    private long id;
    private LocalDateTime expirationTime;
    private DiscountStrategy strategy;
    private int maxDiscountValue;

    public DiscountBuilder setId(long id) {
        this.id = id;
        return this;
    }

    public DiscountBuilder setExpirationTime(LocalDateTime expirationTime) {
        this.expirationTime = expirationTime;
        return this;
    }

    public DiscountBuilder setStrategy(DiscountStrategy strategy) {
        this.strategy = strategy;
        return this;
    }

    public DiscountBuilder setMaxDiscountValue(int maxDiscountValue) {
        this.maxDiscountValue = maxDiscountValue;
        return this;
    }

    public Discount build() {
        return new Discount(id, expirationTime, strategy, maxDiscountValue);
    }
}