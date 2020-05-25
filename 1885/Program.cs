using System;

namespace Expr10
{
    class Program
    {
        static void Main()
        {
            string userInput = Console.ReadLine();
            var data = userInput.Split();
            double h = double.Parse(data[0]);
            double t = double.Parse(data[1]);
            double v = double.Parse(data[2]);
            double x = double.Parse(data[3]);
            double minTime = 0;
            double maxTime = 0;
            double minSpeed = h / t;
            if (minSpeed < x)
            {
                Console.Write(minTime);
                maxTime = Math.Round((h / (x)), 6);
                Console.Write(' ');
                Console.Write(maxTime);
            }
            else
            {
                minTime = Math.Round(((h-t*x)/(v-x)), 6);
                maxTime = Math.Round((h / minSpeed), 6);
                Console.Write(minTime);
                Console.Write(' ');
                Console.Write(maxTime);
            }
        }
    }
}