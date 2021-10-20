using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDU
{
    class Program
    {
        class LRU<T>
        {
            private Dictionary<int, T> data = new Dictionary<int, T>();

            private Dictionary<int, int> dataUnused = new Dictionary<int, int>();

            void Add(int key, T value)
            {
                data[key] = value;
                foreach (var pair in dataUnused)
                    dataUnused[pair.Key] += 1;
                dataUnused[key] = 0;
            }

            T Get(int key)
            {
                foreach (var pair in dataUnused)
                    dataUnused[pair.Key] += 1;
                dataUnused[key] = 0;
                return data[key];
            }

            void RemoveLeastRecentlyUsed()
            {
                var keyToRem = dataUnused
                    .First(x => x.Value == dataUnused.Max(y => y.Value))
                    .Key;
                data.Remove(keyToRem);
                dataUnused.Remove(keyToRem);
            }
        }
    }
}
