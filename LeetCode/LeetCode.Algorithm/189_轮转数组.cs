using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class _189_轮转数组
    {
        public static void Rotate(int k, params int[] nums)
        {
            k %= nums.Length;   //这句是为了预防 k > nums.Length 的情况
            Array.Reverse(nums);
            Array.Reverse(nums, 0, k);
            Array.Reverse(nums, k, nums.Length - k);
        }
    }
}
