using NUnit.Framework;

namespace LeetCode.UT
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Algorithm._1005_LargestSumAfterKNegations(
                4,
                -4, -2,-3);
        }
    }
}