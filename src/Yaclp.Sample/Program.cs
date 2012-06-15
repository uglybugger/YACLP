using System;
using Yaclp.Exceptions;

namespace Yaclp.Sample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyCommandLineParameters options;

            try
            {
                options = new Parser<MyCommandLineParameters>().Parse(args);
            }
            catch (YaclpException exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadKey();
                return;
            }

            new Greeter(options).SayHelloToTheNicePerson();
            Console.ReadKey();
        }
    }
}