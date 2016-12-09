using System.Collections.Generic;

namespace TextSimilarity.Extensions.Jaccard.Set
{
    public static class JaccardDistanceExtension
    {
        public static double JaccardDistance<T>(this ISet<T> value, ISet<T> shingles)
        {
            return 1.0 - value.JaccardIndex(shingles);
        }
    }
}
