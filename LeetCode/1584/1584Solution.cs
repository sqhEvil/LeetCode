using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1584
{
    class _1584Solution
    {
        //给你一个points 数组，表示 2D 平面上的一些点，其中 points[i] = [xi, yi] 。
        //连接点[xi, yi] 和点[xj, yj] 的费用为它们之间的 曼哈顿距离 ：|xi - xj| + |yi - yj| ，其中 |val| 表示 val 的绝对值。
        //请你返回将所有点连接的最小总费用。只有任意两点之间 有且仅有 一条简单路径时，才认为所有点都已连接。
        public int MinCostConnectPoints(int[][] points)
        {
            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    edges.Add(new Edge(Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]), i, j));
                }
            }
            edges.Sort((a, b) => a.len - b.len);
            int result = 0;

            int[] parents = new int[points.Length];
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = i;
            }
            int Find(int index)
            {
                if (parents[index] != index)
                {
                    parents[index] = Find(parents[index]);
                }
                return parents[index];
            }
            void Union(int i1, int i2)
            {
                int r1 = Find(i1);
                int r2 = Find(i2);
                parents[r1] = r2;
            }
            foreach (var edge in edges)
            {
                if (Find(edge.a) != Find(edge.b))
                {
                    Union(edge.a, edge.b);
                    result += edge.len;
                }
            }

            return result;
        }

        public class Edge
        {
            public Edge(int _len, int _a, int _b)
            {
                len = _len;
                a = _a;
                b = _b;
            }
            public int len { get; set; }
            public int a { get; set; }
            public int b { get; set; }
        }
    }
}
