using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class 动态规划
    {
        #region 53. 最大子序和
        //public int MaxSubArray(int[] nums)
        //{

        //}
        #endregion

        #region 70. 爬楼梯 2021-11-12 17:57:55

        /// <summary>
        /// 
        /// https://leetcode-cn.com/problems/climbing-stairs/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int _70_ClimbStairs(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;

            int[] results = new int[n + 1];
            results[0] = 0;
            results[1] = 1;
            results[2] = 2;

            for (int i = 3; i < n + 1; i++)
            {
                results[i] = results[i - 1] + results[i - 2];
            }
            return results[n];
        }

        #endregion

        #region 198. 打家劫舍

        /// <summary>
        /// https://leetcode-cn.com/problems/house-robber/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int _198_Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

            int[] dp = new int[nums.Length];

            dp[0] = nums[0];
            dp[1] = Math.Max(nums[1], nums[0]);

            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }

            return dp[nums.Length - 1];

            /* 2,7,9,3,1
             * 2,9,11=max(11,9),
             */
        }
        #endregion

        #region 213. 打家劫舍 II 
        public static int _213_Rob(int[] nums)
        {
            int length = nums.Length;
            if (length == 1)
            {
                return nums[0];
            }
            else if (length == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }
            return Math.Max(robRange(nums, 0, length - 2), robRange(nums, 1, length - 1));
        }

        private static int robRange(int[] nums, int start, int end)
        {
            int first = nums[start], second = Math.Max(nums[start], nums[start + 1]);
            for (int i = start + 2; i <= end; i++)
            {
                int temp = second;
                second = Math.Max(first + nums[i], second);
                first = temp;
            }
            return second;
        }
        #endregion

        #region 506 斐波那契数 2021-11-10 20:58:25

        public static int _506_Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return _506_Fib(n - 1) + _506_Fib(n - 2);
        }
        public static int _506_Fib1(int n)
        {
            double goldenRatio = (1 + Math.Sqrt(5)) / 2;
            return (int)Math.Round(Math.Pow(goldenRatio, n) / Math.Sqrt(5));
        }
        public static int _506_Fib2(int n)
        {
            if (n < 2)
                return n;
            int[] resArray = new int[n + 1];
            resArray[0] = 0;
            resArray[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                resArray[i] = resArray[i - 1] + resArray[i - 2];
            }
            return resArray[n];
        }
        public static int _506_Fib3(int n)
        {
            int a = 0, b = 1;

            if (n < 2) return n;

            int temp = 0;
            for (int i = 2; i <= n; i++)
            {
                temp = b;
                b = b + a;
                a = temp;
            }

            return b;
        }
        #endregion

        #region 740. 删除并获得点数

        /// <summary>
        /// 
        /// https://leetcode-cn.com/problems/delete-and-earn/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int _740_DeleteAndEarn(int[] nums)
        {
            int maxVal = nums.Max();

            int[] sum = new int[maxVal + 1];
            foreach (int val in nums)
            {
                sum[val] += val;
            }
            return _740_Rob(sum);
        }

        public static int _740_Rob(int[] nums)
        {
            int size = nums.Length;
            int first = nums[0], second = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < size; i++)
            {
                int temp = second;
                second = Math.Max(first + nums[i], second);
                first = temp;
            }
            return second;
        }
        #endregion

        #region 746. 使用最小花费爬楼梯

        /// <summary>
        /// [待理解] 为什么这样 就是最小花费。
        /// https://leetcode-cn.com/problems/min-cost-climbing-stairs/
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public static int _746_MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            int[] dp = new int[n + 1];
            dp[0] = dp[1] = 0;
            for (int i = 2; i <= n; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
            }
            return dp[n];
        }
        #endregion

        #region 1137 第N个泰波那契数 2021-11-10 20:55:48
        public static int _1137_Tribonacci(int n)
        {
            if (n == 0) return 0;
            if (n < 3) return 1;

            int[] nums = new int[n + 1];
            nums[0] = 0;
            nums[1] = 1;
            nums[2] = 1;
            for (int i = 3; i < n + 1; i++)
            {
                nums[i] = nums[i - 3] + nums[i - 2] + nums[i - 1];
            }
            return nums[n];
        }

        #endregion
    }
}
