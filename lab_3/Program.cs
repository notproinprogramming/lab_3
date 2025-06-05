using System;

namespace OnlineShopStrategy
{
    // Інтерфейс стратегії оплати
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    // Реалізація оплати карткою
    public class CardPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {amount:C} карткою успішна.");
        }
    }

    // Реалізація оплати через PayPal
    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {amount:C} через PayPal успішна.");
        }
    }

    // Реалізація оплати криптовалютою
    public class CryptoPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {amount:C} криптовалютою успішна.");
        }
    }

    // Контекст: обробник оплати
    public class PaymentProcessor
    {
        private IPaymentStrategy _paymentStrategy;

        // Метод встановлення стратегії
        public void SetPaymentMethod(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        // Виконання оплати через обрану стратегію
        public void ProcessPayment(decimal amount)
        {
            if (_paymentStrategy == null)
            {
                Console.WriteLine("Помилка: не обрано метод оплати.");
                return;
            }
            _paymentStrategy.Pay(amount);
        }
    }

    // Точка входу
    class Program
    {
        static void Main()
        {
            var paymentProcessor = new PaymentProcessor();

            // Оплата карткою
            paymentProcessor.SetPaymentMethod(new CardPayment());
            paymentProcessor.ProcessPayment(250.75m);

            // Оплата через PayPal
            paymentProcessor.SetPaymentMethod(new PayPalPayment());
            paymentProcessor.ProcessPayment(100.50m);

            // Оплата криптовалютою
            paymentProcessor.SetPaymentMethod(new CryptoPayment());
            paymentProcessor.ProcessPayment(1500.00m);
        }
    }
}
