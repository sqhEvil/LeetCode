using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1423
{
    class _1423Solution
    {
        //几张卡牌 排成一行，每张卡牌都有一个对应的点数。点数由整数数组 cardPoints 给出。

        //每次行动，你可以从行的开头或者末尾拿一张卡牌，最终你必须正好拿 k 张卡牌。

        //你的点数就是你拿到手中的所有卡牌的点数之和。

        //给你一个整数数组 cardPoints 和整数 k，请你返回可以获得的最大点数。

        /// 1 <= cardPoints.length <= 10^5
        ///1 <= cardPoints[i] <= 10^4
        //1 <= k <= cardPoints.length
        /// <summary>
        /// 初始想法改进，初始想法内存消耗大，直接滑动窗口减少内存
        /// </summary>
        /// <param name="cardPoints"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxScore(int[] cardPoints, int k)
        {
            int temSum = 0;
            for (int i = 0; i < k; i++)
            {
                temSum += cardPoints[i];
            }
            var result = temSum;
            for (int i = 1; i <= k; i++)
            {
                temSum -= cardPoints[k - i];
                temSum += cardPoints[cardPoints.Length - i];
                result = Math.Max(result, temSum);
            }
            return result;
        }
        /// <summary>
        /// 初始想法，记录2边的和
        /// </summary>
        /// <param name="cardPoints"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxScore1(int[] cardPoints, int k)
        {
            int result = 0;
            int[] leftCount = new int[k + 1];
            int[] rightCount = new int[k + 1];
            for (int i = 0; i < k; i++)
            {
                leftCount[i + 1] = cardPoints[i] + leftCount[i];
                rightCount[i + 1] = cardPoints[cardPoints.Length - 1 - i] + rightCount[i];
            }
            for (int i = 0; i <= k; i++)
            {
                result = Math.Max(result, leftCount[i] + rightCount[k - i]);
            }
            return result;
        }

        //3,4,2,3
        //1,2,3,1,2,3
        //1,2,3,1,4,5
        public bool CheckPossibility(int[] nums)
        {

            bool IsChange = false;
            for (int i = 1; i < nums.Length; i++)
            {
                if (IsChange && nums[i] < nums[i - 1])
                {
                    return false;
                }
                if (nums[i] < nums[i - 1])
                {
                    IsChange = true;
                    if (i > 1 && nums[i] < nums[i - 2])
                    {
                        nums[i] = nums[i - 1];
                    }
                }
            }
            return true;
        }
    }
}
