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
            LeetCode.���� t = new ����();

            t.KthSmallestPrimeFraction(new int[] { 1, 2, 3, 5 }, 3);
        }
    }
}