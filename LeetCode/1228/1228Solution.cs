using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1228
{
    public class _1228Solution
    {
        //给你一个区间列表，请你删除列表中被其他区间所覆盖的区间。
        //只有当 c <= a 且b <= d 时，我们才认为区间[a, b) 被区间[c, d) 覆盖。
        //在完成所有删除操作后，请你返回列表中剩余区间的数目。



        //示例：
        //输入：intervals = [[1, 4],[3, 6],[2,8]]
        //输出：2
        //解释：区间[3, 6] 被区间[2, 8] 覆盖，所以它被删除了。
        public int[][] CreateData()
        {
            int[][] vs = new int[4][] {
                new int[2] { 1, 4 },
                new int[2] { 1, 2 },
                new int[2] { 3, 6 },
                new int[2] { 2, 8 }
            };
            return vs;
        }

        public int RemoveCoveredIntervals(int[][] intervals)
        {
            int count = 0;
            Array.Sort(intervals, (a, b) => a[0] > b[0] || (a[0] == b[0] && a[1] > b[1]) ? 1 : -1);
            int[] tem = { -1, -1 };
            for (int i = 0; i < intervals.Length; i++)
            {
                if (tem[1] < intervals[i][1])
                {
                    if (tem[0] != intervals[i][0])
                    {
                        count++;
                    }
                    tem[0] = intervals[i][0];
                    tem[1] = intervals[i][1];
                }
            }
            return count;
        }


        public int RemoveCoveredIntervalsForce(int[][] intervals)
        {
            int count = 0;
            for (int i = 0; i < intervals.Length; i++)
            {
                bool isContain = false;
                for (int j = 0; j < intervals.Length; j++)
                {
                    if (i != j && intervals[i][0] >= intervals[j][0] && intervals[i][1] <= intervals[j][1])
                    {
                        isContain = true;
                        break;
                    }
                }
                count += isContain ? 1 : 0;
            }
            return count;
        }
    }
}
