using System;

namespace Patterns.Adapter
{
    class RubleService
    {
        public void ReceiveReportInRubles(decimal amount)
        {
            Console.WriteLine($"OK {amount}");
        }
    }
}