using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1178
{
    class _1178Solution
    {

        /// <summary>
        /// word中包含puzzle中的第一个字符
        /// word中每一个字符 puzzles中都包含
        /// 1 <= words.length <= 10^5
        ///4 <= words[i].length <= 50
        ///1 <= puzzles.length <= 10^4
        ///puzzles[i].length == 7
        ///words[i][j], puzzles[i][j] 都是小写英文字母。
        ///每个 puzzles[i] 所包含的字符都不重复。
        /// </summary>
        /// <param name="words"></param>
        /// <param name="puzzles"></param>
        /// <returns></returns>
        public IList<int> FindNumOfValidWords(string[] words, string[] puzzles)
        {
            IList<int> result = new List<int>();
            Dictionary<int, int> dc = new Dictionary<int, int>();

            foreach (var word in words)
            {
                int mark = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    mark |= (1 << word[i] - 'a');
                }
                if (dc.ContainsKey(mark))
                {
                    dc[mark]++;
                }
                else
                {
                    dc.Add(mark, 1);
                }
            }

            foreach (var puzzle in puzzles)
            {
                int temR = 0;
                int mark = 0;
                for (int j = 1; j < 7; j++)
                {
                    mark |= (1 << puzzle[j] - 'a');
                }

                int tem = mark;
                while (tem > 0)
                {
                    int s = 1 << (puzzle[0] - 'a') | tem;
                    if (dc.ContainsKey(s))
                    {
                        temR += dc[s];
                    }
                    tem = (tem - 1) & mark;
                }
                if (dc.ContainsKey(1 << (puzzle[0] - 'a')))
                {
                    temR += dc[1 << (puzzle[0] - 'a')];
                }
                result.Add(temR);
            }
            return result;
        }
    }
}
