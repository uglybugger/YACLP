using System;

namespace Yaclp.Samples.Sample2
{
    public class Greeter
    {
        private readonly IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SayHello()
        {
            var message = string.IsNullOrEmpty(_configuration.Surname)
                              ? string.Format("Hi, {0}!", _configuration.FirstName)
                              : string.Format("Hello, Mr/Ms {0}", _configuration.Surname);

            Console.WriteLine(message);
        }
    }
}