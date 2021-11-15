using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.公司笔试
{
    /// <summary>
    /// https://leetcode-cn.com/study-plan/meituan/?progress=pjnm0kr
    /// </summary>
    public class 美团校园招聘
    {

        private static int[] CreateArray(params int[] ts)
        {
            return ts;
        }

        #region meituan-001. 小美的用户名 2021-11-15 15:29:50

        public static bool 小美的用户名(string userName)
        {
            if (char.IsLetter(userName[0]) == false) return false;

            bool accept = false;
            foreach (var item in userName)
            {
                if (char.IsLetterOrDigit(item) == false) return false;

                if (char.IsDigit(item)) accept = true;
            }
            return accept;
        }


        #endregion

        #region meituan-002. 小美的仓库整理 2021-11-15 15:23:01

        public void 小美的仓库整理_Test()
        {
            var result = 公司笔试.美团校园招聘.小美的仓库整理(
                CreateArray(3, 2, 4, 4, 5),
                CreateArray(4, 3, 5, 2, 1));

            //[9,5,5,3,0]
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/TJZLyC/
        /// </summary>
        /// <param name="weights"></param>
        /// <param name="selectIndexs"></param>
        /// <returns></returns>
        public static List<int> 小美的仓库整理(int[] weights, int[] selectIndexs)
        {
            List<List<int>> goods = new List<List<int>>();

            goods.Add(Enumerable.Range(1, weights.Length).ToList());

            List<int> MaxWeights = new List<int>();

            for (int i = 0; i < selectIndexs.Length; i++)
            {
                int selectIndex = selectIndexs[i];

                int index1 = 0;
                int index2 = goods.FindIndex(good =>
                {
                    index1 = good.FindIndex(goodIndex => goodIndex == selectIndex);
                    return index1 > -1;
                });

                int count = goods[index2].Count - index1;
                List<int> newGood = goods[index2].GetRange(index1 + 1, count - 1);
                if (index2 + 1 < goods.Count)
                {
                    goods.Insert(index2 + 1, newGood);
                }
                else
                {
                    goods.Add(newGood);
                }
                goods[index2].RemoveRange(index1, count);

                MaxWeights.Add(goods.Max(good => good.Sum(item => weights[item - 1])));
            }

            return MaxWeights;
        }

        #endregion

        #region [疑问]限制条件不明确， meituan-003. 小美的跑腿代购

        /// <summary>
        /// https://leetcode-cn.com/problems/GXV5dX/
        /// </summary>
        /// <param name="input"></param>
        public static void 小美的跑腿代购(int[][] input)
        {

        }
        #endregion

        #region meituan-004. 小团的复制粘贴 2021-11-15 15:44:51


        public static void 小团的复制粘贴(int[] A, int[] B, int k, int x, int y)
        {
            for (int i = 0; i < k; i++)
            {
                if (y + i < B.Length && x + i < A.Length)
                {
                    B[y + i] = A[x + i];
                }
                else
                {
                    break;
                }
            }
        }


        #endregion

        #region meituan-005. 小美的区域会议 
        //https://leetcode-cn.com/problems/Uo7Dr5/
        #endregion
    }
}
