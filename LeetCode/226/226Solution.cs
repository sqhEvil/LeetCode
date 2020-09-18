
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._226
{
    class _226Solution
    {
        //翻转一棵二叉树。

        //示例：

        //输入：

        //     4
        //   /   \
        //  2     7
        // / \   / \
        //1   3 6   9
        //输出：

        //     4
        //   /   \
        //  7     2
        // / \   / \
        //9   6 3   1

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public TreeNode InvertTree(TreeNode root)
        {
            Change(root);
            return root;
        }
        void Change(TreeNode root)
        {
            if (root != null)
            {
                var tem = root.left;
                root.left = root.right;
                root.right = tem;
                Change(root.left);
                Change(root.right);
            }
        }
    }
}
