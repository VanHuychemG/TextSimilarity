using System;
using System.Collections.Generic;

namespace TextSimilarity.Extensions.SimHash.Set
{
    public static class SimHashExtension
    {
        private const int NumberOfBitsInAByte = 8;

        public static int SimHash<T>(this ISet<T> value, Func<T, int> hashFunction)
        {
            var hashVector = new int[sizeof(int) * NumberOfBitsInAByte];

            var simHash = 0;

            foreach (var shingle in value)
            {
                var tempHash = hashFunction(shingle);
                var mask = 1;
                for (var j = 0; j < hashVector.Length; j++)
                {
                    if ((tempHash & mask) > 0)
                        hashVector[j]++;
                    else
                        hashVector[j]--;
                    mask <<= 1;
                }
            }

            for (var i = 0; i < hashVector.Length; i++)
                if (hashVector[i] > 0)
                    simHash |= 1 << i;

            return simHash;
        }
    }
}
