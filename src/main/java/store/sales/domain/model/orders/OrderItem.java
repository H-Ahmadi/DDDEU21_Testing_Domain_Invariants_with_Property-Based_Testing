package store.sales.domain.model.orders;

public class OrderItem {
    private final int productId;
    private final int quantity;
    private final int eachPrice;

    public OrderItem(int productId, int quantity, int eachPrice) {
        this.productId = productId;
        this.quantity = quantity;
        this.eachPrice = eachPrice;
    }

    public int totalPrice() {
        return eachPrice * quantity;
    }

    public int getProductId() {
        return productId;
    }

    public int getQuantity() {
        return quantity;
    }

    public int getEachPrice() {
        return eachPrice;
    }
}
