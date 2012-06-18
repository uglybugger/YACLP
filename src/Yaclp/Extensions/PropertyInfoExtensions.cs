using System.Linq;
using System.Reflection;
using Yaclp.Attributes;

namespace Yaclp.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static bool IsMandatory(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes<ParameterIsOptionalAttribute>(true)
                .None();
        }

        public static bool IsOptional(this PropertyInfo propertyInfo)
        {
            return !IsMandatory(propertyInfo);
        }

        public static T[] GetCustomAttributes<T>(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes<T>(false);
        }

        public static T[] GetCustomAttributes<T>(this PropertyInfo propertyInfo, bool inherit)
        {
            return propertyInfo.GetCustomAttributes(typeof(T), inherit)
                .Cast<T>()
                .ToArray();
        }

        public static void SetValue<T>(this PropertyInfo propertyInfo, object target, T value)
        {
            propertyInfo.SetValue(target, value, null);
        }
    }
}