using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._39
{
    public class _39Solution
    {
        //给定一个无重复元素的数组 candidates和一个目标数 target ，找出 candidates中所有可以使数字和为 target的组合。

        //candidates 中的数字可以无限制重复被选取。

        //说明：

        //所有数字（包括 target）都是正整数。
        //解集不能包含重复的组合。 
        //示例 1：

        //输入：candidates = [2,3,6,7], target = 7,
        //所求解集为：
        //[
        //  [7],
        //  [2,2,3]
        //]
        //示例 2：

        //输入：candidates = [2,3,5], target = 8,
        //所求解集为：
        //[
        //  [2,2,2,2],
        //  [2,3,3],
        //  [3,5]
        //]
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> tem = new List<int>();
            BackTracking(candidates, target, result, tem, 0, 0);
            return result;
        }

        void BackTracking(int[] candidates, int target, IList<IList<int>> result, IList<int> tem, int sum, int index)
        {
            if (sum > target || index >= candidates.Length)
            {
                return;
            }
            if (sum == target)
            {
                result.Add(new List<int>(tem));
                return;
            }
            for (int i = index; i < candidates.Length; i++)
            {

                tem.Add(candidates[i]);
                BackTracking(candidates, target, result, tem, sum + candidates[i], i);
                tem.RemoveAt(tem.Count - 1);
            }
        }
    }
}
