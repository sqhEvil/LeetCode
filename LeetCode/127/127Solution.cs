using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._127
{
    class _127Solution
    {
        int index = 0;
        Dictionary<string, int> map = new Dictionary<string, int>();
        List<List<int>> vs = new List<List<int>>();

        void AddMap(string val)
        {
            if (!map.ContainsKey(val))
            {
                map.Add(val, index++);
            }
        }
        void AddString(string val)
        {
            AddMap(val);
            for (int i = 0; i < val.Length; i++)
            {
                var ar = val.ToCharArray();
                ar[i] = '*';
                var s = ar.ToString();
                AddMap(val);
            }
        }

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            int result = 0;


            return result;
        }
    }
}
