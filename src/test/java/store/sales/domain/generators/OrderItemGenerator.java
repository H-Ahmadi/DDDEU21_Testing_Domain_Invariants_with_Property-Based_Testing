package store.sales.domain.generators;

import com.pholser.junit.quickcheck.generator.GenerationStatus;
import com.pholser.junit.quickcheck.generator.Generator;
import com.pholser.junit.quickcheck.random.SourceOfRandomness;
import store.sales.domain.model.orders.OrderItem;

public class OrderItemGenerator extends Generator<OrderItem> {
    private int MAX = Integer.MAX_VALUE;
    private int MIN = 0;

    public OrderItemGenerator() {
        super(OrderItem.class);
    }

    @Override
    public OrderItem generate(SourceOfRandomness random, GenerationStatus status) {
        PositiveIntGenerator positiveInt = gen().make(PositiveIntGenerator.class);
        positiveInt.configure(MIN, MAX);
        return new OrderItem(1,
                positiveInt.generate(random, status),
                positiveInt.generate(random, status));
    }
}
