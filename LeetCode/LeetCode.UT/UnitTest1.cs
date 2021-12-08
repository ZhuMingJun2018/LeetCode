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
            int d = 0;
            int k = (int)(1 / d);
            LeetCode.排序 t = new 排序();

            t.Convert("ABC", 1);
        }
    }
}