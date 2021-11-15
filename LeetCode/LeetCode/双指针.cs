using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class 双指针
    {
        #region Common
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }

            public override string ToString()
            {
                string result = $"{val}";
                ListNode temp = next;
                while (temp != null)
                {
                    result += $",{next.val}";
                    temp = temp.next;
                }

                return result;
            }
        }

        public static ListNode CreateListNode(int count)
        {
            ListNode node = new ListNode() { val = 1 };
            ListNode first = node;

            for (int i = 1; i < count; i++)
            {
                node.next = new ListNode() { val = i + 1 };
                node = node.next;
            }
            return first;
        }

        #endregion

        #region 19. 删除链表的倒数第 N 个结点 2021-11-15 11:15:47
        public static ListNode _19_RemoveNthFromEnd(ListNode head, int n)
        {
            List<ListNode> list = new List<ListNode>();

            ListNode temp = head;
            while (temp != null)
            {
                list.Add(temp);
                temp = temp.next;
            }

            int count = list.Count;

            if (count == 1) return null;
            if (count == n) return list[1];

            list[count - n - 1].next = n == 1 ? null : list[count - n + 1];
            return head;
        }

        #endregion

        #region 876. 链表的中间结点 2021-11-15 11:15:50

        public static ListNode _876_MiddleNode(ListNode head)
        {
            List<ListNode> list = new List<ListNode>();

            ListNode temp = head;
            while (temp != null)
            {
                list.Add(temp);
                temp = temp.next;
            }

            int mid = list.Count / 2;
            return list[mid];
        }

        #endregion
    }
}