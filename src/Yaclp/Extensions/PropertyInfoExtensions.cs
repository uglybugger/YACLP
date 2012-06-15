using System.Reflection;
using Yaclp.Attributes;

namespace Yaclp.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static bool IsMandatory(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes<ParameterIsOptionalAttribute>()
                .None();
        }

        public static bool IsOptional(this PropertyInfo propertyInfo)
        {
            return !IsMandatory(propertyInfo);
        }
    }
}