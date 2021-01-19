using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._803
{
    class _803Solution
    {
        List<List<int>> step = new List<List<int>>()
        {
            new List<int>{  1 , 0 },
            new List<int>{ -1 , 0 },
            new List<int>{  0 , 1 },
            new List<int>{  0 ,-1 },
        };
        public int[] HitBricks(int[][] grid, int[][] hits)
        {
            int[] result = new int[hits.Length];
            for (int i = 0; i < hits.Length; i++)
            {
                grid[hits[i][0]][hits[i][1]] -= 1;
            }
            int size = grid.Length * grid[0].Length;
            UnionFind uf = new UnionFind(size + 1);
            for (int i = 0; i < grid[0].Length; i++)
            {
                if (grid[0][i] == 1)
                {
                    uf.Union(i, size);
                }
            }
            for (int i = 1; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        if (grid[i - 1][j] == 1)
                        {
                            uf.Union((i - 1) * grid[0].Length + j, i * grid[0].Length + j);
                        }
                        if (j > 0 && grid[i][j - 1] == 1)
                        {
                            uf.Union(i * grid[0].Length + j - 1, i * grid[0].Length + j);
                        }
                    }
                }
            }
            for (int i = hits.Length - 1; i > 0; i--)
            {
                grid[hits[i][0]][hits[i][1]] += 1;

                if (grid[hits[i][0]][hits[i][1]] == 1)
                {
                    int preCount = uf.GetSize(size);
                    if (hits[i][0] == 0)
                    {
                        uf.Union(hits[i][1], size);
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        var x = hits[i][0] + step[j][0];
                        var y = hits[i][1] + step[j][0];
                        if (x >= 0 && y >= 0 && x < grid.Length && y < grid[0].Length && grid[x][y] == 1)
                        {
                            uf.Union(hits[i][0] * grid[0].Length + hits[i][1], x * grid[0].Length + y);
                        }
                    }
                    int unionedCount = uf.GetSize(size);
                    result[i] = Math.Max(0, unionedCount - preCount - 1);
                }
            }
            return result;
        }
        public class UnionFind
        {
            int[] parents;
            int[] size;
            public UnionFind(int count)
            {
                parents = new int[count];
                size = new int[count];
                for (int i = 0; i < count; i++)
                {
                    parents[i] = i;
                    size[i] = 1;
                }
            }

            public int Find(int index)
            {
                if (parents[index] != index)
                {
                    parents[index] = Find(parents[index]);
                }
                return parents[index];
            }
            public void Union(int index1, int index2)
            {
                var a = Find(index1);
                var b = Find(index2);
                parents[a] = b;
                Console.WriteLine(string.Join(',', parents));
                if (a != b)
                {
                    size[b] += size[a];
                }
            }

            public int GetSize(int index)
            {
                return size[Find(index)];
            }
        }
    }
}
