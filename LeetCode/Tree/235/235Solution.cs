using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace LeetCode.Tree._235
{
    class _235Solution
    {
        //给定一个二叉搜索树, 找到该树中两个指定节点的最近公共祖先。

        //百度百科中最近公共祖先的定义为：“对于有根树 T 的两个结点 p、q，最近公共祖先表示为一个结点 x，满足 x 是 p、q 的祖先且 x 的深度尽可能大（一个节点也可以是它自己的祖先）。”

        //例如，给定如下二叉搜索树:  root = [6,2,8,0,4,7,9,null,null,3,5]
        //        示例 1:

        //输入: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
        //输出: 6 
        //解释: 节点 2 和节点 8 的最近公共祖先是 6。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-search-tree

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val < q.val)
            {
                root = GetLowestNode(root, p, q);
            }
            else
            {
                root = GetLowestNode(root, q, p);
            }
            return root;
        }
        //情形1：p,q互为父子节点，选取期中祖先节点的父节点。，，公共节点需要
        //情形2：p，q没有祖先节点关系，选取层级高的父节点。，，公共节点需要满足，节点值位于2者之间
        //思路：
        public TreeNode GetLowestNode(TreeNode root, TreeNode min, TreeNode max)
        {
            if (root.val >= min.val && root.val <= max.val)
                return root;
            if (root.val > min.val && root.val > max.val)//比两者都大，结果往左节点找
            {
                return GetLowestNode(root.left, min, max);
            }
            if (root.val < min.val && root.val < max.val)//比两者都小，结果往右节点找
            {
                return GetLowestNode(root.right, min, max);
            }
            return null;
        }
    }
}
