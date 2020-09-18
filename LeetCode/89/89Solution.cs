using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LeetCode._89
{
    class _89Solution
    {
        //格雷编码是一个二进制数字系统，在该系统中，两个连续的数值仅有一个位数的差异。

        //给定一个代表编码总位数的非负整数 n，打印其格雷编码序列。即使有多个不同答案，你也只需要返回其中一种。

        //格雷编码序列必须以 0 开头。



        //示例 1:

        //输入: 2
        //输出: [0,1,3,2]
        //        解释:
        //00 - 0
        //01 - 1
        //11 - 3
        //10 - 2

        //对于给定的 n，其格雷编码序列并不唯一。
        //例如，[0,2,3,1] 也是一个有效的格雷编码序列。

        //00 - 0
        //10 - 2
        //11 - 3
        //01 - 1
        //示例 2:

        //输入: 0
        //输出: [0]
        //        解释: 我们定义格雷编码序列必须以 0 开头。
        //     给定编码总位数为 n 的格雷编码序列，其长度为 2^n。当 n = 0 时，长度为 2^0 = 1。
        //     因此，当 n = 0 时，其格雷编码序列为[0]。
        public IList<int> GrayCode(int n)
        {
            var result = new List<int>();
            result.Add(0);
            for (int i = 0; i < n; i++)
            {
                var tem = new List<int>(result);
                tem.Reverse();
                for (int j = 0; j < tem.Count; j++)
                {
                    tem[j] = tem[j] + (int)Math.Pow(2, j);
                }
                result.AddRange(tem);

            }
            return result;
        }


        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dc = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var s = target = nums[i];
                if (dc.ContainsKey(s))
                {
                    int[] tem = { dc[s], i };
                    return tem;
                }
                if (!dc.ContainsKey(nums[i]))
                {
                    dc.Add(nums[i], i);
                }
            }
            return new int[1];
        }

    }
}
