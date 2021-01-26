using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.monimianshi1
{
    class mn2Solution
    {
        /*152 给你一个整数数组 nums ，请你找出数组中乘积最大的连续子数组（该子数组中至少包含一个数字），并返回该子数组所对应的乘积。
         * 
         *  [2,3,-2,4]  6
         *  
         *  [-2,0,-1]  0
         *  
         *  [-3,-1,-1]  3
         *  
         *  
         *  [7,-2,-4] 56
         *  
         *  重点：整数，分割负数，0
         *  
         */

        public int MaxProduct(int[] nums)
        {
            int[] maxF = new int[nums.Length];
            int[] minF = new int[nums.Length];
            for (int i = 1; i < nums.Length; i++)
            {
                maxF[i] = Math.Max(maxF[i - 1] * nums[i], Math.Max(nums[i], minF[i - 1] * nums[i]));
                minF[i] = Math.Min(minF[i - 1] * nums[i], Math.Min(nums[i], maxF[i - 1] * nums[i]));
            }
            int result = int.MinValue;
            for (int i = 0; i < maxF.Length; i++)
            {
                result = Math.Max(result, maxF[i]);
            }
            return result;
        }

        public IList<int> AddToArrayForm(int[] A, int K)
        {
            List<int> result = new List<int>();
            int i = A.Length - 1;
            int j = 0;
            while (K > 0 || i >= 0)
            {
                var a = K % 10;
                var b = i >= 0 ? A[i] : 0;

                var tem = a + j + b;
                result.Add(tem % 10);
                j = tem / 10;
                K = K / 10;
                i--;
            }
            if (j > 0)
            {
                result.Add(j);
            }
            result.Reverse();
            return result;
        }

        //在由 1 x 1 方格组成的 N x N 网格 grid 中，每个 1 x 1 方块由 /、\ 或空格构成。这些字符会将方块划分为一些共边的区域。
        //（请注意，反斜杠字符是转义的，因此 \ 用 "\\" 表示。）。
        //返回区域的数目。
        public int RegionsBySlashes(string[] grid)
        {
            int n = grid.Length;
            int[] p = new int[4 * n * n];
            for (int i = 0; i < p.Length; i++)
            {
                p[i] = i;
            }
            int Find(int index)
            {
                if (p[index] != index)
                {
                    p[index] = Find(p[index]);
                }
                return p[index];
            }
            void union(int x, int y)
            {
                if (Find(x) != Find(y))
                {
                    p[Find(x)] = Find(y);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int blokci = (i * n + j) * 4;
                    int leftblocki = (i * n + j - 1) * 4;
                    int topblocki = ((i - 1) * n + j) * 4;
                    switch (grid[i][j])
                    {

                        case '/':
                            union(blokci, blokci + 1);
                            union(blokci + 2, blokci + 3);
                            break;
                        case '\\':
                            union(blokci, blokci + 2);
                            union(blokci + 1, blokci + 3);
                            break;
                        case ' ':
                            union(blokci, blokci + 2);
                            union(blokci + 1, blokci + 3);
                            union(blokci + 1, blokci + 2);
                            break;
                        default:
                            break;
                    }
                    if (i > 0)
                    {
                        union(topblocki + 3, blokci);
                    }
                    if (j > 0)
                    {
                        union(leftblocki + 2, blokci + 1);
                    }
                }
            }

            HashSet<int> hs = new HashSet<int>();
            int c = 0;
            for (int i = 0; i < p.Length; i++)
            {
                int r = Find(i);
                if (!hs.Contains(r))
                {
                    c++;
                    hs.Add(r);
                }
            }
            return c;
        }

        public int NumEquivDominoPairs(int[][] dominoes)
        {
            int result = 0;
            int[] keys = new int[100];
            for (int i = 0; i < dominoes.Length; i++)
            {
                int a = dominoes[i][0], b = dominoes[i][1];
                int x = Math.Min(a, b), y = Math.Max(a, b);
                int index = x * 10 + y;
                keys[index]++;
            }
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] > 1)
                {
                    result += keys[i] * (keys[i] - 1) / 2;
                }
            }
            return result;
        }

        //你这个学期必须选修 numCourse 门课程，记为 0 到 numCourse-1 。

        //在选修某些课程之前需要一些先修课程。 例如，想要学习课程 0 ，你需要先完成课程 1 ，我们用一个匹配来表示他们：[0,1]

        //给定课程总量以及它们的先决条件，请你判断是否可能完成所有课程的学习？

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/course-schedule
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        /*
        *1,2  2,3
        *4,1
        *
        */
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            List<int>[] graphDependenton = new List<int>[numCourses];
            int[] indgress = new int[numCourses];
            for (int i = 0; i < prerequisites.Length; i++)
            {
                int node = prerequisites[i][0];
                int pre = prerequisites[i][1];
                graphDependenton[pre] = graphDependenton[pre] ?? new List<int>();
                graphDependenton[pre].Add(node);
                indgress[node]++;
            }
            Queue<int> q = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indgress[i] == 0)
                {
                    q.Enqueue(i);
                }
            }
            int c = 0;
            while (q.Count > 0)
            {
                var tem = q.Dequeue();
                c++;
                if (graphDependenton[tem] != null)
                {
                    foreach (var item in graphDependenton[tem])
                    {
                        indgress[item]--;
                        if (indgress[item] == 0)
                        {
                            q.Enqueue(item);
                        }
                    }
                }
            }

            return c == numCourses;
        }

        public bool CanFinishdfs(int numCourses, int[][] prerequisites)
        {
            int[] flag = new int[numCourses];
            List<int>[] graph = new List<int>[numCourses];
            int[] indgress = new int[numCourses];
            for (int i = 0; i < prerequisites.Length; i++)
            {
                int node = prerequisites[i][0];
                int pre = prerequisites[i][1];
                graph[pre] = graph[pre] ?? new List<int>();
                graph[pre].Add(node);
                indgress[node]++;
            }
            Stack<int> s = new Stack<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indgress[i] == 0)
                {
                    s.Push(i);
                }
            }
            bool dfs(int i)
            {
                if (flag[i] == 1)
                {
                    return true;
                }
                if (flag[i] == -1)
                {
                    return false;
                }
                flag[i] = 1;
                if (graph[i] != null)
                {
                    foreach (var item in graph[i])
                    {
                        if (dfs(item))
                        {
                            return true;
                        }
                    }
                }
                flag[i] = -1;
                return false;
            }
            for (int i = 0; i < numCourses; i++)
            {
                if (dfs(i))
                {
                    return false;
                }
            }
            return true;
        }
    }

}
