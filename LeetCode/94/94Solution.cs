using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._94
{
    public class _94Solution
    {
        //给定一个二叉树，返回它的中序 遍历。

        //示例:

        //输入: [1,null,2,3]
        //   1
        //    \
        //     2
        //    /
        //   3

        //输出: [1,3,2]
        //        进阶: 递归算法很简单，你可以通过迭代算法完成吗？。

        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root != null)
            {
                if (root.left != null)//左树不为空，将当前节点压入栈（当前节点以及右树后续处理）
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    result.Add(root.val);//左树为空，结果集加入当前节点值，处理当前节点右树
                    root = root.right;
                    if (root == null && stack.Count > 0)//如果右树为空，处理父节点及右树（如果有）
                    {
                        root = stack.Pop();
                        root.left = null;
                    }
                }
            }
            return result;
        }
    }
}
