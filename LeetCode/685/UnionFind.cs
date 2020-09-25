using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._685
{
    
    public class Solution
    {
        public class UnionFind
        {
            int[] anscer;
            public UnionFind(int length)
            {
                anscer = new int[length + 1];
                for (int i = 0; i < length + 1; i++)
                {
                    anscer[i] = i;
                }
            }
            public void InsertUf(int a, int b)
            {
                anscer[GetRoot(a)] = GetRoot(b);
            }
            public int GetRoot(int val)
            {
                if (anscer[val] != val)
                {
                    anscer[val] = GetRoot(anscer[val]);
                }
                return anscer[val];
            }

        }
        public int[] FindRedundantDirectedConnection(int[][] edges)
        {
            UnionFind uf = new UnionFind(edges.Length);
            int cycle = -1;
            int twoP = -1;
            int[] par = new int[edges.Length+1];
            for (int i = 0; i < edges.Length+1; i++)
            {
                par[i] = i;
            }
            for (int i = 0; i < edges.Length; i++)
            {
                if (par[edges[i][1]] != edges[i][1])
                {
                    twoP = i;
                }
                else
                {
                    par[edges[i][1]] = edges[i][0];
                    if (uf.GetRoot(edges[i][0]) == uf.GetRoot(edges[i][1]))
                    {
                        cycle = i;
                    }
                    else
                    {
                        uf.InsertUf(edges[i][0], edges[i][1]);
                    }
                }

            }
            if (twoP < 0)//没有双父节点的情况，直接最后一个导致返回循环节点
            {
                return edges[cycle];
            }
            else
            {
                //有双府节点，数组第二个值一定是双父节点数组的第二个值，即edges[twoP][1]
                //当没有环时，删除后面一个双父节点即可。
                //当有环时，由于判断属于双父亲节点后，没有加入并查集，故当前双父节点不可能是环，只能是双父节点的另一条边为环。
                //此时应该删除双父节点的另一条边。另一条边的第一个值，在判断环时记入了par数组，即par[edges[twoP][1]].
                if (cycle > 0)
                {
                    int[] tem = { par[edges[twoP][1]], edges[twoP][1] };
                    return tem;
                }
                else
                {
                    return edges[twoP];
                }
            }

        }

    }

}
