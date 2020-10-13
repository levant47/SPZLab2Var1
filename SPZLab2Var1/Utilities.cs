namespace SPZLab2Var1
{
    public static class Utilities
    {
        public static int? SafeParseInt(string source) => int.TryParse(source, out var result) ? (int?)result : null;
    }
}
