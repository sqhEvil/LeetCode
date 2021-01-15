using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._743
{
    public class _743Solution
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            int[] startToNode = new int[n];//记录起点到各个点的最近距离
            int[][] graph = new int[n][];//记录个点间的距离
            bool[] isVisited = new bool[n];//记录各点是否已经访问
            for (int i = 0; i < n; i++)
            {
                startToNode[i] = int.MaxValue;
                graph[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    graph[i][j] = int.MaxValue;
                }
                graph[i][i] = 0;//默认自己到自己距离为0，到其他点距离为无穷大
            }
            for (int i = 0; i < times.Length; i++)
            {
                graph[times[i][0] - 1][times[i][1] - 1] = times[i][2];//根据图设置点到点距离
            }
            for (int i = 0; i < n; i++)
            {
                startToNode[i] = graph[k - 1][i];
            }
            isVisited[k - 1] = true;
            startToNode[k - 1] = 0;

            for (int i = 0; i < n; i++)
            {
                if (FindMinNode() < 0)
                {
                    break;
                }
            }


            int FindMinNode()
            {
                int min = int.MaxValue, minNode = -1;
                for (int i = 0; i < n; i++)//找离起点最近的点
                {
                    if (!isVisited[i] && startToNode[i] < min)
                    {
                        min = startToNode[i];
                        minNode = i;
                    }
                }
                Console.WriteLine(minNode);
                if (minNode >= 0)
                {
                    isVisited[minNode] = true;
                    startToNode[minNode] = min;
                    Console.WriteLine(min);
                    //松弛其他点当前点的最小点
                    for (int i = 0; i < n; i++)
                    {
                        if (graph[minNode][i] != int.MaxValue &&
                        startToNode[i] > startToNode[minNode] + graph[minNode][i])
                        {
                            startToNode[i] = startToNode[minNode] + graph[minNode][i];
                        }
                        Console.Write(startToNode[i]); Console.Write("||");
                    }
                    Console.WriteLine("");
                }
                return minNode;
            }

            var max = -1;
            for (int i = 0; i < n; i++)
            {
                if (max < startToNode[i])
                {
                    max = startToNode[i];
                }
            }

            return max == int.MaxValue ? -1 : max;
        }
    }
}
