﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SortAlgorithm
    {
        #region 88. 合并两个有序数组 2021-11-11 13:29:33
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums1.Length != m + n) return;

            for (int i = 0; i < n; i++)
            {
                nums1[i + m] = nums2[i];
            }

            Array.Sort(nums1);
        }

        #endregion

        #region 169. 多数元素 2021-11-11 13:31:01
        public static int MajorityElement(int[] nums)
        {
            int count = 1;
            int num = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == num)
                {
                    count++;
                }
                else if (--count < 0)
                {
                    num = nums[i];
                    count = 0;
                }
            }

            return num;
        }

        #endregion

        #region 217. 存在重复元素 2021-11-11 13:41:59

        public static bool ContainsDuplicate(int[] nums)
        {
            Array.Sort<int>(nums);

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1]) return true;
            }

            HashSet<int> hasNums = new HashSet<int>(nums);

            return hasNums.Count < nums.Length;
        }

        #endregion

        #region 242. 有效的字母异位词 2021-11-11 13:42:07
        public static bool _242_IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            char[] arryS = s.ToCharArray();
            char[] arryT = t.ToCharArray();

            Array.Sort(arryS);
            Array.Sort(arryT);

            return arryS.SequenceEqual(arryT);
        }

        #endregion

        #region 268. 丢失的数字 2021-11-11 14:02:49

        public static int _268_MissingNumber(int[] nums)
        {
            int n = nums.Length;

            Array.Sort(nums);

            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i) return i;
            }

            return n;
        }

        #endregion

        #region 349. 两个数组的交集 2021-11-11 14:06:32

        public int[] _349_Intersection(int[] nums1, int[] nums2)
        {
            return nums1.Intersect(nums2).ToArray();

            Array.Sort(nums1);
            Array.Sort(nums2);

            List<int> result = new List<int>();
            int index = 0, index1 = 0, index2 = 0;
            while (index1 < nums1.Length && index2 < nums2.Length)
            {
                if (nums1[index1] == nums2[index2])
                {
                    if (index == 0 || result[index - 1] != nums1[index])
                    {
                        index++;
                        result.Add(nums1[index1]);
                    }
                }
                else if (nums1[index1] > nums2[index2])
                {
                    index2++;
                }
                else
                {
                    index1++;
                }
            }

            return result.ToArray();


            HashSet<int> hs = nums1.ToHashSet();
            HashSet<int> hs2 = nums2.ToHashSet();
            return hs.Where(num => hs2.Contains(num)).ToArray();
        }

        #endregion

        #region 350. 两个数组的交集 II 2021-11-11 14:28:46
        public static int[] _350_Intersect(int[] nums1, int[] nums2)
        {

            Array.Sort(nums1);
            Array.Sort(nums2);

            List<int> result = new List<int>();
            int index1 = 0, index2 = 0;

            while (index1 < nums1.Length && index2 < nums2.Length)
            {
                int num1 = nums1[index1], num2 = nums2[index2];

                if (num1 == num2)
                {
                    result.Add(num1);
                    index1++;
                    index2++;
                }
                else if (num1 > num2)
                {
                    index2++;
                }
                else
                {
                    index1++;
                }
            }

            return result.ToArray();
        }



        #endregion

        #region 389. 找不同 2021-11-11 14:38:50

        public static char _389_FindTheDifference(string s, string t)
        {
            var listS = s.ToArray();
            var listT = t.ToArray();

            Array.Sort(listS);
            Array.Sort(listT);

            int i = 0;
            for (i = 0; i < listS.Length; i++)
            {
                if (listS[i] != listT[i])
                {
                    return listT[i];
                }
            }

            return listT[i];
        }

        #endregion

        #region 414. 第三大的数 2021-11-11 14:43:06

        public static int _414_ThirdMax(int[] nums)
        {
            if (nums.Length < 3) return nums.Max();

            nums = nums.Distinct().ToArray();

            Array.Sort(nums);

            return nums.Length < 3 ? nums.Max() : nums[nums.Length - 3];
        }

        #endregion

        #region 455. 分发饼干 2021-11-11 14:49:39
        public int _455_FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);
            int i = 0, j = 0, count = 0;
            while (i < g.Length && j < s.Length)
            {
                if (s[j] >= g[i])
                {
                    count++;
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }

            return count;
        }
        #endregion

        #region 506. 相对名次 2021-11-11 14:54:31

        public static string[] _506_FindRelativeRanks(int[] score)
        {
            int len = score.Length;

            string[] ranks = new string[len];

            int[] x = (int[])score.Clone();

            Array.Sort(score);

            score = score.Reverse().ToArray();

            Dictionary<int, string> dic = new Dictionary<int, string>();

            if (len > 0) dic[score[0]] = "Gold Medal";
            if (len > 1) dic[score[1]] = "Silver Medal";
            if (len > 2) dic[score[2]] = "Bronze Medal";


            if (len > 3)
            {
                for (int i = 3; i < len; i++)
                {
                    dic[score[i]] = i + 1 + "";
                }
            }

            for (int i = 0; i < len; i++)
            {
                ranks[i] = dic[x[i]];
            }
            return ranks;
        }

        #endregion

        #region 561. 数组拆分 I 2021-11-11 15:19:05
        public static int _561_ArrayPairSum(int[] nums)
        {
            if (nums.Length % 2 != 0) return -1;

            Array.Sort(nums);

            int sum = 0;

            for (int i = 0; i < nums.Length; i += 2)
            {
                sum += nums[i];
            }

            return sum;
        }
        #endregion

        #region 594. 最长和谐子序列 2021-11-11 15:22:52
        public static int FindLHS(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                dic[num] = dic.ContainsKey(num) ? dic[num] + 1 : 1;
            }

            int res = 0;
            foreach (var key in dic.Keys)
            {
                if (dic.ContainsKey(key + 1))
                {
                    res = Math.Max(res, dic[key] + dic[key + 1]);
                }
            }

            return res;
        }
        #endregion

        #region 628. 三个数的最大乘积 2021-11-11 15:39:54

        public static int _628_MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            int len = nums.Length;

            return Math.Max(nums[0] * nums[1] * nums[len - 1], nums[len - 1] * nums[len - 2] * nums[len - 3]);
        }

        #endregion

        #region 645. 错误的集合 2021-11-11 15:55:14
        public static int[] _645_FindErrorNums(int[] nums)
        {
            int[] errorNums = new int[2];
            int n = nums.Length;
            Array.Sort(nums);
            int prev = 0;
            for (int i = 0; i < n; i++)
            {
                int curr = nums[i];
                if (curr == prev)
                {
                    errorNums[0] = prev;
                }
                else if (curr - prev > 1)
                {
                    errorNums[1] = prev + 1;
                }
                prev = curr;
            }
            if (nums[n - 1] != n)
            {
                errorNums[1] = n;
            }
            return errorNums;
        }
        #endregion

        #region 720. 词典中最长的单词



        #endregion

        #region 747. 至少是其他数字两倍的最大数 2021-11-11 16:23:52
        public static int _747_DominantIndex(int[] nums)
        {
            int len = nums.Length;
            if (len < 2) return 0;

            int[] x = (int[])nums.Clone();

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                dic[nums[i]] = i;
            }

            Array.Sort(nums);

            if (nums[len - 1] >= 2 * nums[len - 2])
            {
                return dic[nums[len - 1]];
            }

            return -1;

            //if (nums.Length == 1) return 0;
            //int max1 = -1, max2 = -1, index = -1, i = 0;
            //foreach (int num in nums)
            //{
            //    if (num > max1)
            //    {
            //        max2 = max1;
            //        max1 = num;
            //        index = i;
            //    }
            //    else if (num > max2)
            //    {
            //        max2 = num;
            //    }
            //    i++;
            //}
            //if (2 * max2 <= max1) return index;
            //return -1;
        }

        #endregion

        #region 888. 公平的糖果棒交换 2021-11-11 17:46:58
        public static int[] _888_FairCandySwap(int[] aliceSizes, int[] bobSizes)
        {
            int aSize = aliceSizes.Sum();
            int bSize = bobSizes.Sum();
            int temp = (bSize - aSize) / 2;

            int[] result = new int[2];

            foreach (var alice in aliceSizes)
            {
                foreach (var bob in bobSizes)
                {
                    if (bob == alice + temp)
                    {
                        result[0] = alice;
                        result[1] = bob;
                        break;
                    }
                }
            }
            return result;
        }
        #endregion

        #region 905. 按奇偶排序数组 2021-11-11 17:30:51
        public static int[] _905_SortArrayByParity(int[] nums)
        {
            int[] result = new int[nums.Length];

            int left = 0, right = nums.Length - 1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    result[left++] = nums[i];
                }
                else
                {
                    result[right--] = nums[i];
                }
            }

            return result;
        }

        #endregion

        #region 922. 按奇偶排序数组 II 2021-11-11 17:47:32
        public static int[] _922_SortArrayByParityII(int[] nums)
        {
            int even = 0;
            int odd = 1;

            int[] result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    result[even] = nums[i];
                    even += 2;
                }
                else
                {
                    result[odd] = nums[i];
                    odd += 2;
                }
            }

            return result;
        }

        #endregion

        #region 937. 重新排列日志文件 2021-11-11 17:51:32
        public static string[] _937_ReorderLogFiles(params string[] logs)
        {
            Array.Sort(logs, (log1, log2) =>
            {
                string[] str1 = log1.Split(" ", 2);
                string[] str2 = log2.Split(" ", 2);
                bool isDigit1 = char.IsDigit(str1[1][0]);
                bool isDigit2 = char.IsDigit(str2[1][0]);
                if (!isDigit1 && !isDigit2)
                {
                    int cmp = str1[1].CompareTo(str2[1]);
                    if (cmp != 0) return cmp;
                    return str1[0].CompareTo(str2[0]);
                }
                return isDigit1 ? (isDigit2 ? 0 : 1) : -1;
            });


            List<string> digitalList = new List<string>();
            List<string> stringList = new List<string>();

            foreach (var log in logs)
            {
                var infos = log.Split(" ", 2);

                if (char.IsDigit(infos[1][0]))
                {
                    digitalList.Add(log);
                }
                else
                {
                    stringList.Add(log);
                }
            }

            stringList.Sort((s1, s2) =>
            {
                string[] str1 = s1.Split(" ", 2);
                string[] str2 = s2.Split(" ", 2);

                var cmd = str1[1].CompareTo(str2[1]);
                if (cmd != 0) return cmd;
                return str1[0].CompareTo(str2[0]);
            });

            stringList.AddRange(digitalList);

            return stringList.ToArray();
        }
        #endregion

        #region 976. 三角形的最大周长 2021-11-12 09:52:05

        /// <summary>
        /// 
        /// https://leetcode-cn.com/problems/largest-perimeter-triangle/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int _976_LargestPerimeter(int[] nums)
        {
            for (int i = nums.Length - 1; i >= 2; --i)
            {
                //[如果此条件不满足，i-1 or i-2 再缩小，肯定不会满足 i < i-1 + i-2的条件，所以只能减少 i ]
                if (nums[i] < nums[i - 1] + nums[i - 2])
                    return nums[i] + nums[i - 1] + nums[i - 2];
            }
            return 0;
        }
        #endregion

        #region 977 有序数组的平方 2021-11-10 20:59:41

        /// <summary>
        /// 
        /// https://leetcode-cn.com/problems/squares-of-a-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] _977_SortedSquares(params int[] nums)
        {
            nums = nums.Select(num => num * num).ToArray();

            Array.Sort(nums);

            return nums;
        }
        #endregion

        #region 1005. K 次取反后最大化的数组和 2021-11-12 10:50:38
        public static int _1005_LargestSumAfterKNegations(int k, params int[] nums)
        {
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (k > 0 && nums[i] < 0)
                {
                    k--;
                    nums[i] = -nums[i];
                }
                else
                {
                    break;
                }
            }

            if (k > 0 && k % 2 == 1)
            {
                Array.Sort(nums);

                nums[0] = -nums[0];
            }

            return nums.Sum();
        }

        #endregion

        #region 1030. 距离顺序排列矩阵单元格
        /// <summary>
        /// 
        /// https://leetcode-cn.com/problems/matrix-cells-in-distance-order/
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="rCenter"></param>
        /// <param name="cCenter"></param>
        /// <returns></returns>
        public static int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
        {
            int[] dr = { 1, 1, -1, -1 };
            int[] dc = { 1, -1, -1, 1 };

            int maxDist = Math.Max(rCenter, rows - 1 - rCenter) + Math.Max(cCenter, cols - 1 - cCenter);
            int[][] ret = new int[rows * cols][];
            int row = rCenter, col = cCenter;
            int index = 0;
            ret[index++] = new int[] { row, col };
            for (int dist = 1; dist <= maxDist; dist++)
            {
                row--;
                for (int i = 0; i < 4; i++)
                {
                    while ((i % 2 == 0 && row != rCenter) || (i % 2 != 0 && col != cCenter))
                    {
                        if (row >= 0 && row < rows && col >= 0 && col < cols)
                        {
                            ret[index++] = new int[] { row, col };
                        }
                        row += dr[i];
                        col += dc[i];
                    }
                }
            }
            return ret;
        }
        #endregion

        #region 1051. 高度检查器 2021-11-12 12:22:58
        public static int _1051_HeightChecker(int[] heights)
        {
            int[] heightNew = (int[])heights.Clone();

            Array.Sort(heightNew);

            int count = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] != heightNew[i])
                {
                    count++;
                }
            }

            return count;
        }
        #endregion

        #region 1619. 删除某些元素后的数组均值 2021-11-12 12:29:42
        public static int[] _1619_RelativeSortArray(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (var item in arr1)
            {
                dic[item] = dic.ContainsKey(item) ? dic[item] + 1 : 1;
            }

            int index = 0;
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < dic[arr2[i]]; j++)
                {
                    arr1[index++] = arr2[i];
                }

                dic.Remove(arr2[i]);
            }

            var keys = dic.Keys.ToList();
            keys.Sort();
            foreach (var item in keys)
            {
                for (int i = 0; i < dic[item]; i++)
                {
                    arr1[index++] = item;
                }
            }

            return arr1;
        }
        #endregion

        #region 1331. 数组序号转换 2021-11-12 12:40:15

        public static int[] _1331_ArrayRankTransform(int[] arr)
        {
            int[] arrNew = (int[])arr.Clone();

            Array.Sort(arrNew);

            int[] result = new int[arrNew.Length];


        }

        #endregion


    }
}