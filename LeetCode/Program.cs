using LeetCode._1228;
using System;

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
    }
}
