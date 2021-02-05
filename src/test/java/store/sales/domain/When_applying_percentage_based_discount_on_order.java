package store.sales.domain;

import com.pholser.junit.quickcheck.From;
import com.pholser.junit.quickcheck.Property;
import com.pholser.junit.quickcheck.runner.JUnitQuickcheck;
import org.junit.runner.RunWith;
import store.sales.domain.generators.OrderGenerator;
import store.sales.domain.model.discounts.DiscountBuilder;
import store.sales.domain.model.discounts.PercentageBasedDiscount;
import store.sales.domain.model.discounts.ValueBasedDiscount;
import store.sales.domain.model.orders.Order;

import static org.assertj.core.api.Assertions.assertThat;

@RunWith(JUnitQuickcheck.class)
public class When_applying_percentage_based_discount_on_order {

    @Property
    public void zero_percent_discount_does_not_change_the_price(
            @From(OrderGenerator.class) Order order) {
        PercentageBasedDiscount percentageBasedDiscount = new PercentageBasedDiscount(0);
        var discount = new DiscountBuilder().setStrategy(percentageBasedDiscount).build();
        var priceBeforeApplyingDiscount = order.totalPrice();
        order.applyDiscount(discount);
        var priceAfterApplyingDiscount = order.totalPrice();

        assertThat(priceBeforeApplyingDiscount).isEqualTo(priceAfterApplyingDiscount);
    }
}
