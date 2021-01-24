package store.sales.domain;

import com.pholser.junit.quickcheck.From;
import com.pholser.junit.quickcheck.Property;
import com.pholser.junit.quickcheck.generator.Ctor;
import com.pholser.junit.quickcheck.runner.JUnitQuickcheck;
import org.junit.runner.RunWith;
import store.sales.domain.model.orders.Order;
import store.sales.domain.model.orders.OrderItem;

import java.util.List;

import static java.util.Arrays.asList;
import static java.util.Collections.singletonList;
import static org.assertj.core.api.Assertions.assertThat;

@RunWith(JUnitQuickcheck.class)
public class When_calculating_total_price_of_order {
    @Property
    public void total_price_of_order_is_equal_to_total_price_of_item_when_there_is_only_one_item(
            final @From(Ctor.class) OrderItem item) {
        var orderItems = singletonList(item);
        var order = new Order(1, orderItems);

        assertThat(order.totalPrice()).isEqualTo(item.totalPrice());
    }

    @Property
    public void subtracting_item_from_total_price_of_order_results_in_other_item(
            final @From(Ctor.class) OrderItem firstItem,
            final @From(Ctor.class) OrderItem secondItem) {
        List<OrderItem> items = asList(firstItem, secondItem);
        var order = new Order(1, items);

        assertThat(order.totalPrice() - firstItem.totalPrice()).isEqualTo(secondItem.totalPrice());
    }

    @Property
    public void subtracting_all_items_from_total_price_results_in_zero(
            final List<@From(Ctor.class) OrderItem> items) {
        var order = new Order(1, items);
        var totalPrice = order.totalPrice();

        for (OrderItem item : items) {
            totalPrice -= item.totalPrice();
        }

        assertThat(totalPrice).isEqualTo(0);
    }
}
