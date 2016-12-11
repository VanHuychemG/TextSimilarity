using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TextSimilarity.Common.Extensions.String
{
    public static class WordCountExtension
    {
        public static Dictionary<string, int> WordCount(this string value)
        {
            var result = new Dictionary<string, int>(
                CultureInfo.InvariantCulture.CompareInfo.GetStringComparer(CompareOptions.IgnoreCase));
            if (string.IsNullOrEmpty(value)) return result;

            var words = Regex.Split(value, @"[\s]+");
            foreach (var word in words)
            {
                if (result.ContainsKey(word)) result[word]++;
                else result[word] = 1;
            }

            return result;
        }
    }
}
