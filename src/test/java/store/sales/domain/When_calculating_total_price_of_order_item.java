package store.sales.domain;

import com.pholser.junit.quickcheck.Property;
import com.pholser.junit.quickcheck.generator.InRange;
import com.pholser.junit.quickcheck.runner.JUnitQuickcheck;
import org.junit.runner.RunWith;
import store.sales.domain.model.orders.OrderItem;

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

    @Property
    public void total_price_is_equal_to_each_price_when_amount_is_one(
            @InRange(minInt = 0) int price) {
        var orderItem = new OrderItem(LAPTOP, 1, price);
        assertThat(orderItem.totalPrice()).isEqualTo(price);
    }

    @Property
    public void total_price_is_equal_to_add_each_price_to_itself_amount_times(
            @InRange(minInt = 0, maxInt = 20) int amount, @InRange(minInt = 0, maxInt = 20) int eachPrice) {
        var orderItem = new OrderItem(LAPTOP, amount, eachPrice);
        var expectedTotalPrice = 0;
        for (int i = 0; i < amount; i++) {
            expectedTotalPrice += eachPrice;
        }

        assertThat(orderItem.totalPrice()).isEqualTo(expectedTotalPrice);
    }
}
