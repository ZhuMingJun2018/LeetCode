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

        #region E 100. 相同的树

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if ((p == null) != (q == null)) return false;
            if (p.val != q.val) return false;
            if (p == null && q == null) return true;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
        #endregion

        #region E 101. 对称二叉树
        public bool IsSymmetric(TreeNode root)
        {

        }

        private bool IsSymmetric(TreeNode left, TreeNode treeNode)
        {

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
