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

    public int totalPrice() {
        int totalPrice = 0;
        for (OrderItem item : items) {
            totalPrice += item.totalPrice();
        }
        if (this.appliedDiscount == null) return totalPrice;
        //if (this.appliedDiscount.getValue() > totalPrice) return 0;
        return totalPrice;
    }

    public void applyDiscount(Discount discount) {
        var discountValue = discount.calculateDiscountFor(this);
        this.appliedDiscount = new AppliedDiscount(discount.getId(), discountValue);
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
