 //给你一个区间列表，请你删除列表中被其他区间所覆盖的区间。
//只有当 c <= a 且b <= d 时，我们才认为区间[a, b) 被区间[c, d) 覆盖。
//在完成所有删除操作后，请你返回列表中剩余区间的数目。



//示例：
//输入：intervals = [[1, 4],[3, 6],[2,8]]
//输出：2
//解释：区间[3, 6] 被区间[2, 8] 覆盖，所以它被删除了。


解法1（暴力搜索）：
思路：
1.循环数字每行，默认计数为0。
2.依次判断是否被包含。
3.没有被包含则计数加1，否则循环下一个。
4.返回计数

		public int RemoveCoveredIntervals(int[][] intervals)
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

解法2（线性扫描）：
思路：
1.对数组第一个数字进行排序，如果第一个数字相同，则根据第二个数字排序，默认计数为0
2.设置默认基点为{-1，-1}（题目给出数组数值范围大于0）
3.如果循环项的区间结尾小于基点的结尾.则说明循环项被覆盖了，循环下一个。
4.如果循环项的结尾大于基点的结尾，
	判断基点与循环项起点是否一致，如果一致则将循环项变成基点，但是不能新增计数，因为当前循环项包含了基点，但是基点以及增加计数了。
	否则则说明循环项没有被包围，将基点修改成当前循环项，计数加1.
5.返回计数即是剩余空间数
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