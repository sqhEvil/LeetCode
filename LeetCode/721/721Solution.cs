using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._721
{
    class _721Solution
    {

        public IList<IList<string>> AccountsMerge1(IList<IList<string>> accounts)
        {
            IList<IList<string>> result = new List<IList<string>>();
            for (int i = 0; i < accounts.Count; i++)
            {
                for (int j = 0; j < result.Count; j++)
                {
                    if (accounts[i][0] == result[j][0])
                    {
                        bool isHas = false;
                        for (int k = 1; k < accounts[i].Count; k++)
                        {
                            for (int l = 1; l < result[j].Count; l++)
                            {
                                if (accounts[i][k] == result[j][l])
                                {
                                    isHas = true;
                                    break;
                                }
                            }
                            if (isHas)
                            {
                                break;
                            }
                        }
                        if (isHas)//isHas有问题，多重关联就不行了。
                        {
                            result.Add(accounts[i]);
                        }
                        else
                        {
                            for (int k = 1; k < accounts[i].Count; k++)
                            {
                                bool isContains = false;
                                for (int l = 1; l < result[j].Count; l++)
                                {
                                    if (accounts[i][k] == result[j][l])
                                    {
                                        isContains = true;
                                        break;
                                    }
                                }
                                if (!isContains)
                                {
                                    result[j].Add(accounts[i][k]);
                                }
                            }
                        }
                    }
                    else
                    {
                        result.Add(accounts[i]);
                    }
                }
            }
            return result;
        }

        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Dictionary<string, int> startToIndex = new Dictionary<string, int>();
            Dictionary<string, string> startToName = new Dictionary<string, string>();
            int index = 0;
            //转换邮箱与姓名关联
            for (int i = 0; i < accounts.Count; i++)
            {
                for (int j = 1; j < accounts[i].Count; j++)
                {
                    if (!startToIndex.ContainsKey(accounts[i][j]))
                    {
                        startToIndex.Add(accounts[i][j], index++);
                        startToName.Add(accounts[i][j], accounts[i][0]);
                    }
                }
            }
            //转化并查集
            UnionFind uf = new UnionFind(index);
            for (int i = 0; i < accounts.Count; i++)
            {
                var first = startToIndex[accounts[i][1]];
                for (int j = 2; j < accounts[i].Count; j++)
                {
                    var tem = startToIndex[accounts[i][j]];
                    uf.Union(first, tem);
                }
            }
            //邮箱并查集转换哈希表
            Dictionary<int, List<string>> dc = new Dictionary<int, List<string>>();
            foreach (var item in startToIndex)
            {
                var tem = uf.Find(item.Value);
                if (dc.ContainsKey(tem))
                {
                    dc[tem].Add(item.Key);
                }
                else
                {
                    dc.Add(tem, new List<string>() { item.Key });
                }
            }
            //邮箱hash表转列表
            foreach (var item in dc)
            {
                item.Value.Sort((a, b) => string.Compare(a, b, StringComparison.Ordinal));
                var tem = item.Value.Prepend(startToName[item.Value[0]]);
                result.Add(tem.ToList());
            }
            return result;
        }

        public class UnionFind
        {
            int[] parents;
            public UnionFind(int count)
            {
                parents = new int[count];
                for (int i = 0; i < count; i++)
                {
                    parents[i] = i;
                }
            }
            public void Union(int index1, int index2)
            {
                parents[Find(index1)] = Find(index2);
            }

            public int Find(int index)
            {
                if (parents[index] != index)
                {
                    parents[index] = Find(parents[index]);
                }
                return parents[index];
            }
        }
    }
}
