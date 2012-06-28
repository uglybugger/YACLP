using Yaclp.Attributes;

namespace Yaclp.BetterSample
{
    public class CommandLineParameters : IConfiguration
    {
        [ParameterDescription("The first name of the person using the program.")]
        public string FirstName { get; set; }

        [ParameterIsOptional]
        [ParameterDefault("Smith")]
        [ParameterDescription("The last name of the person using the program.")]
        public string Surname { get; set; }
    }
}