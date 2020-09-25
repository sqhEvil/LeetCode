using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._685
{
    public class _685Solution
    {
        //在本问题中，有根树指满足以下条件的有向图。该树只有一个根节点，所有其他节点都是该根节点的后继。每一个节点只有一个父节点，除了根节点没有父节点。

        //输入一个有向图，该图由一个有着N个节点(节点值不重复1, 2, ..., N) 的树及一条附加的边构成。附加的边的两个顶点包含在1到N中间，这条附加的边不属于树中已存在的边。

        //结果图是一个以边组成的二维数组。 每一个边 的元素是一对[u, v]，用以表示有向图中连接顶点 u 和顶点 v 的边，其中 u 是 v 的一个父节点。

        //返回一条能删除的边，使得剩下的图是有N个节点的有根树。若有多个答案，返回最后出现在给定二维数组的答案。

        //示例 1:

        //输入: [[1,2], [1,3], [2,3]]
        //输出: [2,3]
        //        解释: 给定的有向图如下:
        //  1
        // / \
        //v v
        //2-->3
        //示例 2:

        //输入: [[1,2], [2,3], [3,4], [4,1], [1,5],[5,6],[6,7],[7,1]]
        //输出: [4,1]
        //        解释: 给定的有向图如下:
        //5 <- 1 -> 2
        //     ^    |
        //     |    v
        //     4 <- 3
        //注意:

        //二维数组大小的在3到1000范围内。
        //二维数组中的每个整数在1到N之间，其中 N 是二维数组的大小。
        //5 <- 1 -> 2
        //     ^    |
        //     |    v
        //     4 <- 3
        //有环无冲突 [[1,2],[2,3],[3,1]]
        //有环有冲突[[1, 2],[2,3],[3,1],[4,2]]
        //无环有冲突[[1, 2],[1,3],[2,3]]


        public class UnionFind
        {
            int[] ancestor;
            public UnionFind(int length)
            {
                ancestor = new int[length];
                for (int i = 0; i < length; i++)
                {
                    ancestor[i] = i;
                }
            }

            public int find(int index)
            {
                if (ancestor[index] != index)
                {
                    ancestor[index] = find(ancestor[index]);
                }
                return ancestor[index];
            }
            public void Union(int index1, int index2)
            {
                ancestor[find(index1)] = find(index2);
            }
        }
        public int[] findRedundantDirectedConnection(int[][] edges)
        {
            int l = edges.Length;
            UnionFind uf = new UnionFind(l + 1);
            int[] par = new int[l + 1];
            for (int i = 0; i < l; i++)
            {
                par[i] = i;
            }
            int conflict = -1;
            int cycle = -1;
            for (int i = 0; i < l; i++)
            {
                int left = edges[i][0];
                int right = edges[i][1];
                if (par[right] != right)
                {
                    conflict = i;
                }
                else
                {
                    par[right] = left;
                    if (uf.find(left) == uf.find(right))
                    {
                        cycle = i;
                    }
                    else
                    {
                        uf.Union(left, right);
                    }
                }
            }
            if (conflict < 0)
            {
                return edges[cycle];
            }
            else
            {
                if (cycle > 0)
                {
                    int[] r = { par[edges[conflict][1]], edges[conflict][1] };
                    return r;
                }
                else
                {
                    return edges[conflict];
                }
            }
        }

    }
}
