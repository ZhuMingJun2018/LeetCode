using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class _977_有序数组的平方
    {
        /// <summary>
        /// 
        /// https://leetcode-cn.com/problems/squares-of-a-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] SortedSquares(params int[] nums)
        {
            var result = nums.Select(num => num * num).ToList();
            result.Sort();

            return result.ToArray();
        }
    }
}
