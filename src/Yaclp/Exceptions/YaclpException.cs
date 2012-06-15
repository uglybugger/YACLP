using System;
using System.Text;

namespace Yaclp.Exceptions
{
    public abstract class YaclpException : Exception
    {
        private readonly Type _parametersType;

        protected YaclpException(Type parametersType)
        {
            _parametersType = parametersType;
        }

        protected abstract string UsageMessage { get; }

        public override sealed string Message
        {
            get
            {
                var sb = new StringBuilder();

                var specificMessage = UsageMessage;
                if (!string.IsNullOrWhiteSpace(specificMessage))
                {
                    sb.AppendLine(specificMessage);
                    sb.AppendLine();
                }

                var messageBuilder = new UsageMessageBuilder(_parametersType);
                sb.AppendLine(messageBuilder.Build());

                return sb.ToString();
            }
        }
    }
}