using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MyUnit
{
    internal static class MyUnit
    {
        public static void Run(Assembly testAssembly)
        {
            MyReport report = new MyReport(testAssembly);

            Type[] types = testAssembly.GetTypes();

            foreach (var type in types)
            {
                MethodInfo[] methods = type.GetMethods();

                foreach (var method in methods)
                {
                    if (method.GetCustomAttributes().Any(_ => _ is MyTestAttribute))
                    {

                        object testClass = testAssembly.CreateInstance(type.FullName);

                        try
                        {
                            method.Invoke(testClass, Type.EmptyTypes);
                        }
                        catch (Exception e)
                        {
                            report.Append(method, e);
                            continue;
                        }

                        report.Append(method);
                    }
                }
            }

            string reportPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "MyUnitTestReport.html");
            File.WriteAllText(reportPath, report.ToString());
        }
    }
}
