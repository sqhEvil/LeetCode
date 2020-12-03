using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortAlgrothm
{
    class kuaisuSort
    {
        /// <summary>
        /// 选择序列第一个元素作为基点，将序列中比基点大和小的元素分别放到序列左右，然后在对左右序列递归选择排序
        /// 先从右边找比基点小的，放到第一个元素的位置。
        /// 然后再从左边找比基点大的，放到右边空出的位置。
        /// 直到两个点交叉
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] Sort(int[] nums)
        {

            kuaisu(nums, 0, nums.Length - 1);
            return nums;
        }
        int i = 1;

        //伪代码



        void kuaisu(int[] nums, int s, int e)
        {
            if (s >= e)
            {
                return;
            }
            int tem = nums[s];
            int index = s, l = s, r = e;
            while (l < r)
            {
                while (l < r && nums[r] >= tem)
                {
                    r--;
                }
                if (l < r)
                {
                    nums[index] = nums[r];
                    index = r;
                }


                while (l < r && nums[l] <= tem)
                {
                    l++;
                }
                if (l < r)
                {
                    nums[index] = nums[l];
                    index = l;
                }
            }
            nums[index] = tem;
            Console.WriteLine($"第{i++}轮，中位{index}，{string.Join(',', nums)}");

            kuaisu(nums, s, index - 1);
            kuaisu(nums, index + 1, e);
        }
    }
}
