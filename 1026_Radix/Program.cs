using System;
using System.Collections.Generic;

namespace _1026_sort
{
    internal static class Program
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            for (var i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());
            Console.ReadLine();
            var k = int.Parse(Console.ReadLine());
            Sort(arr);
            for (var i = 0; i < k; i++)
                Console.WriteLine(arr[int.Parse(Console.ReadLine()) - 1]);
        }

        private static void Sort(IList<int> arr)
        {
            const int byteSize = 256;
            var currentByteValues = new int[arr.Count];
            var arrValuesCopy = new int[arr.Count];
            var indexArr = new int[byteSize];
            for (var shift = 0; shift < 4; shift++)
            {
                var valuesCount = new int[byteSize];
                int i;
                int j;
                for (i = 0; i < arr.Count; i++)
                {
                    j = (arr[i] >> (shift * 8)) % byteSize;
                    valuesCount[j]++;
                    currentByteValues[i] = j;
                    arrValuesCopy[i] = arr[i];
                }

                indexArr[0] = 0;
                for (i = 1, j = i - 1; i < byteSize; i++, j = i - 1)
                    indexArr[i] = valuesCount[j] + indexArr[j];
                for (i = 0; i < arr.Count; i++)
                    arr[indexArr[currentByteValues[i]]++] = arrValuesCopy[i];
            }
        }
    }
}
