using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._31
{
    class _31Solution
    {
        // 实现获取下一个排列的函数，算法需要将给定数字序列重新排列成字典序中下一个更大的排列。

        //如果不存在下一个更大的排列，则将数字重新排列成最小的排列（即升序排列）。

        //必须原地修改，只允许使用额外常数空间。

        //以下是一些例子，输入位于左侧列，其相应输出位于右侧列。
        //1,2,3 → 1,3,2
        //3,2,1 → 1,2,3
        //1,1,5 → 1,5,1

        //1,3,2 → 2,1,3   1,3,2->

        public void NextPermutation(int[] nums)
        {
            int a = 0, b = nums.Length - 1;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] > nums[i - 1])
                {
                    a = i;
                    for (int j = nums.Length - 1; j > a; j--)
                    {
                        if (nums[a - 1] < nums[j])
                        {
                            int tem = nums[a - 1];
                            nums[a - 1] = nums[j];
                            nums[j] = tem;
                            break;
                        }
                    }
                    break;
                }
            }
            while (a < b)
            {
                int tem = nums[a];
                nums[a] = nums[b];
                nums[b] = tem;
                a++; b--;
            }
        }
    }
}
