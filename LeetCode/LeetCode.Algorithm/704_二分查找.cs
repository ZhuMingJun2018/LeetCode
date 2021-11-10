using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class _704_二分查找
    {
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
        public static int 二分查找(int[] nums, int target)
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
    }
}
