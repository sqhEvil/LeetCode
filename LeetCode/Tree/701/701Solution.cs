﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Tree._701
{
    class _701Solution
    {
        //给定二叉搜索树（BST）的根节点和要插入树中的值，将值插入二叉搜索树。 返回插入后二叉搜索树的根节点。 输入数据保证，新值和原始二叉搜索树中的任意节点值都不同。
        //注意，可能存在多种有效的插入方式，只要树在插入后仍保持为二叉搜索树即可。 你可以返回任意有效的结果。

        //例如, 

        //给定二叉搜索树:

        //        4
        //       / \
        //      2   7
        //     / \
        //    1   3

        //和 插入的值: 5
        //你可以返回这个二叉搜索树:

        //         4
        //       /   \
        //      2     7
        //     / \   /
        //    1   3 5
        //或者这个树也是有效的:

        //         5
        //       /   \
        //      2     7
        //     / \   
        //    1   3
        //         \
        //          4


        //提示：

        //给定的树上的节点数介于 0 和 10^4 之间
        //每个节点都有一个唯一整数值，取值范围从 0 到 10^8
        //-10^8 <= val <= 10^8
        //新值和原始二叉搜索树中的任意节点值都不同

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/insert-into-a-binary-search-tree

        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            var tem = root;
            while (tem != null)
            {
                if (tem.val < val)
                {
                    if (tem.right == null)
                    {
                        tem.right = new TreeNode(val);
                        return root;
                    }
                    else
                    {
                        tem = tem.right;
                    }
                }
                else
                {
                    if (tem.left == null)
                    {
                        tem.left = new TreeNode(val);
                        return root;
                    }
                    else
                    {
                        tem = tem.left;
                    }
                }
            }
            return root;
        }
    }
}
