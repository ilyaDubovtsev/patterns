using System;

namespace Patterns.Adapter
{
    public class EuroClient
    {
        public int GetEuroSum()
        {
            return MakeSpecificRequest();
        }

        private static int MakeSpecificRequest()
        {
            var random = new Random();
            return random.Next(1, 1000);
        }
    }
}