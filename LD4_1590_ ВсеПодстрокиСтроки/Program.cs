using System;
using System.Collections.Generic;
using System.Linq;

namespace _1590
{
    internal class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine();
            var suffixes = TakeSuffixes(input);
            Console.WriteLine(CalculateAllSubstrings(suffixes));
        }

        private static int TakeMostLengthPrefixLength(string a, string b)
        {
            var len = 0;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                if (a[i] == b[i])
                    len++;
                else
                    break;

            return len;
        }

        private static int CalculateAllSubstrings(SortedSet<string> suffixes)
        {
            var previousSuffix = suffixes.First();
            var count = previousSuffix.Length;
            foreach (var suffix in suffixes.Skip(1))
            {
                count += suffix.Length - TakeMostLengthPrefixLength(previousSuffix, suffix);
                previousSuffix = suffix;
            }

            return count;
        }

        private static SortedSet<string> TakeSuffixes(string input)
        {
            var sortedSuffixes =new SortedSet<string>(StringComparer.Ordinal);
            for (int i = 0; i < input.Length; i++)
                sortedSuffixes.Add(input.Substring(i, input.Length - i));
            return sortedSuffixes;
        }
    }
}