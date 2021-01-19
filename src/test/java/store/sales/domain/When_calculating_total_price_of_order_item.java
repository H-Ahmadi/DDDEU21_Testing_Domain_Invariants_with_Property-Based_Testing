package store.sales.domain;

import com.pholser.junit.quickcheck.Property;
import com.pholser.junit.quickcheck.generator.InRange;
import com.pholser.junit.quickcheck.runner.JUnitQuickcheck;
import org.assertj.core.api.Assertions;
import org.junit.runner.RunWith;
import store.sales.domain.model.orders.OrderItem;
import store.sales.domain.test.helpers.TestProducts;

import static org.assertj.core.api.Assertions.assertThat;
import static store.sales.domain.test.helpers.TestProducts.LAPTOP;

@RunWith(JUnitQuickcheck.class)
public class When_calculating_total_price_of_order_item {
    @Property
    public void each_price_of_zero_always_results_in_total_price_of_zero(
            @InRange(minInt = 0) int amount) {
        var orderItem = new OrderItem(LAPTOP, amount, 0);
        assertThat(orderItem.totalPrice()).isEqualTo(0);
    }
}
