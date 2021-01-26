using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.monimianshi1
{
    class mn1Solution
    {

        /*从开始循环到最后
         * 往右 一直循环到往左的，
         * 往左的就判断值大小，直到判断的比当前绝对值值小的
         * 
         * 给定一个整数数组 asteroids，表示在同一行的行星。
         * 对于数组中的每一个元素，其绝对值表示行星的大小，正负表示行星的移动方向（正表示向右移动，负表示向左移动）。每一颗行星以相同的速度移动。
         * 找出碰撞后剩下的所有行星。碰撞规则：两个行星相互碰撞，较小的行星会爆炸。如果两颗行星大小相同，则两颗行星都会爆炸。两颗移动方向相同的行星，永远不会发生碰撞。
         */
        public int[] AsteroidCollision(int[] asteroids)
        {
            List<int> result = new List<int>();
            Stack<int> right = new Stack<int>();
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] < 0)
                {
                    if (right.Count == 0)
                    {
                        result.Add(asteroids[i]);
                        continue;
                    }
                    var tem = right.Peek();
                    while (tem + asteroids[i] <= 0)
                    {
                        right.Pop();
                        if (tem + asteroids[i] == 0)
                        {
                            break;
                        }
                        if (right.Count > 0)
                        {
                            tem = right.Peek();
                        }
                        else
                        {
                            result.Add(asteroids[i]);
                        }
                    }
                }
                else
                {
                    right.Push(asteroids[i]);
                }
            }
            var rightTem = new List<int>();
            while (right.Count > 0)
            {
                rightTem.Add(right.Pop());
            }
            rightTem.Reverse();
            result.AddRange(rightTem);
            return result.ToArray();
        }
    }
}
