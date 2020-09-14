using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._40
{
    public class _40Solution
    {
//        给定一个数组 candidates和一个目标数 target ，找出 candidates中所有可以使数字和为 target的组合。

//candidates 中的每个数字在每个组合中只能使用一次。

//说明：

//所有数字（包括目标数）都是正整数。
//解集不能包含重复的组合。 
//示例 1:

//输入: candidates = [10,1,2,7,6,1,5], target = 8,
//所求解集为:
//[
//  [1, 7],
//  [1, 2, 5],
//  [2, 6],
//  [1, 1, 6]
//]
//示例 2:

//输入: candidates = [2,5,2,1,2], target = 5,
//所求解集为:
//[

// [1,2,2],
//  [5]
//]
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> tem = new List<int>();
            Array.Sort(candidates);
            BackTracking(candidates, target, result, tem, 0, 0);
            return result;
        }

        void BackTracking(int[] candidates, int target, IList<IList<int>> result, IList<int> temList, int sum, int resultIndex)
        {
            if (target == sum)
            {
                result.Add(new List<int>(temList));
                return;
            }
            for (int i = resultIndex; i < candidates.Length; i++)
            {
                if (sum - target > 0)
                {
                    break;
                }
                if (i > resultIndex && candidates[resultIndex] == candidates[i])
                {
                    continue;
                }
                var tem = candidates[i];
                temList.Add(tem);
                BackTracking(candidates, target, result, temList, sum + tem, resultIndex + 1);
                temList.RemoveAt(temList.Count - 1);
            }
        }
    }
}
