using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._763
{
    class _763Solution
    {
        public IList<int> PartitionLabels(string S)
        {
            IList<int> result = new List<int>();
            int[][] l = new int[26][];
            for (int i = 0; i < 26; i++)
            {
                int[] vs = { -1, -2 };
                l[i] = vs;

            }
            for (int i = 0; i < S.Length; i++)
            {
                if (l[S[i] - 'a'][0] < 0)
                {
                    l[S[i] - 'a'][0] = i;
                    l[S[i] - 'a'][1] = i;
                }
                else
                {
                    l[S[i] - 'a'][1] = i;
                }
            }
            Array.Sort(l, (a, b) => a[0] - b[0]);
            int s = -1, e = -1;
            for (int i = 0; i < 26; i++)
            {
                if (l[i][0] >= 0)
                {
                    if (s < 0)
                    {
                        s = l[i][0];
                        e = l[i][1];
                        continue;
                    }
                    if (l[i][0] > e)
                    {
                        result.Add(e - s);
                        s = -1; e = -1;
                    }
                    else
                    {
                        e = Math.Max(e, l[i][1]);
                    }
                }
            }
            if (s > 0)
            {
                result.Add(e - s + 1);
            }
            return result;
        }


        public int NetworkDelayTime(int[][] times, int N, int K)
        {
            List<int>[] vs = new List<int>[N + 1];
            for (int i = 1; i <= N; i++)
            {
                vs[i] = new List<int>();
            }
            for (int i = 0; i < times.Length; i++)
            {
                vs[times[i][0]].Add(i);
            }
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine($"{i}---{string.Join(',', vs[i])}");
            }
            bool[] isTurn = new bool[N + 1];
            int dfs(int tem)
            {
                isTurn[tem] = true;
                Console.WriteLine($"{tem}---{string.Join(',', vs[tem])}");
                int count = 0;
                for (int i = 0; i < vs[tem].Count; i++)
                {
                    var r = times[vs[tem][i]];
                    Console.WriteLine(r[1]);
                    count = Math.Max(count, r[2] + dfs(r[1]));
                }
                return count;
            }
            int result = dfs(K);
            for (int i = 1; i <= N; i++)
            {
                if (!isTurn[i]) return -1;
            }
            return result;
        }
        //bool isPalindrome(ListNode* head)
        //{
        //    return false;
        //}

    }
}
