using System;
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
        public Property adding_value_of_discount_to_total_price_results_in_total_price_before_applying_discount(long totalPrice)
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

        [Property]
        public Property expired_discount_wont_affect_price_of_order(Order order, DateTime expireDateOfDiscount)
        {
            var discount = new DiscountBuilder().AsValueBasedDiscount(100).WithExpireDateAs(expireDateOfDiscount).Build();
            var priceBeforeDiscount = order.TotalPrice();
            order.ApplyDiscount(discount);
            var priceAfterDiscount = order.TotalPrice();

            return (priceBeforeDiscount == priceAfterDiscount)
                .When(expireDateOfDiscount < DateTime.Now);
        }

        [Property]
        public Property sum_of_applied_discount_and_price_after_discount_results_in_price_before_discount(Order order)
        {
            return Prop.ForAll(DiscountValueGenerator.GenerateWithMaximumValueOf(order.TotalPrice()), discountValue =>
            {
                var discount = new DiscountBuilder().AsValueBasedDiscount(discountValue).Build();
                var priceBeforeDiscount = order.TotalPrice();
                order.ApplyDiscount(discount);
                return (order.TotalPrice() + order.AppliedDiscount.Value == priceBeforeDiscount).ToProperty();
            }).When(order.TotalPrice() > 0);
        }

        [Property]
        public Property applied_discount_should_never_be_greater_than_max_discount_value(Order order, PositiveInt discountValue, PositiveInt maxDiscountValue)
        {
            var discount = new DiscountBuilder()
                .AsValueBasedDiscount(discountValue.Get)
                .WithMaxDiscountValue(maxDiscountValue.Get)
                .Build();

            order.ApplyDiscount(discount);
            return (order.AppliedDiscount.Value <= maxDiscountValue.Get).ToProperty();
        }
    }
}