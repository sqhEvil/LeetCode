using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._219
{
    public class _219Solution
    {
        //给定一个整数数组和一个整数 k，判断数组中是否存在两个不同的索引 i和 j，使得 nums[i] = nums[j]，并且 i 和 j的差的 绝对值 至多为 k。

        //示例 1:

        //输入: nums = [1,2,3,1], k = 3
        //输出: true
        //示例 2:

        //输入: nums = [1,0,1,1], k = 1
        //输出: true
        //示例 3:

        //输入: nums = [1,2,3,1,2,3], k = 2
        //输出: false
        //线性搜索（超时）
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j <= i + k; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 哈希搜索
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsNearbyDuplicate1(int[] nums, int k)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    return true;
                }
                set.Add(nums[i]);
                if (set.Count > k)
                {
                    set.Remove(nums[i - k]);
                }
            }
            return false;
        }
    }
}
