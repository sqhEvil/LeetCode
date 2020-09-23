using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace LeetCode.Tree._538
{
    public class _538Solution
    {
        //给定一个二叉搜索树（Binary Search Tree），把它转换成为累加树（Greater Tree)，使得每个节点的值是原来的节点值加上所有大于它的节点值之和。



        //例如：

        //输入: 原始二叉搜索树:
        //              5
        //            /   \
        //           2     13

        //输出: 转换为累加树:
        //             18
        //            /   \
        //          20     13
        
        public TreeNode ConvertBST(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }
            int sum = 0;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            var tem = root;
            while (stack.Count > 0)
            {
                while (stack.Peek().right != null)
                {
                    stack.Push(stack.Peek().right);
                }
                while (stack.Count > 0)
                {
                    tem = stack.Pop();
                    sum += tem.val;
                    tem.val = sum;

                    if (tem.left != null)
                    {
                        stack.Push(tem.left);
                        break;
                    }
                }

            }
            return root;
        }
    }
}
