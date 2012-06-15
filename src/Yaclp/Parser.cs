using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Yaclp.Attributes;
using Yaclp.Exceptions;
using Yaclp.Extensions;

namespace Yaclp
{
    public class Parser<T> where T : class, new()
    {
        public T Parse(IEnumerable<string> args)
        {
            var argStack = new Stack<string>(args.Reverse());

            var result = new T();
            PopulateDefaultProperties(result);
            PopulateMandatoryProperties(result, argStack);
            PopulateOptionalProperties(result, argStack);
            return result;
        }

        private static void PopulateDefaultProperties(T result)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                var defaultValueAttribute = prop.GetCustomAttributes<ParameterDefaultAttribute>().FirstOrDefault();
                if (defaultValueAttribute == null) continue;
                var value = Convert.ChangeType(defaultValueAttribute.Value, prop.PropertyType);
                prop.SetValue(result, value);
            }
        }

        private static void PopulateMandatoryProperties(T result, Stack<string> argStack)
        {
            var mandatoryProperties = typeof(T).GetMandatoryProperties();

            if (argStack.Count() < mandatoryProperties.Count()) throw new ParameterCountException(typeof(T));

            foreach (var prop in mandatoryProperties)
            {
                var requiredArg = argStack.Pop();
                var value = Convert.ChangeType(requiredArg, prop.PropertyType);
                prop.SetValue(result, value);
            }
        }

        private static void PopulateOptionalProperties(T result, Stack<string> argStack)
        {
            while (argStack.Any())
            {
                var optionalArg = argStack.Pop();

                if (optionalArg[0] != '/') throw new OptionalArgumentFormatException(optionalArg, typeof(T));
                var colonIndex = optionalArg.IndexOf(':');
                if (colonIndex < 0) throw new OptionalArgumentFormatException(optionalArg, typeof(T));

                var propertyName = optionalArg.Substring(1, colonIndex - 1);
                var propertyValue = optionalArg.Substring(colonIndex + 1);
                var prop = typeof(T).GetProperty(propertyName);
                if (prop == null) throw new PropertyNotFoundException(propertyName, typeof(T));
                if (!prop.IsOptional()) throw new PropertyNotOptionalException(propertyName, typeof(T));

                var value = Convert.ChangeType(propertyValue, prop.PropertyType);
                prop.SetValue(result, value);
            }
        }
    }
}