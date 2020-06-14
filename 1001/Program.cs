using System;
using System.Collections.Generic;
using System.Linq;

namespace _1000
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = new List<char>(128);
            var delimetrs = new[] {' ', '\r', '\n'};
            var output = new List<double>(128);
            for (var i = 0; i < 256 * 1024; i++)
            {
                var simbolInt = Console.Read();
                if (simbolInt == -1)
                    break;

                var simbolCh = (char) simbolInt;
                while (!delimetrs.Contains(simbolCh))
                {
                    numbers.Add(simbolCh);
                    simbolInt = Console.Read();
                    if (simbolInt == -1)
                        break;
                    simbolCh = (char) simbolInt;
                }

                if (numbers.Count != 0)
                {
                    output.Add(Math.Round(Math.Sqrt(double.Parse(new string(numbers.ToArray()))), 4));
                    numbers = new List<char>(128);
                }
            }

            output.Reverse();
            foreach (var numb in output) Console.WriteLine(numb);
        }
    }
}