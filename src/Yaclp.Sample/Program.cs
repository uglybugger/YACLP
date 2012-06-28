namespace Yaclp.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = DefaultParser.ParseOrExitWithUsageMessage<MyCommandLineParameters>(args);

            new Greeter(options).SayHelloToTheNicePerson();
        }
    }
}