namespace TextSimilarity.Extensions.SimHash.Integer
{
    public static class HammingDistanceExtension
    {
        public static int HammingDistance(this int value, int number)
        {
            var dist = value ^ number;
            return dist.CountSetBits();
        }
    }
}
