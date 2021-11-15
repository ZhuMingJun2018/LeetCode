using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class 滑动窗口
    {
        #region 3. 无重复字符的最长子串 2021-11-15 11:15:40
        public static int _3_LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            int max = 0;
            int index = 0;
            int i = 0;

            for (i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    max = Math.Max(max, i - index);

                    for (int j = index; j < dic[s[i]]; j++)
                    {
                        dic.Remove(s[j]);
                    }

                    index = dic[s[i]] + 1;
                }

                dic[s[i]] = i;
            }
            return Math.Max(max, i - index);
        }

        #endregion

        #region 567. 字符串的排列 2021-11-15 13:11:37
        private static bool _567_IsSameArry(int[] array1, int[] array2)
        {
            int len1 = array1.Length;
            int len2 = array2.Length;

            if (len1 != len2) return false;

            for (int i = 0; i < len1; i++)
            {
                if (array1[i] != array2[i]) return false;
            }
            return true;
        }
        public static bool _567_CheckInclusion(string s1, string s2)
        {
            int len1 = s1.Length;
            int len2 = s2.Length;

            if (len1 > s2.Length) return false;

            int[] char1 = new int[26];
            int[] char2 = new int[26];

            for (int i = 0; i < len1; i++)
            {
                ++char1[s1[i] - 'a'];
            }

            for (int i = 0; i < len2 - len1 + 1; i++)
            {
                for (int j = 0; j < len1; j++)
                {
                    char2[s2[i + j] - 'a']++;
                }
                if (_567_IsSameArry(char1,char2))
                {
                    return true;
                }
                else
                {
                    char2 = new int[26];
                }
            }

            return false;
        }
        #endregion
    }
}
