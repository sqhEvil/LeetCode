
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._771
{
    class _771Solu
    {
        //给定字符串J 代表石头中宝石的类型，和字符串 S代表你拥有的石头。 S 中每个字符代表了一种你拥有的石头的类型，你想知道你拥有的石头中有多少是宝石。

        //J 中的字母不重复，J 和S中的所有字符都是字母。字母区分大小写，因此"a"和"A"是不同类型的石头。

        //示例 1:

        //输入: J = "aA", S = "aAAbbbb"
        //输出: 3
        //示例 2:

        //输入: J = "z", S = "ZZ"
        //输出: 0

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/jewels-and-stones
        public int NumJewelsInStones(string J, string S)
        {
            int sum = 0;
            var sa = S.ToCharArray();
            var ja = J.ToCharArray();
            Dictionary<char, int> dc = new Dictionary<char, int>();
            for (int i = 0; i < sa.Length; i++)
            {
                if (dc.ContainsKey(sa[i]))
                {
                    dc[sa[i]]++;
                }
                else
                {
                    dc.Add(sa[i], 1);
                }
            }
            for (int i = 0; i < ja.Length; i++)
            {
                if (dc.ContainsKey(ja[i]))
                {
                    sum += dc[ja[i]];
                }
            }
            return sum;
        }
    }
}
