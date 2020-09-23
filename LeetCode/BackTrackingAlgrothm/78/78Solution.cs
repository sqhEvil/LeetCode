using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.BackTrackingAlgrothm._78
{
    public class _78Solution
    {
        //给定一组不含重复元素的整数数组 nums，返回该数组所有可能的子集（幂集）。

        //说明：解集不能包含重复的子集。

        //示例:

        //输入: nums = [1,2,3]
        //        输出:
        //[
        //  [3],
        //  [1],
        //  [2],
        //  [1,2,3],
        //  [1,3],
        //  [2,3],
        //  [1,2],
        //  []
        //]

        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> tem = new List<int>();
            BackTracking(result, tem, nums, 0);
            return result;
        }
        void BackTracking(IList<IList<int>> result, IList<int> tem, int[] nums, int index)
        {
            result.Add(new List<int>(tem));
            for (int i = index; i < nums.Length; i++)
            {
                tem.Add(nums[i]);
                BackTracking(result, tem, nums, index + 1);
                tem.RemoveAt(tem.Count - 1);
            }
        }
    }
}
