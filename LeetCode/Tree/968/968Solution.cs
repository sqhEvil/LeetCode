﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace LeetCode.Tree._968
{
    class _968Solution
    {
        //给定一个二叉树，我们在树的节点上安装摄像头。

        //节点上的每个摄影头都可以监视其父对象、自身及其直接子对象。

        //计算监控树的所有节点所需的最小摄像头数量。



        //示例 1：



        //输入：[0,0,null,0,0]
        //        输出：1
        //解释：如图所示，一台摄像头足以监控所有节点。
        //示例 2：



        //输入：[0,0,null,0,null,0,null,null,0]
        //        输出：2
        //解释：需要至少两个摄像头来监视树的所有节点。 上图显示了摄像头放置的有效位置之一。

        //提示：

        //给定树的节点数的范围是[1, 1000]。
        //每个节点的值都是 0。
        //链接：https://leetcode-cn.com/problems/binary-tree-cameras
        int result = 0;
        public int MinCameraCover(TreeNode root)
        {
            if (GetNodeStatus(root) == 0)
            {
                result++;
            }
            return result;
        }
        //0没有覆盖，1有摄像头，2无摄像头但是有覆盖。
        int GetNodeStatus(TreeNode node)
        {
            if (node == null)
            {
                return 2;
            }
            int left = GetNodeStatus(node.left);
            int right = GetNodeStatus(node.right);
            if (left == 2 && right == 2) return 0;//左右节点都有覆盖，则当前节点由父节点覆盖为最优解
            if (left == 0 || right == 0)//左右子节点有1个没有覆盖，当前节点都需要摄像头
            {
                result++;
                return 1;
            }
            if (left == 1 || right == 1)
            {
                return 2;
            }
            return -1;

        }
    }
}
