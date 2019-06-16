namespace Yaclp.Samples.Sample1
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