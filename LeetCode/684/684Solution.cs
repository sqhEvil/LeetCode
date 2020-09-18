using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._684
{
    class _684Solution
    {
        //在本问题中, 树指的是一个连通且无环的无向图。

        //输入一个图，该图由一个有着N个节点(节点值不重复1, 2, ..., N) 的树及一条附加的边构成。附加的边的两个顶点包含在1到N中间，这条附加的边不属于树中已存在的边。

        //结果图是一个以边组成的二维数组。每一个边的元素是一对[u, v] ，满足 u<v，表示连接顶点u 和v的无向图的边。

        //返回一条可以删去的边，使得结果图是一个有着N个节点的树。如果有多个答案，则返回二维数组中最后出现的边。答案边[u, v] 应满足相同的格式 u<v。

        //示例 1：

        //输入: [[1, 2], [1,3], [2,3]]
        //输出: [2,3]
        //        解释: 给定的无向图为:
        //  1
        // / \
        //2 - 3
        //示例 2：

        //输入: [[1,2], [2,3], [3,4], [1,4], [1,5]]
        //输出: [1,4]
        //        解释: 给定的无向图为:
        //5 - 1 - 2
        //    |   |
        //    4 - 3
        //注意:
         
        //输入的二维数组大小在 3 到 1000。
        //二维数组中的整数在1到N之间，其中N是输入数组的大小。
        public class Solution
        {
            public int[] FindRedundantConnection(int[][] edges)
            {
                bool[] isUse = new bool[edges.Length - 1];
                for (int i = edges.Length - 1; i > 0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (edges[j][0] == edges[i][0])
                        {
                            isUse[j] = true;
                            if (checkloop(edges, isUse, edges[j][1], i, j)) return edges[i];
                            isUse[j] = false;
                        }
                        else if (edges[j][1] == edges[i][0])
                        {
                            isUse[j] = true;
                            if (checkloop(edges, isUse, edges[j][0], i, j)) return edges[i];
                            isUse[j] = false;
                        }
                    }
                }
                return edges[0];
            }

            bool checkloop(int[][] edges, bool[] isUse, int start, int end, int index)
            {
                //Console.WriteLine($"index:{index},,start:{start},,end:{end}");
                if (edges[index][0] == edges[end][1] || edges[index][1] == edges[end][1])
                {
                    return true;
                }
                for (int i = 0; i < end; i++)
                {
                    if (isUse[i]) continue;
                    if (edges[i][0] == start)
                    {
                        isUse[i] = true;
                        if (checkloop(edges, isUse, edges[i][1], end, i)) return true;
                        isUse[i] = false;
                    }
                    else if (edges[i][1] == start)
                    {
                        isUse[i] = true;
                        if (checkloop(edges, isUse, edges[i][0], end, i)) return true;
                        isUse[i] = false;
                    }
                }
                return false;
            }


            public int[] FindRedundantConnection11(int[][] edges)
            {
                int N = edges.Length;
                int[] id = new int[N + 1];
                int[] size = new int[N + 1];
                for (int i = 0; i <= N; ++i)
                {
                    id[i] = i;
                    size[i] = 1;
                }
                foreach (int[] edge in edges)
                {
                    int p = edge[0];//左
                    int q = edge[1];//右
                    while (id[p] != p) p = id[p];
                    while (id[q] != q) q = id[q];
                    if (p == q) return edge;
                    if (size[p] >= size[q])
                    {
                        id[q] = p;
                        size[p] += size[q];
                    }
                    else
                    {
                        id[p] = q;
                        size[q] += size[p];
                    }
                }
                return edges[0];
            }

            //[[1,2],[2,3],[3,4],[1,4],[1,5]]
            //id[2]=1  size[1]=2
            //
        }
    }
}
