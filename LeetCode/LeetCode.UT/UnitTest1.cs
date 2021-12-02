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
<<<<<<< HEAD
            LeetCode.前缀和 t = new 前缀和();

            t.MinSubArrayLen(7, 2, 3, 1, 2, 4, 3);
=======
            排序 t = new 排序();
            t.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3,4 });
>>>>>>> c9a97638ebce4eb784e1191528cb30748055756e
        }
    }
}