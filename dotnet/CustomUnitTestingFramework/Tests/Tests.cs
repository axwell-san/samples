using MyUnit;
using System;

namespace Tests
{
    public class Tests
    {
        [MyTest]
        public void PositiveTest()
        {
            Console.WriteLine("PositiveTest started.");
            Console.WriteLine("Assert true is true.");
            MyAssert.IsTrue(true);
        }

        [MyTest]
        public void NegativeTest()
        {
            Console.WriteLine("NegativeTest started.");
            Console.WriteLine("Assert true is false.");
            MyAssert.IsTrue(false);
        }
    }
}
