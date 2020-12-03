using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortAlgrothm
{
    class xuanzeSort
    {
        public void Sort(int[] nums)
        {
            for (int j = 0; j < nums.Length - 1; j++)
            {
                int min = j;
                for (int i = j + 1; i < nums.Length; i++)
                {
                    if (nums[i] < nums[min])
                    {
                        min = i;
                    }
                }
                SwapNum(nums, min, j);
                Console.WriteLine($"第{j + 1}轮，最小项{min}：{string.Join(',', nums)}");
            }

        }
        void SwapNum(int[] nums, int i, int j)
        {
            int tem = nums[i];
            nums[i] = nums[j];
            nums[j] = tem;
        }
    }
}
