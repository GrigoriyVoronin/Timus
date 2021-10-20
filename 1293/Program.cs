using System;
using System.Linq;

namespace _1293
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Aggregate((a, b) => a * b) * 2);
        }
    }
}
