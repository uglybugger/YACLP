using System.Collections.Generic;

namespace Yaclp
{
    public static class DefaultParser
    {
        public static T Parse<T>(IEnumerable<string> args) where T : class, new()
        {
            return YaclpParserFactory.CreateParserFor<T>().Parse(args);
        }

        public static T ParseOrExitWithUsageMessage<T>(IEnumerable<string> args) where T : class, new()
        {
            return YaclpParserFactory.CreateParserFor<T>().ParseOrExitWithUsageMessage(args);
        }
    }
}