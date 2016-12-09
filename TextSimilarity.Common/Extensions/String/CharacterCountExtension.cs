using System.Collections.Generic;

namespace TextSimilarity.Common.Extensions.String
{
    public static class CharacterCountExtension
    {
        public static Dictionary<char, int> CharacterCount(this string value)
        {
            var result = new Dictionary<char, int>();

            if (string.IsNullOrEmpty(value)) return result;

            foreach (var feature in value)
            {
                if (result.ContainsKey(feature)) result[feature]++;
                else result[feature] = 1;
            }

            return result;
        }
    }
}
