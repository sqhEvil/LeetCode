using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LeetCode._794
{
    class _794Solution
    {
        //用字符串数组作为井字游戏的游戏板 board。当且仅当在井字游戏过程中，玩家有可能将字符放置成游戏板所显示的状态时，才返回 true。

        //该游戏板是一个 3 x 3 数组，由字符 " "，"X" 和 "O" 组成。字符 " " 代表一个空位。

        //以下是井字游戏的规则：

        //玩家轮流将字符放入空位（" "）中。
        //第一个玩家总是放字符 “X”，且第二个玩家总是放字符 “O”。
        //“X” 和 “O” 只允许放置在空位中，不允许对已放有字符的位置进行填充。
        //当有 3 个相同（且非空）的字符填充任何行、列或对角线时，游戏结束。
        //当所有位置非空时，也算为游戏结束。
        //如果游戏结束，玩家不允许再放置字符。
        //示例 1:
        //输入: board = ["O  ", "   ", "   "]
        //        输出: false
        //解释: 第一个玩家总是放置“X”。

        //示例 2:
        //输入: board = ["XOX", " X ", "   "]
        //        输出: false
        //解释: 玩家应该是轮流放置的。

        //示例 3:
        //输入: board = ["XXX", "   ", "OOO"]
        //        输出: false

        //示例 4:
        //输入: board = ["XOX", "O O", "XOX"]
        //        输出: true
        //说明:

        //游戏板 board 是长度为 3 的字符串数组，其中每个字符串 board[i] 的长度为 3。
        // board[i][j] 是集合 {" ", "X", "O"}
        //        中的一个字符。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/valid-tic-tac-toe-state


        //不可能的情况
        //1.[O]数量>[X]数量
        //2.[X]的数量-[O]数量大于1个
        //3.XO同时胜利
        //4.X胜利时，X数量不等于O数量加1
        //5.O胜利时，XO数量不相等
        public bool ValidTicTacToe(string[] board)
        {
            int xC = 0;
            int oC = 0;
            int xend = 0;
            int oend = 0;
            bool[] win = new bool[5];//012:竖，34：×；
            for (int i = 0; i < 5; i++)
            {
                win[i] = true;
            }
            char[] tem = new char[6];//123：竖，45：×；
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == "XXX")
                {
                    xend++;
                }
                if (board[i] == "OOO")
                {
                    oend++;
                }
                var c = board[i].ToArray();
                if (tem[0] == tem[1]) { tem[1] = c[0]; }
                else
                {
                    if (tem[1] != c[0])
                    {
                        win[0] = false;
                    }
                }
                if (tem[0] == tem[2]) { tem[2] = c[1]; }
                else if (tem[2] != c[1])
                {
                    win[1] = false;
                }
                if (tem[0] == tem[3]) { tem[3] = c[2]; }
                else if (tem[3] != c[2])
                {
                    win[2] = false;
                }

                if (tem[0] == tem[4]) { tem[4] = c[i]; }
                else if (tem[4] != c[i])
                {
                    win[3] = false;
                }
                if (tem[0] == tem[5]) { tem[5] = c[2 - i]; }
                else if (tem[5] != c[2 - i])
                {
                    win[4] = false;
                }
                for (int j = 0; j < 3; j++)
                {
                    if (c[j] == 'O')
                    {
                        oC++;
                    }
                    if (c[j] == 'X')
                    {
                        xC++;
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (win[i])
                {
                    if (tem[i + 1] == 'X')
                    {
                        xend++;
                    }
                    if (tem[i + 1] == 'O')
                    {
                        oend++;
                    }
                }
            }
            Console.WriteLine(string.Join(',', win));
            Console.WriteLine($"xC:{xC};oC:{oC},xEnd:{xend},oend:{oend}");
            if (oC > xC || xC - oC > 1 || (xend > 0 && oend > 0))
            {
                return false;
            }
            if (oend > 0)
            {
                return oC == xC;
            }
            if (xend > 0)
            {
                return oC + 1 == xC;
            }
            return true;
        }
    }
}
