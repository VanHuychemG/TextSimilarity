using System.Text.RegularExpressions;

namespace TextSimilarity.Common.Extensions.String
{
    public static class ToSingleLineExtension
    {
        public static string ToSingleLine(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            var s = Regex.Replace(value, "<[^>]*>|\r\n|\r|\n", " ", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            s = Regex.Replace(s, @"\s+", " ", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            return s.Trim();
        }
    }
}
