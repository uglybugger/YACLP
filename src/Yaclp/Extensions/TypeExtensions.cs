using System;
using System.Linq;
using System.Reflection;

namespace Yaclp.Extensions
{
    public static class TypeExtensions
    {
        public static PropertyInfo[] GetMandatoryProperties(this Type type)
        {
            var mandatoryProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(propertyInfo => propertyInfo.IsMandatory())
                .ToArray();
            return mandatoryProperties;
        }

        public static PropertyInfo[] GetOptionalProperties(this Type type)
        {
            var optionalProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(propertyInfo => propertyInfo.IsOptional())
                .ToArray();
            return optionalProperties;
        }


    }
}