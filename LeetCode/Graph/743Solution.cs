using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graph
{
    class _743Solution
    {
        //        有 N 个网络节点，标记为 1 到 N。

        //给定一个列表 times，表示信号经过有向边的传递时间。 times[i] = (u, v, w)，其中 u 是源节点，v 是目标节点， w 是一个信号从源节点传递到目标节点的时间。

        //现在，我们从某个节点 K 发出一个信号。需要多久才能使所有节点都收到信号？如果不能使所有节点收到信号，返回 -1。
        //示例：
        //输入：times = [[2,1,1],[2,3,1],[3,4,1]], N = 4, K = 2
        //输出：2
        //2--->1
        //|
        //V
        //3--->4

        //注意:
        //N 的范围在[1, 100] 之间。
        //K 的范围在[1, N] 之间。
        //times 的长度在[1, 6000] 之间。
        //所有的边 times[i] = (u, v, w) 都有 1 <= u, v <= N 且 0 <= w <= 100。


        //测试用例：
        //[[2,1,1],[2,3,1],[3,4,1]]（常规）
        //4
        //2
        //[[2,1,1],[2,3,1],[3,2,1],[3,4,1]]（双向边）
        //4
        //2
        //[[1,2,1],[1,3,5],[2,3,1]](环，单边慢)
        //3
        //1
        //[[1,2,1],[1,3,1],[2,3,1]](环，单边快)
        //3
        //1
        //[[1,2,1],[2,1,3]]
        //2
        //2

        int networkDelayTime(int[][] times, int N, int K)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < times.Length; i++)
            {
                if (!graph.ContainsKey(times[i][0]))
                {
                    graph[times[i][0]] = new List<int>();
                }
                graph[times[i][0]].Add(i);
            }
            int[] path = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                path[i] = -1;
            }
            path[K] = 0;
            void dfs(int node)
            {
                if (graph.ContainsKey(node))
                {
                    for (int i = 0; i < graph[node].Count; i++)
                    {
                        var tem = times[graph[node][i]];
                        var l = path[node] + tem[2];
                        if (path[tem[1]] < 0 || path[tem[1]] > l)
                        {
                            path[tem[1]] = l;
                            dfs(tem[1]);
                        }
                    }
                }
            }

            dfs(K);
            int max = -1;
            for (int i = 1; i <= N; i++)
            {
                if (path[i] < 0)
                {
                    return -1;
                }
                max = Math.Max(max, path[i]);
            }
            return max;
        }
    }
}
