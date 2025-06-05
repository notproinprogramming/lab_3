using System;

namespace OnlineShopStrategy
{
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    public class CardPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {amount:C} карткою успішна.");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {amount:C} через PayPal успішна.");
        }
    }

    public class CryptoPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {amount:C} криптовалютою успішна.");
        }
    }

    public class PaymentProcessor
    {
        private IPaymentStrategy _paymentStrategy;

        public void SetPaymentMethod(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

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

    class Program
    {
        static void Main()
        {
            var paymentProcessor = new PaymentProcessor();

            paymentProcessor.SetPaymentMethod(new CardPayment());
            paymentProcessor.ProcessPayment(250.75m);

            paymentProcessor.SetPaymentMethod(new PayPalPayment());
            paymentProcessor.ProcessPayment(100.50m);

            paymentProcessor.SetPaymentMethod(new CryptoPayment());
            paymentProcessor.ProcessPayment(1500.00m);
        }
    }
}
