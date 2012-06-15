using System;

namespace Yaclp.Attributes
{
    public sealed class ParameterDescriptionAttribute : Attribute
    {
        private readonly string _description;

        public ParameterDescriptionAttribute(string description)
        {
            _description = description;
        }

        public string Description
        {
            get { return _description; }
        }
    }
}