using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using FsCheck;
using FsCheck.Xunit;
using Sales.Domain.Model.Discounts;
using Sales.Domain.Model.Orders;
using Sales.Domain.Tests.Generators;
using Sales.Domain.Tests.TestHelpers;

namespace Sales.Domain.Tests
{
    public class When_applying_value_based_discount_on_order
    {
        public When_applying_value_based_discount_on_order()
        {
            Arb.Register<OrderGenerator>();
        }

        [Property]
        public Property zero_discount_does_not_change_the_price(Order order)
        {
            var discount = new DiscountBuilder().AsValueBasedDiscount(0).Build();
            var priceBeforeApplyingDiscount = order.TotalPrice();
            order.ApplyDiscount(discount);
            var priceAfterApplyingDiscount = order.TotalPrice();

            return (priceBeforeApplyingDiscount == priceAfterApplyingDiscount).ToProperty();
        }

        [Property]
        public Property applying_discount_results_in_free_order_when_discount_value_is_greater_than_price(long totalPrice)
        {
            return Prop.ForAll(DiscountValueGenerator.GenerateWithMinimumValueOf(totalPrice), discountValue =>
            {
                var order = OrderTestFactory.CreateOrderWithTotalPriceOf(totalPrice);
                var discount = new DiscountBuilder().AsValueBasedDiscount(discountValue).Build();
                order.ApplyDiscount(discount);
                return order.TotalPrice() == 0;
            }).When(totalPrice > 0);
        }

        [Property]
        public Property adding_value_of_discount_to_total_price_results_in_total_price(long totalPrice)
        {
            return Prop.ForAll(DiscountValueGenerator.GenerateWithMaximumValueOf(totalPrice), discountValue =>
            {
                var order = OrderTestFactory.CreateOrderWithTotalPriceOf(totalPrice);
                var priceBeforeDiscount = order.TotalPrice();
                var discount = new DiscountBuilder().AsValueBasedDiscount(discountValue).Build();

                order.ApplyDiscount(discount);
                var priceAfterDiscount = order.TotalPrice();

                return priceAfterDiscount + discountValue == priceBeforeDiscount;
            }).When(totalPrice > 0);
        }
    }
}