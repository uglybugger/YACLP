using System;
using Yaclp.Extensions;

namespace Yaclp.Exceptions
{
    public class PropertyNotFoundException : YaclpException
    {
        private readonly string _propertyName;

        public PropertyNotFoundException(string propertyName, Type parametersType) : base(parametersType)
        {
            _propertyName = propertyName;
        }

        protected override string UsageMessage
        {
            get { return "The parameter '{0}' was not recognised.".FormatWith(_propertyName); }
        }
    }
}