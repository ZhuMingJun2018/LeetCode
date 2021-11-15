using NUnit.Framework;

namespace LeetCode.UT
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static int[] CreateArray(params int[] ts)
        {
            return ts;
        }

        [Test]
        public void Test1()
        {
            程序员面试金典.Class1.Demo_连续中值();
        }
    }
}