using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class 前缀和
    {
        #region 209. 长度最小的子数组
        public int MinSubArrayLen(int target, params int[] nums)
        {
            int ans = nums.Length + 1;

            for (int i = 0; i < nums.Length; i++)
            {
                int sum = nums[i];

                if (sum >= target) return 1;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    sum += nums[j];

                    if (sum >= target)
                    {
                        ans = Math.Min(ans, j - i + 1);
                        break;
                    }
                }
            }

            return ans > nums.Length ? 0 : ans;
        }
        #endregion
    }
}
