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
            排序 t = new 排序();
            t.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3,4 });
        }
    }
}