using System;
using FsCheck;
using FsCheck.Xunit;
using Sales.Domain.Model.Orders;
using Sales.Domain.Tests.Generators;
using Sales.Domain.Tests.TestHelpers;
using Xunit;

namespace Sales.Domain.Tests
{
    public class When_applying_percentage_based_discount_on_order
    {
        public When_applying_percentage_based_discount_on_order()
        {
            Arb.Register<OrderGenerator>();
        }

        [Property]
        public Property zero_percent_discount_does_not_change_the_price(Order order)
        {
            var discount = new DiscountBuilder().AsPercentageBasedDiscount(0).Build();
            var priceBeforeApplyingDiscount = order.TotalPrice();
            order.ApplyDiscount(discount);
            var priceAfterApplyingDiscount = order.TotalPrice();

            return (priceBeforeApplyingDiscount == priceAfterApplyingDiscount).ToProperty();
        }

        [Property]
        public Property hundred_percent_discount_results_in_free_order(Order order)
        {
            var discount = new DiscountBuilder().AsPercentageBasedDiscount(100).Build();
            order.ApplyDiscount(discount);

            return (order.TotalPrice() == 0).ToProperty();
        }


        [Property]
        public Property delta_of_price_before_and_after_discount_should_be_nearly_equal_to_discount_percent(Order order)
        {
            return Prop.ForAll(DiscountPercentGenerator.Generate(), discountPercent =>
            {
                var discount = new DiscountBuilder().AsPercentageBasedDiscount(discountPercent).Build();
                var priceBeforeDiscount = order.TotalPrice();
                order.ApplyDiscount(discount);
                var priceAfterDiscount = order.TotalPrice();

                var percent = ((float)(priceBeforeDiscount - priceAfterDiscount) / priceBeforeDiscount) * 100;
                var result = Math.Abs(discountPercent - percent) < 0.5;
                return result;
            }).When(order.TotalPrice() > 0);
        }

        [Property]
        public Property expired_discount_wont_affect_price_of_order(Order order, DateTime expireDateOfDiscount)
        {
            var discount = new DiscountBuilder().AsPercentageBasedDiscount(100).WithExpireDateAs(expireDateOfDiscount).Build();
            var priceBeforeDiscount = order.TotalPrice();
            order.ApplyDiscount(discount);
            var priceAfterDiscount = order.TotalPrice();

            return (priceBeforeDiscount == priceAfterDiscount)
                .When(expireDateOfDiscount < DateTime.Now);
        }

        [Property]
        public Property sum_of_applied_discount_and_price_after_discount_results_in_price_before_discount(Order order)
        {
            return Prop.ForAll(DiscountPercentGenerator.Generate(), discountPercent =>
            {
                var discount = new DiscountBuilder().AsPercentageBasedDiscount(discountPercent).Build();
                var priceBeforeDiscount = order.TotalPrice();
                order.ApplyDiscount(discount);
                var x = order.TotalPrice();
                return (order.TotalPrice() + order.AppliedDiscount.Value == priceBeforeDiscount).ToProperty();
            }).When(order.TotalPrice() > 0);
        }

        [Property]
        public Property applied_discount_should_never_be_greater_than_max_discount_value(Order order, PositiveInt maxDiscountValue)
        {
            return Prop.ForAll(DiscountPercentGenerator.Generate(), discountPercent =>
            {
                var discount = new DiscountBuilder()
                                    .AsPercentageBasedDiscount(discountPercent)
                                    .WithMaxDiscountValue(maxDiscountValue.Get)
                                    .Build();

                order.ApplyDiscount(discount);
                return (order.AppliedDiscount.Value <= maxDiscountValue.Get).ToProperty();
            });
        }
    }
}