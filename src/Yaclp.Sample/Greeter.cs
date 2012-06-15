using System;

namespace Yaclp.Sample
{
    public class Greeter
    {
        private readonly IOptions _configSettings;

        public Greeter(IOptions configSettings)
        {
            _configSettings = configSettings;
        }

        public void SayHelloToTheNicePerson()
        {
            var isAdult = !_configSettings.Age.HasValue || _configSettings.Age >= 21;
            var message = isAdult
                              ? string.Format("Hello, Mr/Ms {0}.", _configSettings.LastName)
                              : string.Format("Hi, {0}!", _configSettings.FirstName);
            Console.WriteLine(message);
        }
    }
}