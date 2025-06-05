using System;
using System.IO;
using NUnit.Framework;
using OnlineShopStrategy;

namespace OnlineShopStrategy.Tests
{
    [TestFixture]
    public class PaymentProcessorTests
    {
        [Test]
        public void ProcessPayment_NoStrategy_PrintsError()
        {
            var processor = new PaymentProcessor();
            using var output = new StringWriter();
            var original = Console.Out;
            Console.SetOut(output);

            processor.ProcessPayment(10m);

            Console.SetOut(original);
            var expected = $"Помилка: не обрано метод оплати.{Environment.NewLine}";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void ProcessPayment_WithCardPayment_PrintsSuccess()
        {
            var processor = new PaymentProcessor();
            using var output = new StringWriter();
            var original = Console.Out;
            Console.SetOut(output);

            processor.SetPaymentMethod(new CardPayment());
            processor.ProcessPayment(250.75m);

            Console.SetOut(original);
            var expected = $"Оплата {250.75m:C} карткою успішна.{Environment.NewLine}";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void ProcessPayment_WithPayPalPayment_PrintsSuccess()
        {
            var processor = new PaymentProcessor();
            using var output = new StringWriter();
            var original = Console.Out;
            Console.SetOut(output);

            processor.SetPaymentMethod(new PayPalPayment());
            processor.ProcessPayment(100.50m);

            Console.SetOut(original);
            var expected = $"Оплата {100.50m:C} через PayPal успішна.{Environment.NewLine}";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void ProcessPayment_WithCryptoPayment_PrintsSuccess()
        {
            var processor = new PaymentProcessor();
            using var output = new StringWriter();
            var original = Console.Out;
            Console.SetOut(output);

            processor.SetPaymentMethod(new CryptoPayment());
            processor.ProcessPayment(1500.00m);

            Console.SetOut(original);
            var expected = $"Оплата {1500.00m:C} криптовалютою успішна.{Environment.NewLine}";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }
    }
}