using System;
using Yaclp.Extensions;

namespace Yaclp.Exceptions
{
    internal class PropertyNotOptionalException : YaclpException
    {
        private readonly string _propertyName;

        public PropertyNotOptionalException(string propertyName, Type parametersType) : base(parametersType)
        {
            _propertyName = propertyName;
        }

        protected override string UsageMessage
        {
            get
            {
                return
                    "The property '{0}' was supplied as an optional parameter but is mandatory. You don't need the /{0}:<value> syntax; just use <value>".FormatWith(_propertyName);
            }
        }
    }
}