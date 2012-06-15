using System;

namespace Yaclp.Attributes
{
    public sealed class ParameterExampleAttribute : Attribute
    {
        private readonly string _example;

        public ParameterExampleAttribute(string example)
        {
            _example = example;
        }

        public string Example
        {
            get { return _example; }
        }
    }
}