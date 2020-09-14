using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._216
{
    public class _216Solution
    {
        //找出所有相加之和为 n 的 k个数的组合。组合中只允许含有 1 - 9 的正整数，并且每种组合中不存在重复的数字。

        //说明：

        //所有数字都是正整数。
        //解集不能包含重复的组合。 
        //示例 1:

        //输入: k = 3, n = 7
        //输出: [[1,2,4]]
        //示例 2:

        //输入: k = 3, n = 9
        //输出: [[1,2,6], [1,3,5], [2,3,4]]
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> tem = new List<int>();
            BackTracking(n, k, result, tem, 1);
            return result;
        }

        void BackTracking(int n, int k, IList<IList<int>> result, IList<int> tem, int start)
        {
            if (k == 0 && n == 0)
            {
                result.Add(new List<int>(tem));
                return;
            }
            if (k < 0 || n < 0)
            {
                return;
            }
            for (int i = start; i <= 9; i++)
            {
                if (n - i < 0)
                {
                    break;
                }
                tem.Add(i);
                BackTracking(n - i, k - 1, result, tem, i + 1);
                tem.RemoveAt(tem.Count - 1);
            }
        }
    }
}
