using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortAlgrothm
{
    class maopaoSort
    {
        /// <summary>
        /// 将最大的元素逐个移动到最后面
        /// </summary>
        /// <param name="nums"></param>
        public int[] Sort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                bool swap = false;
                for (int j = 0; j < nums.Length - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        swap = true;
                        SwapNum(nums, j, j + 1);
                    }
                }
                Console.WriteLine($"第{i + 1}轮：{string.Join(',', nums)}");
                if (!swap)
                {
                    break;
                }
            }
            return nums;
        }
        void SwapNum(int[] nums, int i, int j)
        {
            int tem = nums[i];
            nums[i] = nums[j];
            nums[j] = tem;
        }
    }
}
