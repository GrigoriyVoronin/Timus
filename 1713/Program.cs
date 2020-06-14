using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1713
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLength = int.Parse(Console.ReadLine());
            var commands = new HashSet<string>();
            for (var i = 0; i < inputLength; i++)
            {
                commands.Add(Console.ReadLine());
            }
        }
    }
}
