using System;
using System.Linq;
using Yaclp.Extensions;

namespace Yaclp.Exceptions
{
    public class ParameterCountException : YaclpException
    {
        private readonly string _customMessage;

        public ParameterCountException(Type parametersType) : base(parametersType)
        {
            var mandatoryParameterCount = parametersType.GetProperties().Where(p => p.IsMandatory()).Count();

            _customMessage = "Incorrect number of parameters provided. At minimum, you need to provide {0}.".FormatWith(
                mandatoryParameterCount == 1
                    ? "the one required parameter"
                    : "the {0} required parameters".FormatWith(mandatoryParameterCount)
                );
        }

        protected override string UsageMessage
        {
            get { return _customMessage; }
        }
    }
}