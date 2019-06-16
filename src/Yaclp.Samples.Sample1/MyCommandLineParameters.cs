using Yaclp.Attributes;

namespace Yaclp.Samples.Sample1
{
    public class MyCommandLineParameters : IOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ParameterIsOptional]
        public int? Age { get; set; }
    }
}