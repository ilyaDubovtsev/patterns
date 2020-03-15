using System;
using Patterns.Adapter;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== SimpleExample ==========");
            AdapterExample.GetSimpleExample();
            Console.WriteLine("========== PatternExample ==========");
            AdapterExample.GetPatternExample();
        }
    }
}