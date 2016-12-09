using System.Collections.Generic;
using System.Linq;

namespace TextSimilarity.Extensions.SorensenDiceCoefficient.Set
{
    public static class SorensenDiceCoefficientExtension
    {
        public static double SorensenDiceCoefficient<T>(this ISet<T> value, ISet<T> shingles)
        {
            var intersectCount = value.Intersect(shingles).Count();
            return 2 * intersectCount / (double)(value.Count + value.Count);
        }
    }
}
