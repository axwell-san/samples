using System;

namespace MyUnit
{
    public static class MyAssert
    {
        public static void IsTrue(bool actual)
        {
            if (!actual)
            {
                throw new Exception("MyAssert failed. Expected true, but is false.");
            }
        }
    }
}
