using System;

namespace Yaclp
{
    public class DefaultTypeConverter : ITypeConverter
    {
        public object Convert(string value, Type toType)
        {
            var targetType = Nullable.GetUnderlyingType(toType) ?? toType;
            return System.Convert.ChangeType(value, targetType);
        }
    }
}