using Yaclp.Attributes;

namespace Yaclp.Tests.GivenAModelWithMandatoryAndOptionalParameters
{
    public class ModelWithMandatoryAndOptionalParameters
    {
        public string Foo { get; set; }

        [ParameterIsOptional]
        public string Bar { get; set; }

        [ParameterIsOptional]
        public string Baz { get; set; }
    }
}