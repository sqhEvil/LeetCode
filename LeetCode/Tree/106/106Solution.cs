using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Tree._106
{
    class _106Solution
    {
        //根据一棵树的中序遍历与后序遍历构造二叉树。

        //注意:
        //你可以假设树中没有重复的元素。

        //例如，给出

        //中序遍历 inorder   = [9, 3,  15,20, 7]
        //后序遍历 postorder = [9, 15, 7, 20, 3]
        //返回如下的二叉树：

        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            int l = inorder.Length; if (l == 0) return null;
            var root = GetNode(inorder, postorder, 0, 0, l);
            return root;
        }

        TreeNode GetNode(int[] inorder, int[] postorder, int inStart, int postStart, int Length)
        {
            var leftLength = 0;
            for (int i = inStart; i < inStart + Length; i++)
            {
                if (inorder[i] == postorder[postStart + Length - 1])
                {
                    break;
                }
                leftLength++;
            }
            TreeNode root = new TreeNode(postorder[postStart + Length - 1]);
            if (leftLength > 0)
                root.left = GetNode(inorder, postorder, inStart, postStart, leftLength);
            var rightLength = Length - leftLength - 1;
            if (rightLength > 0)
                root.right = GetNode(inorder, postorder, inStart + leftLength + 1, postStart + leftLength, rightLength);
            return root;
        }
    }
}
