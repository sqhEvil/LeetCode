using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortAlgrothm
{
    public class SortTest
    {
        int[] nums = { 2, 4, 8, 6, 5, 9, 3 };
        int[] nums1 = { 2, 4, 8, 6, 5, 9, 3 };
        int[] nums2 = { 2, 4, 8, 6, 5, 9, 3 };
        int[] nums3 = { 2, 4, 8, 6, 5, 9, 3 };
        int[] nums4 = { 2, 4, 8, 6, 5, 9, 3 };
        int[] nums5 = { 2, 4, 8, 6, 5, 9, 3 };
        int[] nums6 = { 2, 4, 8, 6, 5, 9, 3 };
        int[] nums7 = { 2, 4, 8, 6, 5, 9, 3 };
        int[] nums8 = { 2, 4, 8, 6, 5, 9, 3 };
        int[] nums9 = { 2, 4, 8, 6, 5, 9, 3 };
        public void Test()
        {
            Console.WriteLine("排序算法：");
            Console.WriteLine($"原始数据：{string.Join(',', nums)}");

            Console.WriteLine("冒泡排序");
            maopaoSort maopao = new maopaoSort();
            maopao.Sort(nums1);
            Console.WriteLine(string.Join(',', nums1));
            Console.WriteLine("---------------");

            Console.WriteLine("插入排序");
            charuSort charu = new charuSort();
            charu.Sort(nums2);
            Console.WriteLine(string.Join(',', nums2));
            Console.WriteLine("---------------");

            Console.WriteLine("快速排序");
            kuaisuSort kuaisu = new kuaisuSort();
            kuaisu.Sort(nums3);
            Console.WriteLine(string.Join(',', nums3));
            Console.WriteLine("---------------");


            Console.WriteLine("选择排序");
            xuanzeSort xuanze = new xuanzeSort();
            xuanze.Sort(nums4);
            Console.WriteLine(string.Join(',', nums4));
            Console.WriteLine("---------------");

            Console.WriteLine("排序算法结束！按回车键结束");
            Console.ReadKey();
        }
    }
}
