using System;
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

        /// <summary>
        /// 获取节点的状态
        /// </summary>
        /// <param name="node"></param>
        /// <returns>数组索引0表示：当前节点有摄像头的最优解；索引1表示不论当前节点是否有摄像头的最优解；索引2表示不论当前节点是否有被监控的最优解。</returns>
        int[] GetCameraCOnverStatus(TreeNode node)
        {
            if (node == null)
            {
                int[] r = { int.MaxValue / 2, 0, 0 };
                return r;
            }
            int[] left = GetCameraCOnverStatus(node.left);
            int[] right = GetCameraCOnverStatus(node.right);
            int a = left[2] + right[2] + 1;//两个子树单独被覆盖，然后当前节点再放置一个摄像头
            //当前节点对应树的最优解在一下三种情况中取最优：
            //当前节点有摄像头后的最优解；
            //当前节点没有摄像头，左节点有摄像头，右节点最优；
            //当前节点没有摄像头，右节点有摄像头，左节点最优。
            int b = Math.Min(a, Math.Min(left[0] + right[1], left[1] + right[0]));
            //无论当前节点是否被覆盖，只覆盖两个子节点的最优解在以下两种情况中取最优：
            //1.当前节点有摄像头之后的最优解（两个子节点分开考虑之后，两子个节点都放置了摄像头，可以合并到当前节点。）
            //      0
            //    /   \
            //   0     0
            //2.分别覆盖左节点和右节点最优解之和
            int c = Math.Min(a, left[1] + right[1]);
            int[] result = { a, b, c };
            return result;
        }
    }
}
