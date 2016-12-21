using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextSimilarity.Common.Extensions.String
{
    public static class ShinglesExtension
    {
        private const int DefaultShingleSize = 2;
        private const int DefaultShingleOverlap = 1;

        public static HashSet<string> CharacterShingles(this string value, int shingleSize = DefaultShingleSize, int shingleOverlap = DefaultShingleOverlap)
        {
            if (shingleOverlap >= shingleSize) throw new ArgumentException("Shingle overlap cannot be bigger than the shingle size");

            var result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (string.IsNullOrEmpty(value)) return result;

            var loopCount = value.Length - shingleSize;
            for (var i = 0; i <= loopCount; i = i + shingleSize - shingleOverlap) result.Add(value.Substring(i, shingleSize));

            return result;
        }

        public static HashSet<string> WordShingles(this string value, int shingleSize = DefaultShingleSize, int shingleOverlap = DefaultShingleOverlap)
        {
            if (shingleOverlap >= shingleSize) throw new ArgumentException("Shingle overlap cannot be bigger than the shingle size");

            var result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (string.IsNullOrEmpty(value)) return result;

            var words = Regex.Split(value, @"[\s\!\?\.\,\-]+", RegexOptions.CultureInvariant);
            var loopCount = words.Length - shingleSize;
            for (var i = 0; i <= loopCount; i = i + shingleSize - shingleOverlap) result.Add(string.Join(" ", words, i, shingleSize));

            return result;
        }
    }
}
