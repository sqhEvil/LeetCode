using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace LeetCode.Tree._501
{
    class _501Solution
    {

        //给定一个有相同值的二叉搜索树（BST），找出 BST 中的所有众数（出现频率最高的元素）。

        //假定 BST 有如下定义：

        //结点左子树中所含结点的值小于等于当前结点的值
        //结点右子树中所含结点的值大于等于当前结点的值
        //左子树和右子树都是二叉搜索树
        //例如：
        //给定 BST[1, null, 2, 2],

        //   1
        //    \
        //     2
        //    /
        //   2
        //返回[2].

        //提示：如果众数超过1个，不需考虑输出顺序

        //进阶：你可以不使用额外的空间吗？（假设由递归产生的隐式调用栈的开销不被计算在内）
        TreeNode pnode = null;//父节点
        int count, max;
        public int[] FindMode(TreeNode root)
        {
            IList<int> result = new List<int>();
            MediumSort(root, result);
            return result.ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node">当前节点</param>
        /// <param name="result"></param>
        /// <param name="count">当前节点之前连续的</param>
        /// <param name="max"></param>
        /// <returns></returns>
        void MediumSort(TreeNode node, IList<int> result)
        {
            if (node == null)
            {
                return ;
            }
            MediumSort(node.left, result);
            if (node.val == pnode?.val)
            {
                count = count + 1;
            }
            else
            {
                count = 1;
            }
            pnode = node;
            if (count > max)
            {
                max = count;
                result.Clear();
            }
            if (count >= max)
            {
                result.Add(node.val);
            }
            Console.WriteLine($"node:{node.val},pnode:{pnode?.val},max:{max},count:{count},keys:{string.Join(',', result)}");
            MediumSort(node.right, result);
        }
    }
}
