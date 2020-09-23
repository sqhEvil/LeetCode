using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Tree._404
{
    public class _404Solution
    {
        //计算给定二叉树的所有左叶子之和。

        //示例：

        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7

        //在这个二叉树中，有两个左叶子，分别是 9 和 15，所以返回 24
        //[0,2,4,1,null,3,-1,5,1,null,6,null,8]
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null) return 0;
            int sum = 0;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                root = stack.Pop();
                if (root.left != null)
                {
                    if (root.left.left == null && root.left.right == null)
                    {
                        sum += root.left.val;
                    }
                    stack.Push(root.left);
                }
                if (root.right != null)
                {
                    stack.Push(root.right);
                }
            }
            return sum;
        }
    }
}
