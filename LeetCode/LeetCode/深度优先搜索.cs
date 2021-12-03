using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class 深度优先搜索
    {
        #region MyRegion
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        #endregion

        #region E 94. 二叉树的中序遍历 2021-12-02 12:14:48
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> ans = new List<int>();

            InorderTraversalPart(root, ans);

            return ans;
        }

        private void InorderTraversalPart(TreeNode node, List<int> values)
        {
            if (node == null) return;

            if (node.left != null) InorderTraversalPart(node.left, values);
            values.Add(node.val);
            if (node.right != null) InorderTraversalPart(node.right, values);
        }

        #endregion

        #region M 98. 验证二叉搜索树
        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;
            if (root.left != null && root.val <= root.left.val) return false;
            if (root.right != null && root.val >= root.right.val) return false;
            return IsValidBST(root.left) && IsValidBST(root.right);
        }

        #endregion

        #region M 99. 恢复二叉搜索树
        public void RecoverTree(TreeNode root)
        {
            if (root == null) return;
            var temp = root.left;
            root.left = root.right;
            root.right = temp;
            RecoverTree(root.left);
            RecoverTree(root.right);
        }

        #endregion

        #region E 100. 相同的树 2021-12-03 10:16:12

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(p);
            queue.Enqueue(q);

            while (queue.Any())
            {
                p = queue.Dequeue();
                q = queue.Dequeue();

                if ((p == null) != (q == null)) return false;
                if (p == null) continue;
                if (p.val != q.val) return false;

                queue.Enqueue(p.left);
                queue.Enqueue(q.left);

                queue.Enqueue(p.right);
                queue.Enqueue(q.right);
            }
            return true;
            if ((p == null) != (q == null)) return false;
            if (p == null) return true;
            if (p.val != q.val) return false;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
        #endregion

        #region E 101. 对称二叉树 2021-12-03 10:08:02
        public bool IsSymmetric(TreeNode root)
        {
            return IsSymmetric(root.left, root.right);
        }

        private bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;
            return left.val == right.val && IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
        }

        private bool IsSymmetric_迭代(TreeNode left, TreeNode right)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(left);
            q.Enqueue(right);

            while (q.Any())
            {
                left = q.Dequeue();
                right = q.Dequeue();

                if (left == null && right == null) continue;

                if (left == null || right == null || left.val != right.val) return false;

                q.Enqueue(left.left);
                q.Enqueue(right.right);

                q.Enqueue(left.right);
                q.Enqueue(right.left);
            }
            return true;
        }

        #endregion

        #region E 112. 路径总和 2021-12-02 09:46:13
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;
            if (targetSum < 0) return false;

            if (root.val == targetSum && root.left == null && root.right == null) return true;

            if (HasPathSum(root.left, targetSum - root.val)) return true;

            if (HasPathSum(root.right, targetSum - root.val)) return true;

            return false;
        }

        #endregion
    }
}
