using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class _035_搜索插入位置
    {
        #region 35 搜索插入位置

        /// <summary>
        /// [代解决]
        /// https://leetcode-cn.com/problems/search-insert-position/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int 搜索插入位置(int target, params int[] nums)
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
    }
}
