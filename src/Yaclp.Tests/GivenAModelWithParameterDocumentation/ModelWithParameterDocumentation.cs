using Yaclp.Attributes;

namespace Yaclp.Tests.GivenAModelWithSomeParameterDescriptions
{
    public class ModelWithParameterDocumentation
    {
        [ParameterIsOptional]
        [ParameterDescription("This is Foo")]
        public string Foo { get; set; }

        [ParameterIsOptional]
        [ParameterDefault("Bar Default")]
        public string Bar { get; set; }

        [ParameterIsOptional]
        [ParameterExample("Baz Example")]
        public string Baz { get; set; }

        [ParameterIsOptional]
        public string MuchLongerParameterNameToMessUpFormatting { get; set; }

        [ParameterIsOptional]
        [ParameterExample("All Example")]
        [ParameterDefault("All Default")]
        [ParameterDescription("This is All")]
        public string All { get; set; }

        [ParameterIsOptional]
        [ParameterDefault("DescAndDefault Default")]
        [ParameterDescription("This is DescAndDefault")]
        public string DescAndDefault { get; set; }
    }
}