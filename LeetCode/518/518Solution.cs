using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._518
{
    public class _518Solution
    {
        // 给定不同面额的硬币和一个总金额。写出函数来计算可以凑成总金额的硬币组合数。假设每一种面额的硬币有无限个。 



        //示例 1:

        //输入: amount = 5, coins = [1, 2, 5]
        //        输出: 4
        //解释: 有四种方式可以凑成总金额:
        //5=5
        //5=2+2+1
        //5=2+1+1+1
        //5=1+1+1+1+1
        //示例 2:

        //输入: amount = 3, coins = [2]
        //        输出: 0
        //解释: 只用面额2的硬币不能凑成总金额3。
        //示例 3:

        //输入: amount = 10, coins = [10]
        //        输出: 1
        //int count = 0;

        //注意:
        //你可以假设：
        //0 <= amount(总金额) <= 5000
        //1 <= coin(硬币面额)<= 5000
        //硬币种类不超过 500 种
        //结果符合 32 位符号整数
        public int Change(int amount, int[] coins)
        {
            var count = BackTracking2(coins, amount, 0, 0);
            return count;
        }

        int BackTracking2(int[] coins, int amount, int start, int sum)
        {
            if (sum == amount)
            {
                return 1;
            }
            if (sum > amount)
            {
                return 0;
            }
            int count = 0;
            for (int i = start; i < coins.Length; i++)
            {
                count += BackTracking2(coins, amount, i, sum + coins[i]);
            }
            return count;
        }

        //暴力回溯（超时）
        int count1 = 0;
        public int Change1(int amount, int[] coins)
        {
            Array.Sort(coins);
            BackTracking1(coins, amount, 0);
            return count1;
        }

        void BackTracking1(int[] coins, int amount, int start)
        {
            if (amount == 0)
            {
                count1++;
            }
            if (amount < 0)
            {
                return;
            }
            for (int i = start; i < coins.Length; i++)
            {
                if (amount < coins[i])
                {
                    break;
                }
                BackTracking1(coins, amount - coins[i], i);
            }
        }

        public int Change2(int amount, int[] coins)
        {
            Array.Sort(coins);
            int[] dp = new int[amount + 1];
            dp[0] = 1;
            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = coins[i]; j <= amount; j++)
                {
                    dp[j] += dp[j - coins[i]];
                }
            }
            return dp[amount];
        }
    }
}
