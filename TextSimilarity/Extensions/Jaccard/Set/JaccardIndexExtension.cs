using System.Collections.Generic;
using System.Linq;

namespace TextSimilarity.Extensions.Jaccard.Set
{
    public static class JaccardIndexExtension
    {
        public static double JaccardIndex<T>(this ISet<T> value, ISet<T> shingles)
        {
            var unionCount = value.Union(shingles).Count();

            if (unionCount == 0 || unionCount == value.Count) return 1.0;

            var intersectCount = value.Intersect(shingles).Count();

            return intersectCount / (double)unionCount;
        }
    }
}
