using System;

namespace Yaclp.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var options = YaclpParserFactory.CreateParserFor<MyCommandLineParameters>().ParseOrExitWithUsageMessage(args);
                new Greeter(options).SayHelloToTheNicePerson();
            }
            finally
            {
                Console.Write("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}