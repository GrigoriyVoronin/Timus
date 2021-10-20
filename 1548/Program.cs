using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1548
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var height = input[0];
            var weight = input[1];
            var table = new bool[height, weight];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    table[i, j] = bool.Parse(((char) Console.Read()).ToString());
                }
            }


        }
    }
}
