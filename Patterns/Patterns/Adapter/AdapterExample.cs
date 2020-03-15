using System;
using System.Globalization;
using System.Linq;

namespace Patterns.Adapter
{
    public static class AdapterExample
    {
        public static void GetSimpleExample()
        {
            var dollarClient = new DollarClient();
            var euroClient = new EuroClient();

            Console.WriteLine("Получаем значения из двух клиентов:");
            
            var dollarAmount = dollarClient.GetTotalAmount();
            var euroAmount = euroClient.GetEuroSum();
            
            Console.WriteLine($"dollarClient.GetTotalAmount: {dollarAmount}");
            Console.WriteLine($"euroClient.GetEuroSum: {euroAmount}");

            Console.WriteLine($"Используем конвертеры для преобразования в рубли:");
            
            var dollarsInRubles = ConvertDollarsToRubles(dollarAmount);
            var euroInRubles = ConvertEuroToRubles(euroAmount);
            
            Console.WriteLine($"ConvertDollarsToRubles(dollarAmount): {dollarsInRubles}");
            Console.WriteLine($"ConvertEuroToRubles(euroAmount): {euroInRubles}");
            
            Console.WriteLine($"Вызываем сервисный метод:");
            var rubleService = new RubleService();
            rubleService.ReceiveReportInRubles(dollarsInRubles);
            rubleService.ReceiveReportInRubles(euroInRubles);
        }

        public static void GetPatternExample()
        {
            Console.WriteLine("Вызываем адаптер:");
            
            var moneyAdapter = new MoneyAdapter();
            var rublesAmountFromDollars = moneyAdapter.GetRublesAmountFromDollars();
            var rublesAmountFromEuros = moneyAdapter.GetRublesAmountFromEuros();
            
            Console.WriteLine($"moneyAdapter.GetRublesAmountFromDollars: {rublesAmountFromDollars}");
            Console.WriteLine($"moneyAdapter.GetRublesAmountFromEuros {rublesAmountFromEuros}");
            
            Console.WriteLine("Вызываем сервисный метод:");
            
            var rubleService = new RubleService();
            rubleService.ReceiveReportInRubles(rublesAmountFromDollars);
            rubleService.ReceiveReportInRubles(rublesAmountFromEuros);
        }

        private static decimal ConvertDollarsToRubles(string amount)
        {
            var dollarString = amount
                .Substring(1)
                .Replace(',', '.');
            var rubles = decimal.Parse(dollarString, CultureInfo.InvariantCulture) * 60.0m;
            return rubles;
        }

        private static decimal ConvertEuroToRubles(int amount)
        {
            return amount * 70.0m;
        }
    }
}