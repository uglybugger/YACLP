namespace Yaclp
{
    public static class YaclpParserFactory
    {
        public static Parser<T> CreateParserFor<T>() where T : class, new()
        {
            return new Parser<T>(new DefaultTypeConverter());
        }
    }
}