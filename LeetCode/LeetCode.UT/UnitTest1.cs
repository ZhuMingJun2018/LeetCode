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
            LeetCode.前缀和 t = new 前缀和();

            t.MinSubArrayLen(7, 2, 3, 1, 2, 4, 3);
        }
    }
}