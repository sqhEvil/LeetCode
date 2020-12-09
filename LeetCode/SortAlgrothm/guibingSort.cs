using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortAlgrothm
{
    class guibingSort
    {
        public void Sort(int[] nums)
        {
            Recurvision(nums, 0, nums.Length - 1);
        }
        int l = 1;
        void Recurvision(int[] nums, int s, int e)
        {
            if (e - s < 1)
            {
                return;
            }
            Recurvision(nums, s, (e + s) / 2);
            Recurvision(nums, (e + s) / 2 + 1, e);
            Merge(nums, s, e);
            Console.WriteLine($"第{l++}轮，排序起始点{s}-{e}：{string.Join(',', nums)}");
        }

        void Merge(int[] nums, int s, int e)
        {
            int mid = (s + e) / 2;
            for (int j = mid + 1; j <= e; j++)//合并不开辟新空间,插入排序，亦可开辟新空间。
            {
                if (nums[j] > nums[j - 1])
                {
                    return;
                }
                int tem = nums[j];
                int i = j - 1;
                while (i >= s && nums[i] > tem)
                {
                    nums[i + 1] = nums[i];
                    i--;
                }
                nums[i + 1] = tem;
            }
        }
    }
}
