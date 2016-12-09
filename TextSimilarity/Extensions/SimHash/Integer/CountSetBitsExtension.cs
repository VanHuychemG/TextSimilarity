namespace TextSimilarity.Extensions.SimHash.Integer
{
    public static class CountSetBitsExtension
    {
        public static int CountSetBits(this int value)
        {
            var count = ((value & 0xfff) * 0x1001001001001 & 0x84210842108421) % 0x1f;
            count += (((value & 0xfff000) >> 12) * 0x1001001001001 & 0x84210842108421) % 0x1f;
            count += ((value >> 24) * 0x1001001001001 & 0x84210842108421) % 0x1f;
            return (int)count;
        }
    }
}
