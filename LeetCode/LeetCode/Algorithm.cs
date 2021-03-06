using System;

namespace LeetCode
{
    public class Algorithm
    {

        #region [待解决] 35 搜索插入位置 

        /// <summary>
        /// 
        /// https://leetcode-cn.com/problems/search-insert-position/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int _35_搜索插入位置(int target, params int[] nums)
        {
            int startIndex = 0;
            int endIndex = nums.Length - 1;
            int midIndex = 0;

            if (nums[startIndex] == target) return startIndex;
            if (nums[endIndex] == target) return endIndex;
            if (nums[startIndex] > target) return 0;
            if (nums[endIndex] < target) return endIndex + 1;

            while (startIndex < endIndex - 1)
            {
                //find middle index
                midIndex = startIndex + (endIndex - startIndex) / 2;

                if (nums[midIndex] == target) return midIndex;

                if (target < nums[midIndex])
                    endIndex = midIndex;
                else
                    startIndex = midIndex;
            }

            return startIndex + 1;
        }
        #endregion

        #region 70 爬楼梯 2021-11-10 20:44:22

        /// <summary>
        /// 
        /// https://leetcode-cn.com/problems/climbing-stairs/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int _70_ClimbStaris(int n)
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

        #region 167. 两数之和 II - 输入有序数组 2021-11-11 13:01:41

        public static int[] _167_TwoSum(int target, params int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int low = i + 1, high = numbers.Length - 1;
                int tempTarget = target - numbers[i];
                if (tempTarget == numbers[low])
                {
                    return new int[] { i + 1, low + 1 };
                }
                else if (tempTarget == numbers[high])
                {
                    return new int[] { i + 1, high + 1 };
                }

                while (low < high - 1)
                {
                    int mid = low + (high - low) / 2;

                    if (tempTarget == numbers[mid])
                    {
                        return new int[] { i + 1, mid + 1 };
                    }
                    else if (tempTarget < numbers[mid])
                    {
                        high = mid;
                    }
                    else
                    {
                        low = mid;
                    }
                }
            }

            return new int[] { 0, 0 };
        }



        #endregion

        #region 189 轮转数组 2021-11-10 20:56:23

        public static void _189_Rotate(int k, params int[] nums)
        {
            k %= nums.Length;   //这句是为了预防 k > nums.Length 的情况
            Array.Reverse(nums);
            Array.Reverse(nums, 0, k);
            Array.Reverse(nums, k, nums.Length - k);
        }

        #endregion

        #region 278 第一个错误的版本 2021-11-10 20:57:12

        /// <summary>
        /// [待理解]
        /// https://leetcode-cn.com/problems/first-bad-version/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int _278_第一个错误的版本(int n)
        {
            int badVersion = new Random().Next(n);
            Func<int, bool> IsBadVersion = (version) => version > badVersion || version == badVersion;

            int left = 1, right = n;
            int count = 0;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                count++;
                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            Console.WriteLine($"[{nameof(_278_第一个错误的版本)}]:AlgorithmCount[{count}],VersionSize[{n}],BadVersion[{badVersion}]");

            return left;
        }



        #endregion

        #region 283 移动零 2021-11-10 20:58:05
        public static void _283_MoveZeroes(params int[] nums)
        {
            int length = nums.Length;

            var list = nums.ToList();

            int count = list.RemoveAll(num => num == 0);

            list.AddRange(new int[count]);

            for (int i = 0; i < length; i++)
            {
                nums[i] = list[i];
            }
        }

        #endregion

        #region 704 二分查找 2021-11-09 23:25:55
        /// <summary>
        /// 二分查找
        /// 给定一个 n 个元素有序的（升序）整型数组 nums 和一个目标值 target  ，
        /// 写一个函数搜索 nums 中的 target，如果目标值存在返回下标，否则返回 -1。
        /// 
        /// 时间复杂度：O(\log n)O(logn)，其中 nn 是数组的长度。
        /// 空间复杂度：O(1)O(1)。
        /// 
        /// https://leetcode-cn.com/problems/binary-search/
        /// </summary>
        /// <param name="nums">升序整型数组</param>
        /// <param name="target">目标值</param>
        /// <returns>存在则返回目标值序号，否则返回-1</returns>
        public static int _704_二分查找(int[] nums, int target)
        {
            int startIndex = 0;
            int endIndex = nums.Length - 1;
            int midIndex = 0;

            if (nums[startIndex] == target) return startIndex;
            if (nums[endIndex] == target) return endIndex;

            if (nums[startIndex] > target
                || nums[endIndex] < target) return -1;

            while (startIndex < endIndex)
            {
                //find middle index
                midIndex = startIndex + (endIndex - startIndex) / 2;

                if (nums[midIndex] == target) return midIndex;

                if (nums[midIndex] > target)
                    endIndex = midIndex - 1;
                else
                    startIndex = midIndex + 1;
            }

            return -1;
        }


        #endregion

        #region [待解决] 746 使用最小花费爬楼梯 

        /// <summary>
        /// 
        /// https://leetcode-cn.com/problems/min-cost-climbing-stairs/
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public static int _746_MinCostClimbingStairs(params int[] cost)
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


    }
}