using System;

namespace MyUnit
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MyTestAttribute : Attribute
    {
    }
}
