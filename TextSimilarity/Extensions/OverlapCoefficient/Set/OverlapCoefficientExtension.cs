using System;
using System.Collections.Generic;
using System.Linq;

namespace TextSimilarity.Extensions.OverlapCoefficient.Set
{
    public static class OverlapCoefficientExtension
    {
        public static double OverlapCoefficient<T>(this ISet<T> value, ISet<T> shingles)
        {
            var minLength = Math.Min(value.Count, shingles.Count);
            if (minLength == 0) return 0;
            var intersectCount = value.Intersect(shingles).Count();
            return intersectCount / (double)minLength;
        }
    }
}
