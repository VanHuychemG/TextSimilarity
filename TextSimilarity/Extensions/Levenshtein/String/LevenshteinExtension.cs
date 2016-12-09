using System;
using System.Collections.Generic;
using System.Linq;

namespace TextSimilarity.Extensions.Levenshtein.String
{
    public static class LevenshteinExtension
    {
        public static int LevenshteinDistance(this string value, string text)
        {
            if (string.Equals(value, text)) return 0;

            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(text))
                return (value ?? string.Empty).Length + (text ?? string.Empty).Length;

            if (value.Length > text.Length)
            {
                var tmp = value;
                value = text;
                text = tmp;
            }

            if (text.Contains(value)) return text.Length - value.Length;

            var distance = new int[value.Length + 1, text.Length + 1];

            for (var i = 0; i <= value.Length; distance[i, 0] = i++) { }
            for (var j = 0; j <= text.Length; distance[0, j] = j++) { }

            for (var i = 1; i <= value.Length; i++)
            {
                for (var j = 1; j <= text.Length; j++)
                {
                    var cost = (text[j - 1] == value[i - 1]) ? 0 : 1;

                    distance[i, j] = Math.Min(
                        Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                        distance[i - 1, j - 1] + cost);
                }
            }

            return distance[value.Length, text.Length];
        }

        public static int DamerauLevenshteinDistance(this string value, string text)
        {
            if (value == text) return 0;

            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(text))
                return (value ?? string.Empty).Length + (text ?? string.Empty).Length;

            if (value.Length > text.Length)
            {
                var tmp = value;
                value = text;
                text = tmp;
            }

            if (text.Contains(value)) return text.Length - value.Length;

            var m = value.Length;
            var n = text.Length;
            var h = new int[m + 2, n + 2];
            var inf = m + n;
            h[0, 0] = inf;

            for (var i = 0; i <= m; i++) { h[i + 1, 1] = i; h[i + 1, 0] = inf; }
            for (var j = 0; j <= n; j++) { h[1, j + 1] = j; h[0, j + 1] = inf; }

            var sd = new SortedDictionary<char, int>();
            foreach (var l in (value + text).Where(l => !sd.ContainsKey(l)))
                sd.Add(l, 0);

            for (var i = 1; i <= m; i++)
            {
                var db = 0;
                for (var j = 1; j <= n; j++)
                {
                    var i1 = sd[text[j - 1]];
                    var j1 = db;

                    if (value[i - 1] == text[j - 1])
                    {
                        h[i + 1, j + 1] = h[i, j];
                        db = j;
                    }
                    else h[i + 1, j + 1] = Math.Min(h[i, j], Math.Min(h[i + 1, j], h[i, j + 1])) + 1;
                    h[i + 1, j + 1] = Math.Min(h[i + 1, j + 1], h[i1, j1] + (i - i1 - 1) + 1 + (j - j1 - 1));
                }
                sd[value[i - 1]] = i;
            }

            return h[m + 1, n + 1];
        }
    }
}
