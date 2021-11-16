using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.程序员面试金典
{
    /// <summary>
    /// https://leetcode-cn.com/problem-list/xb9lfcwi/
    /// </summary>
    public class Class1
    {


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        #region 栈

        #region 02.06. 回文链表 2021-11-15 15:58:11
        public static bool IsPalindrome(ListNode head)
        {
            List<int> values = new List<int>();
            while (head != null)
            {
                values.Add(head.val);
                head = head.next;
            }

            for (int i = 0; i < values.Count / 2; i++)
            {
                if (values[i] != values[values.Count - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region 03.02. 栈的最小值

        public class MinStack
        {
            private readonly List<int> stack;

            /** initialize your data structure here. */
            public MinStack()
            {
                stack = new List<int>();
            }

            public void Push(int x)
            {
                stack.Add(x);
            }

            public void Pop()
            {
                stack.RemoveAt(0);
            }

            public int Top()
            {
                int value = stack[0];
                stack.RemoveAt(0);
                return value;
            }

            public int GetMin()
            {
                return stack.Min();
            }
        }
        #endregion

        #region 03.04. 化栈为队

        /// <summary>
        /// https://leetcode-cn.com/problems/implement-queue-using-stacks-lcci/
        /// </summary>
        public class MyQueue
        {
            private readonly Queue<int> queue1;
            private readonly Queue<int> queue2;
            /** Initialize your data structure here. */
            public MyQueue()
            {

            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {

            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                return 1;
            }

            /** Get the front element. */
            public int Peek()
            {
                return 1;
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return true;
            }
        }

        #endregion

        #endregion

        #region 排序

        #region 01.01. 判定字符是否唯一 2021-11-15 16:35:40
        public bool IsUnique(string astr)
        {
            HashSet<char> dic = new HashSet<char>();
            foreach (char c in astr)
            {
                if (dic.Contains(c))
                {
                    return false;
                }
                else
                {
                    dic.Add(c);
                }
            }
            return true;
        }
        #endregion

        #region 01.02. 判定是否互为字符重排 2021-11-15 16:38:04
        public bool CheckPermutation(string s1, string s2)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in s1)
            {
                dic[c] = dic.ContainsKey(c) ? dic[c] + 1 : 1;
            }

            foreach (char c in s2)
            {
                if (dic.ContainsKey(c) && dic[c] > 0)
                {
                    dic[c]--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 08.13. 堆箱子 

        /// <summary>
        /// https://leetcode-cn.com/problems/pile-box-lcci/
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public int PileBox(int[][] box)
        {
            return 0;
        }
        #endregion

        #region 16.06. 最小差 2021-11-15 16:54:41
        public int SmallestDifference(int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);
            long min = Math.Abs((long)a[0] - b[0]);
            for (int i = 0, j = 0; i < a.Length && j < b.Length;)
            {
                long tempMin = Math.Abs((long)a[i] - b[j]);

                if (tempMin < min) min = tempMin;

                if (a[i] > b[j])
                {
                    j++;
                }
                else
                {
                    i++;
                }
            }
            return (int)min;
        }
        #endregion

        #region 16.16. 部分排序 2021-11-15 17:03:56
        public int[] SubSort(int[] array)
        {
            int[] clone = (int[])array.Clone();
            Array.Sort(clone);
            int m = -1;
            int n = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != clone[i])
                {
                    m = i;
                    break;
                }
            }

            for (int i = array.Length - 1; m < i; i--)
            {
                if (array[i] != clone[i])
                {
                    n = i;
                    break;
                }
            }
            return new int[2] { m, n };
        }
        #endregion

        #region 10.01. 合并排序的数组 2021-11-15 17:05:55
        public void Merge(int[] A, int m, int[] B, int n)
        {
            for (int i = 0; i < n; i++)
            {
                A[i + m] = B[i];
            }

            Array.Sort(A);
        }
        #endregion

        #region [疑问] 特殊情况不能覆盖 [4,8,8,2] 10.11. 峰与谷
        public void WiggleSort(int[] nums)
        {
            if (nums.Length < 3) return;

            //next except
            for (int i = 1; i < nums.Length - 1; i++)
            {
                if ((nums[i - 1] - nums[i] > 0) != (nums[i + 1] - nums[i] > 0))
                {
                    int temp = nums[i];
                    nums[i] = nums[i + 1];
                    nums[i + 1] = temp;
                }
            }
        }
        #endregion

        #region 面试题 17.04. 消失的数字

        #endregion

        #region 17.14. 最小K个数 2021-11-15 17:27:25
        public int[] SmallestK(int[] arr, int k)
        {
            if (arr.Length < k) return null;

            Array.Sort(arr);
            int[] ans = new int[k];
            Array.Copy(arr, ans, k);
            return ans;
        }
        #endregion

        #region 17.20. 连续中值 

        /// <summary>
        /// https://leetcode-cn.com/problems/continuous-median-lcci/
        /// </summary>
        public static void Demo_连续中值()
        {
            MedianFinder finder = new MedianFinder();
            finder.AddNum(1);
            finder.AddNum(2);
            var ans = finder.FindMedian();
            finder.AddNum(3);
            ans = finder.FindMedian();
        }
        public class MedianFinder
        {
            private readonly List<double> _Values;
            private int Count { get; set; }

            /** initialize your data structure here. */
            public MedianFinder()
            {
                _Values = new List<double>();
            }

            public void AddNum(int num)
            {
                if (Count == 0)
                {
                    _Values.Add(num);
                }
                else
                {
                    int index = FindInsertIndex(num);
                    _Values.Insert(index, num);
                }

                Count++;
            }

            private int FindInsertIndex(int num)
            {
                if (num < _Values[0]) return 0;
                if (num > _Values[Count - 1]) return Count;
                if (Count == 1) return num < _Values[0] ? 0 : 1;

                int left = 0;
                int right = Count - 1;

                while (left < right)
                {
                    int mid = (left + right) / 2;

                    if (num == _Values[mid])
                    {
                        return mid;
                    }
                    else if (num < _Values[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                return left;
            }

            public double FindMedian()
            {
                if (Count == 0) return 0;
                bool IsOdd = Count % 2 == 1;
                return IsOdd ? _Values[Count / 2] : (_Values[Count / 2 - 1] + _Values[Count / 2]) / 2;
            }
        }
        #endregion
        #endregion
    }
}
