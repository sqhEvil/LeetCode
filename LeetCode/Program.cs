using LeetCode._1228;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //_1228Solution _1228 = new _1228Solution();
            //_1228.RemoveCoveredIntervals(_1228.CreateData());
            _40._40Solution solution = new _40._40Solution();
            int[] vs = { 10, 1, 2, 7, 6, 1, 5 };
            solution.CombinationSum2(vs, 8);
            //_47._47Solution solution = new _47._47Solution();
            //int[] vs = { 1, 2, 3, 4 };
            //solution.PermuteUnique(vs);
            Console.Read();
        }
        //给定一个非空整数数组，除了某个元素只出现一次以外，其余每个元素均出现两次。找出那个只出现了一次的元素。

        //说明：

        //你的算法应该具有线性时间复杂度。 你可以不使用额外空间来实现吗？

        //示例 1:

        //输入: [2,2,1]
        //        输出: 1
        //示例 2:

        //输入: [4,1,2,1,2]
        //        输出: 4

        //作者：力扣(LeetCode)
        //链接：https://leetcode-cn.com/leetbook/read/top-interview-questions/xm0u83/
        public int SingleNumber(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result = result ^ nums[i];
            }
            return result;
        }

        //        编写一个高效的算法来搜索 m x n 矩阵 matrix 中的一个目标值 target。该矩阵具有以下特性：

        //每行的元素从左到右升序排列。
        //每列的元素从上到下升序排列。
        //示例:

        //现有矩阵 matrix 如下：

        //[
        //  [1,   4,  7, 11, 15],
        //  [2,   5,  8, 12, 19],
        //  [3,   6,  9, 16, 22],
        //  [10, 13, 14, 17, 24],
        //  [18, 21, 23, 26, 30]
        //]
        //给定 target = 5，返回 true。

        //给定 target = 20，返回 false。

        //作者：力扣(LeetCode)
        //链接：https://leetcode-cn.com/leetbook/read/top-interview-questions/xmlwi1/
        public bool SearchMatrix(int[,] matrix, int target)
        {
            for (int i = 0, j = matrix.GetLength(1) - 1; j >= 0 && i < matrix.GetLength(0);)
            {
                if (matrix[i, j] == target)
                {
                    return true;
                }
                else if (matrix[i, j] > target)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }
            return false;
        }

        //鸡蛋掉落
        //你将获得 K 个鸡蛋，并可以使用一栋从 1 到 N 共有 N 层楼的建筑。

        //每个蛋的功能都是一样的，如果一个蛋碎了，你就不能再把它掉下去。

        //你知道存在楼层 F ，满足 0 <= F <= N 任何从高于 F 的楼层落下的鸡蛋都会碎，从 F 楼层或比它低的楼层落下的鸡蛋都不会破。

        //每次移动，你可以取一个鸡蛋（如果你有完整的鸡蛋）并把它从任一楼层 X 扔下（满足 1 <= X <= N）。

        //你的目标是确切地知道 F 的值是多少。

        //无论 F 的初始值如何，你确定 F 的值的最小移动次数是多少？



        //示例 1：

        //输入：K = 1, N = 2
        //输出：2
        //解释：
        //鸡蛋从 1 楼掉落。如果它碎了，我们肯定知道 F = 0 。
        //否则，鸡蛋从 2 楼掉落。如果它碎了，我们肯定知道 F = 1 。
        //如果它没碎，那么我们肯定知道 F = 2 。
        //因此，在最坏的情况下我们需要移动 2 次以确定 F 是多少。
        //示例 2：

        //输入：K = 2, N = 6
        //输出：3
        //示例 3：

        //输入：K = 3, N = 14
        //输出：4

        //作者：力扣(LeetCode)
        //链接：https://leetcode-cn.com/leetbook/read/top-interview-questions/xmup75/

        public int SuperEggDrop(int K, int N)
        {
            
            return 0;
        }


        //合并两个有序数组
        //给你两个有序整数数组 nums1 和 nums2，请你将 nums2 合并到 nums1 中，使 nums1 成为一个有序数组。



        //说明:

        //初始化 nums1 和 nums2 的元素数量分别为 m 和 n 。
        //你可以假设 nums1 有足够的空间（空间大小大于或等于 m + n）来保存 nums2 中的元素。


        //示例:

        //输入:
        //nums1 = [1,2,3,0,0,0], m = 3
        //nums2 = [2,5,6],       n = 3

        //输出: [1,2,2,3,5,6]

        //        作者：力扣(LeetCode)
        //链接：https://leetcode-cn.com/leetbook/read/top-interview-questions/xmi2l7/
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            while (m > 0 || n > 0)
            {
                if (m == 0)
                {
                    nums1[m + n - 1] = nums2[n - 1];
                }
                else if (n == 0)
                {
                    return;
                }
                else if (nums1[m - 1] > nums2[n - 1])
                {
                    nums1[m + n - 1] = nums1[m - 1];
                    m--;
                }
                else
                {
                    nums1[m + n - 1] = nums2[n - 1];
                    n--;
                }
            }
        }

        public int MajorityElement(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            Dictionary<int, int> dc = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dc.ContainsKey(nums[i]))
                {
                    dc[nums[i]]++;
                    if (dc[nums[i]] > nums.Length / 2)
                    {
                        return nums[i];
                    }
                }
                else
                {
                    dc.Add(nums[i], 1);
                }
            }
            return 0;
        }
    }
}
