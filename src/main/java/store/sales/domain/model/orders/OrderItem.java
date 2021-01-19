package store.sales.domain.model.orders;

public class OrderItem {
    private final long productId;
    private final long amount;
    private final long eachPrice;

    public OrderItem(long productId, long amount, long eachPrice) {
        this.productId = productId;
        this.amount = amount;
        this.eachPrice = eachPrice;
    }

    public long totalPrice() {
        return eachPrice;
    }

    public long getProductId() {
        return productId;
    }

    public long getAmount() {
        return amount;
    }

    public long getEachPrice() {
        return eachPrice;
    }
}
