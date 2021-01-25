package store.sales.domain.generators;

import com.pholser.junit.quickcheck.generator.GenerationStatus;
import com.pholser.junit.quickcheck.generator.Generator;
import com.pholser.junit.quickcheck.random.SourceOfRandomness;
import store.sales.domain.model.orders.Order;
import store.sales.domain.model.orders.OrderItem;

import java.util.ArrayList;
import java.util.List;

public class OrderGenerator extends Generator<Order> {

    public OrderGenerator() {
        super(Order.class);
    }

    @Override
    public Order generate(SourceOfRandomness random, GenerationStatus status) {
        return new Order(1, generateItems(random, status));
    }

    private List<OrderItem> generateItems(SourceOfRandomness random, GenerationStatus status) {
        OrderItemGenerator productGenerator = gen().make(OrderItemGenerator.class);
        List<OrderItem> products = new ArrayList<>();
        products.add(productGenerator.generate(random, status));
        return products;
    }
}
