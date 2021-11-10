using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class _278_第一个错误的版本
    {
        #region 278 第一个错误的版本

        /// <summary>
        /// [待理解]
        /// https://leetcode-cn.com/problems/first-bad-version/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int 第一个错误的版本(int n)
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
    }
}
