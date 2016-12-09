namespace TextSimilarity.Extensions.SimHash.Integer
{
    public static class SimHashSimilarityIndexExtension
    {
        private const int HashSize = 32;

        public static int SimHashSimilarityIndex(this int value, int number)
        {
            return (HashSize - value.HammingDistance(number)) / HashSize;
        }
    }
}
