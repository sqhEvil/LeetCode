using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DynamicPrograming._19
{
    class _19Solution
    {
        //小扣出去秋游，途中收集了一些红叶和黄叶，他利用这些叶子初步整理了一份秋叶收藏集 leaves， 字符串 leaves 仅包含小写字符 r 和 y， 其中字符 r 表示一片红叶，字符 y 表示一片黄叶。
        //出于美观整齐的考虑，小扣想要将收藏集中树叶的排列调整成「红、黄、红」三部分。每部分树叶数量可以不相等，但均需大于等于 1。每次调整操作，小扣可以将一片红叶替换成黄叶或者将一片黄叶替换成红叶。请问小扣最少需要多少次调整操作才能将秋叶收藏集调整完毕。

        //示例 1：

        //输入：leaves = "rrryyyrryyyrr"

        //输出：2

        //解释：调整两次，将中间的两片红叶替换成黄叶，得到 "rrryyyyyyyyrr"

        //示例 2：

        //输入：leaves = "ryr"

        //输出：0

        //解释：已符合要求，不需要额外操作

        //提示：

        //3 <= leaves.length <= 10^5
        //leaves 中只包含字符 'r' 和字符 'y'

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/UlBDOe

        public int MinimumOperations(string leaves)
        {
            int[][] dp = new int[leaves.Length][];
            var a = leaves.ToCharArray();
            dp[0] = new int[3];
            dp[0][0] = isYellow(a[0]);
            dp[0][1] = int.MaxValue;
            dp[0][2] = int.MaxValue;
            for (int i = 1; i < leaves.Length; i++)
            {
                dp[i] = new int[3];
                dp[i][0] = dp[i - 1][0] + isYellow(a[i]);
                dp[i][1] = Math.Min(dp[i - 1][0], dp[i - 1][1]) + isRed(a[i]);
                if (i > 1)
                {
                    dp[i][2] = Math.Min(dp[i - 1][1], dp[i - 1][2]) + isYellow(a[i]);
                }
                else
                {
                    dp[i][2] = int.MaxValue;//节点为2个时，不满足红黄红，故设置值为极大值
                }

            }
            return dp[leaves.Length - 1][2];
        }

        int isRed(char v)
        {
            return 'r' == v ? 1 : 0;
        }
        int isYellow(char v)
        {
            return 'y' == v ? 1 : 0;
        }
    }
}
