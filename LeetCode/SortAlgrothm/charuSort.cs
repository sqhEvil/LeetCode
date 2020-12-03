using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortAlgrothm
{
    class charuSort
    {
        /// <summary>
        /// 前面序列有序，后面元素逐个插入有序序列
        /// </summary>
        /// <param name="nums"></param>
        public int[] Sort(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    int tem = nums[i];
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (nums[j] > tem)
                        {
                            nums[j + 1] = nums[j];
                        }
                        else
                        {
                            nums[j + 1] = tem;
                            break;
                        }
                    }
                }
                Console.WriteLine($"第{i}轮：{string.Join(',', nums)}");
            }
            return nums;
        }
    }
}
