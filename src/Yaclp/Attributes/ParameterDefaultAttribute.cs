using System;

namespace Yaclp.Attributes
{
    [Serializable]
    public sealed class ParameterDefaultAttribute: Attribute
    {
        private readonly string _value;

        public ParameterDefaultAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}