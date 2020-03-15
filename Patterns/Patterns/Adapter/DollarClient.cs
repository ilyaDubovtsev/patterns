using System;

namespace Patterns.Adapter
{
    public class DollarClient
    {
        public string GetTotalAmount()
        {
            return MakeSpecificRequest();
        }

        private static string MakeSpecificRequest()
        {
            var random = new Random();
            var amount = random.Next(1, 1000) / 100.0;
            return $"${amount}";
        }
    }
}