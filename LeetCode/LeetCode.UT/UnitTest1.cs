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
            Algorithm._746_MinCostClimbingStairs(1, 2, 10, 11, 100, 1, 100, 1);
        }
    }
}