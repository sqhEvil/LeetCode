using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Tree._145
{
    class _145Solution
    {
        public IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();
            if (root == null) return result;
            Stack<TreeNode> s = new Stack<TreeNode>();
            s.Push(root);
            TreeNode popRight = null;
            while (s.Count > 0)
            {
                while (s.Peek().left != null)
                {
                    s.Push(s.Peek().left);
                }
                while (s.Count > 0)
                {
                    if (s.Peek().right == null || s.Peek().right == popRight)
                    {
                        popRight = s.Pop();
                        result.Add(popRight.val);
                    }
                    else
                    {
                        s.Push(s.Peek().right);
                        break;
                    }
                }
            }
            return result;
        }
    }
}
