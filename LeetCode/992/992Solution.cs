using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._992
{
    class _992Solution
    {
        // 给定一个正整数数组 A，如果 A 的某个子数组中不同整数的个数恰好为 K，则称 A 的这个连续、不一定独立的子数组为好子数组。

        //（例如，[1,2,3,1,2] 中有 3 个不同的整数：1，2，以及 3。）

        //返回 A 中好子数组的数目。

        //示例 1：

        //输入：A = [1,2,1,2,3], K = 2
        //输出：7
        //解释：恰好由 2 个不同整数组成的子数组：[1,2], [2,1], [1,2], [2,3], [1,2,1], [2,1,2], [1,2,1,2].
        //示例 2：

        //输入：A = [1,2,1,3,4], K = 3
        //输出：3
        //解释：恰好由 3 个不同整数组成的子数组：[1,2,1,3], [2,1,3], [1,3,4].


        //提示：

        //1 <= A.length <= 20000
        //1 <= A[i] <= A.length
        //1 <= K <= A.length
        public int SubarraysWithKDistinct3(int[] A, int K)
        {
            int validCount = 0;
            IDictionary<int, int> stats = new Dictionary<int, int>();
            int left = 0, right = 0;
            while (right < A.Length)
            {
                int count = 0;
                stats.TryGetValue(A[right], out count);
                count++;
                stats[A[right]] = count;

                #region 收缩滑动窗口
                while (stats.Count() > K)
                {
                    if (stats[A[left]] > 1)
                    {
                        stats[A[left]]--;
                    }
                    else
                    {
                        stats.Remove(A[left]);
                    }
                    left++;
                }
                #endregion

                //判断以A[right]结尾的满足要求的子数组
                int temp_left = left;
                while (stats.Count() == K)
                {
                    validCount++;
                    if (stats[A[temp_left]] > 1)
                    {
                        stats[A[temp_left]]--;
                    }
                    else
                    {
                        stats.Remove(A[temp_left]);
                    }
                    temp_left++;
                }

                while (temp_left > left)
                {
                    if (stats.ContainsKey(A[temp_left - 1]))
                    {
                        stats[A[temp_left - 1]]++;
                    }
                    else
                    {

                        stats[A[temp_left - 1]] = 1;
                    }
                    temp_left--;
                }


                right++;
            }


            return validCount;
        }
        public int SubarraysWithKDistinct(int[] A, int K)
        {
            int CaculateMaxKCount(int k)
            {
                int count = 0;
                Dictionary<int, int> dt = new Dictionary<int, int>();
                int left = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    if (!dt.ContainsKey(A[i]))
                    {
                        dt.Add(A[i], 0);
                    }
                    dt[A[i]]++;
                    while (dt.Keys.Count > k)
                    {
                        dt[A[left]]--;
                        if (dt[A[left]] == 0)
                        {
                            dt.Remove(A[left]);
                        }
                        left++;
                    }
                    count += i - left;
                }
                return count;
            }
            return CaculateMaxKCount(K) - CaculateMaxKCount(K - 1);
        }


        public int SubarraysWithKDistinct2(int[] A, int K)
        {
            var result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                HashSet<int> hs = new HashSet<int>();
                for (int j = i; j < A.Length; j++)
                {
                    if (!hs.Contains(A[i]))
                    {
                        hs.Add(A[i]);
                    }
                    if (hs.Count == K)
                    {
                        result++;
                    }
                    if (hs.Count > K)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        public int SubarraysWithKDistinct1(int[] A, int K)
        {
            var result = 0;
            for (int i = K; i < A.Length; i++)
            {
                int left = 0;
                Dictionary<int, int> dc = new Dictionary<int, int>();
                for (int j = 0; j < A.Length; j++)
                {
                    if (dc.ContainsKey(A[j]))
                    {
                        dc[A[j]]++;
                    }
                    else
                    {
                        dc.Add(A[j], 1);
                    }

                    if (j - left + 1 < i)
                    {
                        continue;
                    }

                    if (dc.Keys.Count == K)
                    {
                        result++;
                    }
                    dc[A[left]]--;
                    if (dc[A[left]] == 0)
                    {
                        dc.Remove(A[left]);
                    }
                    left++;
                }
            }
            return result;
        }
    }
}
