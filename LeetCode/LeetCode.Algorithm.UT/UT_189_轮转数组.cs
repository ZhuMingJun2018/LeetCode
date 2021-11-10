using NUnit.Framework;

namespace LeetCode.Algorithm.UT
{
    public class UT_189_轮转数组
    {
        [Test]
        public void Test1()
        {
            _189_轮转数组.Rotate(2, -1, -100, 3, 99);
            _189_轮转数组.Rotate(2, 1, 2, 3, 4, 5, 6, 7);
        }
    }
}