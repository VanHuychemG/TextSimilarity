using System.Linq;

namespace TextSimilarity.Common.Extensions.String
{
    public static class GetHashCodeAltExtension
    {
        public static int GetHashCodeAlt(this string s)
        {
            unchecked
            {
                return s.Aggregate(23, (current, c) => current * 31 + c);
            }
        }

        public static int GetHashCodeAlt2(this string s)
        {
            unchecked
            {
                var hash1 = (5381 << 16) + 5381;
                var hash2 = hash1;

                for (var i = 0; i < s.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ s[i];
                    if (i == s.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ s[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }
    }
}
