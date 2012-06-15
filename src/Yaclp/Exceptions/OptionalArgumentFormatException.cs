using System;
using Yaclp.Extensions;

namespace Yaclp.Exceptions
{
    public class OptionalArgumentFormatException : YaclpException
    {
        private readonly string _optionalArg;

        public OptionalArgumentFormatException(string optionalArg, Type parametersType) : base(parametersType)
        {
            _optionalArg = optionalArg;
        }

        protected override string UsageMessage
        {
            get { return "Invalid argument, '{0}'. Optional arguments should be specified in /ArgName:<ArgValue> format".FormatWith(_optionalArg); }
        }
    }
}