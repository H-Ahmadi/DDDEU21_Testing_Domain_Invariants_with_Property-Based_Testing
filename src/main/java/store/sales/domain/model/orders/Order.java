package store.sales.domain.model.orders;

import store.sales.domain.model.discounts.Discount;

import java.util.List;

public class Order {
    private final List<OrderItem> items;
    private final long id;
    private AppliedDiscount appliedDiscount;

    public Order(long id, List<OrderItem> items) {
        this.id = id;
        this.items = items;
    }

    public long totalPrice() {
        throw new UnsupportedOperationException();
    }

    public void ApplyDiscount(Discount discount) {
        throw new UnsupportedOperationException();
    }

    public long getId() {
        return id;
    }

    public List<OrderItem> getItems() {
        return items;
    }

    public AppliedDiscount getAppliedDiscount() {
        return appliedDiscount;
    }
}
