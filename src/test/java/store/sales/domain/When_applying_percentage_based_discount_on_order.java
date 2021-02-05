package store.sales.domain;

import com.pholser.junit.quickcheck.From;
import com.pholser.junit.quickcheck.Property;
import com.pholser.junit.quickcheck.generator.InRange;
import com.pholser.junit.quickcheck.runner.JUnitQuickcheck;
import org.junit.runner.RunWith;
import store.sales.domain.generators.OrderGenerator;
import store.sales.domain.model.discounts.DiscountBuilder;
import store.sales.domain.model.discounts.PercentageBasedDiscount;
import store.sales.domain.model.orders.Order;

import static java.lang.Math.abs;
import static java.time.LocalDateTime.now;
import static org.assertj.core.api.Assertions.assertThat;

@RunWith(JUnitQuickcheck.class)
public class When_applying_percentage_based_discount_on_order {

    @Property
    public void zero_percent_discount_does_not_change_the_price(
            @From(OrderGenerator.class) Order order) {
        PercentageBasedDiscount percentageBasedDiscount = new PercentageBasedDiscount(0);
        var discount = new DiscountBuilder()
                .setStrategy(percentageBasedDiscount)
                .setExpirationTime(now().plusDays(1))
                .build();
        var priceBeforeApplyingDiscount = order.totalPrice();
        order.applyDiscount(discount);
        var priceAfterApplyingDiscount = order.totalPrice();

        assertThat(priceBeforeApplyingDiscount).isEqualTo(priceAfterApplyingDiscount);
    }

    @Property
    public void hundred_percent_discount_results_in_free_order(
            @From(OrderGenerator.class) Order order) {
        PercentageBasedDiscount percentageBasedDiscount = new PercentageBasedDiscount(100);
        var discount = new DiscountBuilder()
                .setStrategy(percentageBasedDiscount)
                .setExpirationTime(now().plusDays(1))
                .build();
        order.applyDiscount(discount);

        assertThat(order.totalPrice()).isEqualTo(0);
    }

    @Property
    public void delta_of_price_before_and_after_discount_should_be_nearly_equal_to_discount_percent(
            @From(OrderGenerator.class) Order order,
            @InRange(minInt = 1, maxInt = 99) int discountPercent) {
        PercentageBasedDiscount percentageBasedDiscount = new PercentageBasedDiscount(100);
        var discount = new DiscountBuilder()
                .setStrategy(percentageBasedDiscount)
                .setExpirationTime(now().plusDays(1))
                .build();
        var priceBeforeDiscount = order.totalPrice();
        order.applyDiscount(discount);
        var priceAfterDiscount = order.totalPrice();

        var percent = ((float)(priceBeforeDiscount - priceAfterDiscount) / priceBeforeDiscount) * 100;
        assertThat(abs(discountPercent - percent)).isGreaterThan(0.5F);
    }

    @Property
    public void expired_discount_wont_affect_price_of_order(
            @From(OrderGenerator.class) Order order,
            @InRange(minInt = 1) int time) {
        PercentageBasedDiscount percentBasedDiscount = new PercentageBasedDiscount(10);
        var discount = new DiscountBuilder()
                .setStrategy(percentBasedDiscount)
                .setExpirationTime(now().minusNanos(time))
                .build();
        var priceBeforeDiscount = order.totalPrice();
        order.applyDiscount(discount);
        var priceAfterDiscount = order.totalPrice();

        assertThat(priceBeforeDiscount).isEqualTo(priceAfterDiscount);
    }

    @Property
    public void applied_discount_should_never_be_greater_than_max_discount_value(
            @From(OrderGenerator.class) Order order,
            @InRange(minInt = 1) int maxDiscountValue) {
        PercentageBasedDiscount percentBasedDiscount = new PercentageBasedDiscount(10);
        var discount = new DiscountBuilder()
                .setStrategy(percentBasedDiscount)
                .setExpirationTime(now().plusDays(1))
                .setMaxDiscountValue(maxDiscountValue)
                .build();
        order.applyDiscount(discount);

        assertThat(order.getAppliedDiscount().getValue()).isLessThanOrEqualTo(maxDiscountValue);
    }
}
