using System.Globalization;

namespace Patterns.Adapter
{
    public class MoneyAdapter
    {
        private DollarClient _dollarClient;
        private EuroClient _euroClient;

        public MoneyAdapter()
        {
            _dollarClient = new DollarClient();
            _euroClient = new EuroClient();
        }

        public decimal GetRublesAmountFromDollars()
        {
            var dollarString = _dollarClient.GetTotalAmount()
                .Substring(1)
                .Replace(',', '.');
            var rubles = decimal.Parse(dollarString, CultureInfo.InvariantCulture) * 60.0m;
            return rubles;
        }

        public decimal GetRublesAmountFromEuros()
        {
            var euroSum = _euroClient.GetEuroSum();
            return euroSum * 70m;
        }
    }
}