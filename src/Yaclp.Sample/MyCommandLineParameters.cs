using Yaclp.Attributes;

namespace Yaclp.Sample
{
    public class MyCommandLineParameters : IOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ParameterIsOptional]
        public int? Age { get; set; }
    }
}