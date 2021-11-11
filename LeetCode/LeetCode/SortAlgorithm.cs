using System;
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

            if (nums.Length == 1) return 0;
            int max1 = -1, max2 = -1, index = -1, i = 0;
            foreach (int num in nums)
            {
                if (num > max1)
                {
                    max2 = max1;
                    max1 = num;
                    index = i;
                }
                else if (num > max2)
                {
                    max2 = num;
                }
                i++;
            }
            if (2 * max2 <= max1) return index;
            return -1;
        }

        #endregion





    }
}
