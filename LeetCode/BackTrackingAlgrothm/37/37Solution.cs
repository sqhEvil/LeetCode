
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace LeetCode.BackTrackingAlgrothm._37
{
    public class _37Solution
    {
        char[] charVs = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public void SolveSudoku(char[][] board)
        {
            bool[][] isNeed = new bool[9][];
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        isNeed[i][j] = true;
                    }
                }
            }
            BackTracking(board, 0, 0);
        }

        bool BackTracking(char[][] board, int x, int y)
        {
            if (x == 9)
            {
                return true;
            }
            int xi = x;
            int yi = y + 1;
            if (yi == 9)
            {
                yi = 0;
            }
            else
            {
                xi++;
            }
            if (board[x][y] != '.')
            {
                return BackTracking(board, xi, yi);//下一个点
            }
            else
            {
                bool isTrue = false;
                for (int i = 1; i < 10; i++)
                {
                    if (CheckChar(board, x, y, charVs[i - 1]))
                    {

                        board[x][y] = charVs[i - 1];//设置当前点
                        var result = BackTracking(board, xi, yi);//继续下一个点
                        if (!result)//如果下一个点不行，就还原当前点
                        {
                            board[x][y] = '.';
                        }
                        else
                        {
                            isTrue = true;//当前点行，并且后面所有点都行才设置为true
                        }
                    }

                }
                return isTrue;
            }


        }

        bool CheckChar(char[][] board, int x, int y, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[x][i] == c)
                {
                    return false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (board[i][y] == c)
                {
                    return false;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[(x / 3) * 3 + i][(y / 3) * 3 + j] == c)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
