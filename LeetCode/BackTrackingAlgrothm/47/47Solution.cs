using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._47
{
    public class _47Solution
    {
        //        给定一个可包含重复数字的序列，返回所有不重复的全排列。

        //示例:

        //输入: [1,1,2]
        //        输出:
        //[
        //  [1,1,2],
        //  [1,2,1],
        //  [2,1,1]
        //  ]
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Console.WriteLine($"原数组：{string.Join(',', nums)}");
            BackTracking(nums, result, 0);
            return result;
        }

        void BackTracking(int[] nums, IList<IList<int>> result, int first)
        {
            if (first == nums.Length)
            {
                result.Add(new List<int>(nums));
            }
            for (int i = first; i < nums.Length; i++)
            {
                bool isHas = false;
                for (int j = first; j < i; j++)
                {
                    if (i != j && nums[j] == nums[i])
                    {
                        isHas = true;
                        break;
                    }
                }
                if (isHas)
                {
                    continue;
                }
                int tem = nums[i];
                nums[i] = nums[first];
                nums[first] = tem;
                string tems = string.Empty;
                for (int k = 0; k <= first; k++)
                {
                    tems = $"{tems},{nums[k]}";
                }
                Console.WriteLine($"第{first}个字符，取第{i}个值，取值后数组{tems.Trim(',')}");
                BackTracking(nums, result, first + 1);
                nums[first] = nums[i];
                nums[i] = tem;
            }
        }
    }
}
