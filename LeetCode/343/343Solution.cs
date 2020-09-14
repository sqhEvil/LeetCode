using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._343
{
    public class _343Solution
    {
        //给定一个正整数 n，将其拆分为至少两个正整数的和，并使这些整数的乘积最大化。 返回你可以获得的最大乘积。

        //示例 1:

        //输入: 2
        //输出: 1
        //解释: 2 = 1 + 1, 1 × 1 = 1。
        //示例 2:

        //输入: 10
        //输出: 36
        //解释: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36。
        //说明: 你可以假设 n不小于 2 且不大于 58。

        //1=1  
        //2=1*1  
        //3=1*2   
        //4=2*2  
        //5=2*3  
        //6=2*4=2*2*2  
        //7=3*4=3*2*2
        public class Solution
        {
            public int IntegerBreak(int n)
            {
                List<int> vs = new List<int>();
                if (n == 2)
                {
                    return 1;
                }
                if (n == 3)
                {
                    return 2;
                }
                if (n == 4)
                {
                    return 4;
                }
                if (n == 5)
                {
                    return 6;
                }
                if (n == 6)
                {
                    return 9;
                }
                vs.Add(1);
                vs.Add(1);
                vs.Add(2);
                vs.Add(4);
                vs.Add(6);
                vs.Add(9);
                for (int i = 6; i < n; i++)
                {
                    var max = vs[i - 1];
                    max = Math.Max(max, vs[i - 2] * 2);
                    max = Math.Max(max, vs[i - 3] * 3);
                    max = Math.Max(max, vs[i - 4] * 4);
                    max = Math.Max(max, vs[i - 5] * 5);
                    max = Math.Max(max, vs[i - 6] * 6);
                    vs.Add(max);
                }

                return vs[n - 1];
            }
        }
    }
}
