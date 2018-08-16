using System;
using System.Reflection;

namespace MyUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MyUnit test runner...");

            if (args.Length == 0)
            {
                PrintHelp();
                return;
            }
            else
            {
                string assemblyFile = args[0];
                AssemblyName testAssemblyName = AssemblyName.GetAssemblyName(assemblyFile);
                Assembly testAssembly = AppDomain.CurrentDomain.Load(testAssemblyName);
                MyUnit.Run(testAssembly);
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Specify absolute path to assembly file(eg. 'myunit c:\\tests\\tests.dll')\nTest method should be marked with MyUnit.MyTest attribute\nPress any key...");
            Console.ReadKey();
        }
    }
}
