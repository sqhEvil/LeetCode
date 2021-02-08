using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._978
{
    class _978Solution
    {
        //当 A 的子数组 A[i], A[i + 1], ..., A[j] 满足下列条件时，我们称其为湍流子数组：

        //若 i <= k<j，当 k 为奇数时， A[k]> A[k + 1]，且当 k 为偶数时，A[k] < A[k + 1]；
        //或 若 i <= k<j，当 k 为偶数时，A[k]> A[k + 1] ，且当 k 为奇数时， A[k] < A[k + 1]。
        //也就是说，如果比较符号在子数组中的每个相邻元素对之间翻转，则该子数组是湍流子数组。

        //返回 A 的最大湍流子数组的长度。
        /// [9,4,2,10,7,8,8,1,9]
        /// 5
        /// A[1] > A[2] < A[3] > A[4] < A[5]
        ///  1<= A.length <= 40000
        ///  [0,8,45,88,48,68,28,55,17,24]
        public int MaxTurbulenceSize(int[] arr)
        {
            int result = 1;
            int left = 0;
            int type = 3;//1大 2 小 3 同
            for (int i = 1; i < arr.Length; i++)
            {
                if ((type == 1 && arr[i] >= arr[i - 1]) ||
                    (type == 2 && arr[i] <= arr[i - 1]) ||
                    arr[i] == arr[i - 1])
                {
                    result = Math.Max(result, i - left);
                    left = arr[i] == arr[i - 1] ? i : i - 1;
                }
                type = arr[i] == arr[i - 1] ? 3 : arr[i] > arr[i - 1] ? 1 : 2;
            }
            result = Math.Max(result, arr.Length - left);
            return result;
        }
    }
}
