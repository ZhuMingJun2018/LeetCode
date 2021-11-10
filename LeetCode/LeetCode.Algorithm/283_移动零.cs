using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class _283_移动零
    {
        public static void MoveZeroes(params int[] nums)
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
    }
}
