using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace LeetCode.Tree._129
{
    class _129Solution
    {

        //给定一个二叉树，它的每个结点都存放一个 0-9 的数字，每条从根到叶子节点的路径都代表一个数字。

        //例如，从根到叶子节点路径 1->2->3 代表数字 123。

        //计算从根到叶子节点生成的所有数字之和。

        //说明: 叶子节点是指没有子节点的节点。

        //示例 1:

        //输入: [1,2,3]
        //    1
        //   / \
        //  2   3
        //输出: 25
        //解释:
        //从根到叶子节点路径 1->2 代表数字 12.
        //从根到叶子节点路径 1->3 代表数字 13.
        //因此，数字总和 = 12 + 13 = 25.
        //示例 2:

        //输入: [4,9,0,5,1]
        //    4
        //   / \
        //  9   0
        // / \
        //5   1
        //输出: 1026
        //解释:
        //从根到叶子节点路径 4->9->5 代表数字 495.
        //从根到叶子节点路径 4->9->1 代表数字 491.
        //从根到叶子节点路径 4->0 代表数字 40.
        //因此，数字总和 = 495 + 491 + 40 = 1026.
        //
        public int SumNumbers(TreeNode root)
        {
            int result = 0;
            if (root == null)
            {
                return 0;
            }
            IList<TreeNode> tem = new List<TreeNode>();
            void dfs(TreeNode node)
            {
                tem.Add(node);
                if (node.left == null && node.right == null)//叶子节点，计算
                {
                    result += Caculate(tem);
                    tem.RemoveAt(tem.Count - 1);
                }
                if (node.left != null)
                {
                    dfs(node.left);
                }
                if (node.right != null)
                {
                    dfs(node.right);
                }
            }
            dfs(root);
            return result;
        }
        int Caculate(IList<TreeNode> tem)
        {
            int result = 0;
            for (int i = 0; i < tem.Count; i++)
            {
                result += tem[i].val * (int)Math.Pow(10, (tem.Count - i - 1));
            }
            return result;
        }


        public int IslandPerimeter(int[][] grid)
        {
            int n = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        if (i == 0 || grid[i - 1][j] == 0)//上
                        {
                            n++;
                        }
                        if (i == grid.Length - 1 || grid[i + 1][j] == 0)//下
                        {
                            n++;
                        }
                        if (j == 0 || grid[i][j - 1] == 0)//左
                        {
                            n++;
                        }
                        if (j == grid[i].Length - 1 || grid[i][j + 1] == 0)//右
                        {
                            n++;
                        }
                    }
                }
            }
            return n;
        }
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            List<int> result = new List<int>();
            HashSet<int> h = new HashSet<int>();
            foreach (var item in nums1)
            {
                h.Add(item);
            }
            foreach (var item in nums2)
            {
                if (h.Contains(item))
                {
                    h.Remove(item);
                    result.Add(item);
                }
            }
            return result.ToArray();
        }

        public bool ValidMountainArray(int[] A)
        {
            if (A.Length < 3 || A[1] < A[0])
            {
                return false;
            }
            bool result = false;
            for (int i = 2; i < A.Length; i++)
            {
                if (A[i] == A[i - 1] || (result && A[i] > A[i - 1]))
                {
                    return false;
                }
                else if ((!result) && A[i] < A[i - 1])
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
