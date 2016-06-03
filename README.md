#YACLP
##Yet Another Command-Line Parser

It's on NuGet:

    Install-Package YACLP

Why another one?

Because there were a bunch out there but all of them focused more on the parsing than on being quick and easy to call.

I want my command-line parser to not only parse arguments (which it does, but isn't very flexible about) but to automatically generate a usage message so that I don't have to.

##Simple Usage
    
    var options = DefaultParser.ParseOrExitWithUsageMessage<MyCommandLineParameters>(args);

##Recommendations
I'd recommend using an IConfiguration or similar interface so that anything that depends on it doesn't need to know about command-line parameters.

Our main program would look like this:

    public class Program
    {
        private static void Main(string[] args)
        {
            var configuration = DefaultParser.ParseOrExitWithUsageMessage<CommandLineParameters>(args);

            new Greeter(configuration).SayHello();
        }
    }

... and our Greeter like this:

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

Note that our Greeter takes a dependency on an IConfiguration, which looks like this:

    public interface IConfiguration
    {
        string FirstName { get; set; }
        string Surname { get; set; }
    }

... and that IConfiguration interface is implemented by our CommandLineParameters class:

    public class CommandLineParameters : IConfiguration
    {
        [ParameterDescription("The first name of the person using the program.")]
        public string FirstName { get; set; }

        [ParameterIsOptional]
        [ParameterDefault("Smith")]
        [ParameterDescription("The last name of the person using the program.")]
        public string Surname { get; set; }
    }

The key point here is that our Greeter knows absolutely nothing about command-line parameters as everything is segregated using the IConfiguration interface.

##License

This project is licensed using the MIT license.

The MIT License (MIT)
Copyright (c) 2016 Andrew Harcourt

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
