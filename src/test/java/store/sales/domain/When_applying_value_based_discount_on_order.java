package store.sales.domain;

import com.pholser.junit.quickcheck.From;
import com.pholser.junit.quickcheck.Property;
import com.pholser.junit.quickcheck.generator.InRange;
import com.pholser.junit.quickcheck.runner.JUnitQuickcheck;
import org.junit.runner.RunWith;
import store.sales.domain.generators.OrderGenerator;
import store.sales.domain.model.discounts.DiscountBuilder;
import store.sales.domain.model.discounts.ValueBasedDiscount;
import store.sales.domain.model.orders.Order;

import static org.assertj.core.api.Assertions.assertThat;
import static org.hamcrest.Matchers.*;
import static org.junit.Assume.assumeThat;

@RunWith(JUnitQuickcheck.class)
public class When_applying_value_based_discount_on_order {

    @Property
    public void zero_discount_does_not_change_the_price(@From(OrderGenerator.class) Order order) {
        ValueBasedDiscount valueBasedDiscount = new ValueBasedDiscount(0);
        var discount = new DiscountBuilder().setStrategy(valueBasedDiscount).build();
        var priceBeforeApplyingDiscount = order.totalPrice();
        order.applyDiscount(discount);
        var priceAfterApplyingDiscount = order.totalPrice();

        assertThat(priceBeforeApplyingDiscount).isEqualTo(priceAfterApplyingDiscount);
    }

    @Property
    public void applying_discount_results_in_free_order_when_discount_value_is_greater_than_price(
            @From(OrderGenerator.class) Order order,
            @InRange(minInt = 401) int discountValue) {
        ValueBasedDiscount valueBasedDiscount = new ValueBasedDiscount(discountValue);
        var discount = new DiscountBuilder().setStrategy(valueBasedDiscount).build();
        order.applyDiscount(discount);
        var priceAfterApplyingDiscount = order.totalPrice();

        assertThat(priceAfterApplyingDiscount).isEqualTo(0);
    }

    @Property
    public void adding_value_of_discount_to_total_price_results_in_total_price_before_applying_discount(
            @From(OrderGenerator.class) Order order,
            @InRange(minInt = 0) int discountValue) {
        var priceBeforeApplyingDiscount = order.totalPrice();
        assumeThat(priceBeforeApplyingDiscount, lessThan(discountValue));
        if (priceBeforeApplyingDiscount < discountValue) discountValue = 0;
        ValueBasedDiscount valueBasedDiscount = new ValueBasedDiscount(discountValue);
        var discount = new DiscountBuilder().setStrategy(valueBasedDiscount).build();
        order.applyDiscount(discount);
        var priceAfterApplyingDiscount = order.totalPrice();

        assertThat(priceAfterApplyingDiscount + discountValue)
                .isEqualTo(priceBeforeApplyingDiscount);
    }
}
