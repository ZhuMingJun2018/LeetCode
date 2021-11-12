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

        #region 506 斐波那契数 2021-11-10 20:58:25

        public static int _506_Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return _506_Fib(n - 1) + _506_Fib(n - 2);
        }
        public static int _506_Fib1(int n)
        {
            double goldenRatio = (1 + Math.Sqrt(5)) / 2;
            return (int)Math.Round(Math.Pow(goldenRatio, n) / Math.Sqrt(5));
        }
        public static int _506_Fib2(int n)
        {
            if (n < 2)
                return n;
            int[] resArray = new int[n + 1];
            resArray[0] = 0;
            resArray[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                resArray[i] = resArray[i - 1] + resArray[i - 2];
            }
            return resArray[n];
        }
        public static int _506_Fib3(int n)
        {
            int a = 0, b = 1;

            if (n < 2) return n;

            int temp = 0;
            for (int i = 2; i <= n; i++)
            {
                temp = b;
                b = b + a;
                a = temp;
            }

            return b;
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

        #region 1137 第N个泰波那契数 2021-11-10 20:55:48
        public static int _1137_Tribonacci(int n)
        {
            if (n == 0) return 0;
            if (n < 3) return 1;

            int[] nums = new int[n + 1];
            nums[0] = 0;
            nums[1] = 1;
            nums[2] = 1;
            for (int i = 3; i < n + 1; i++)
            {
                nums[i] = nums[i - 3] + nums[i - 2] + nums[i - 1];
            }
            return nums[n];
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
                if (heights[i]!=heightNew[i])
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