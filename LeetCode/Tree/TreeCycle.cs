using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LeetCode.Tree
{
    public class TreeCycle
    {
        /// <summary>
        /// 前序遍历（Preorder Traversal (VLR)）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IList<int> VLR(TreeNode node)
        {
            IList<int> result = new List<int>();
            if (node == null) return result;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(node);
            while (stack.Count > 0)
            {
                var tem = stack.Pop();
                result.Add(tem.val);
                if (tem.right != null) stack.Push(tem.right);
                if (tem.left != null) stack.Push(tem.left);
            }

            return result;
        }

        public IList<int> VLRRecursion(TreeNode node)
        {
            IList<int> result = new List<int>();
            VLRRecursion(node, result);
            return result;
        }
        public void VLRRecursion(TreeNode node, IList<int> result)
        {
            if (node == null) return;
            result.Add(node.val);
            VLRRecursion(node, result);
            VLRRecursion(node, result);
        }
        /// <summary>
        /// 中序遍历（Inorder Traversal (LDR)）
        /// 1.先从根节点找到最左端得节点，当前节点由于没有左节点故可以直接输出
        /// 2.看该节点是否有右节点，有的话就回到1得逻辑，继续处理。
        /// 3.从栈中逐个取出节点进行1，2处理即可遍历完成。
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IList<int> LDR(TreeNode node)
        {
            IList<int> result = new List<int>();
            if (node == null) return result;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(node);
            while (stack.Count > 0)
            {
                while (stack.Peek().left != null)//找到最左端得节点
                {
                    stack.Push(stack.Peek().left);
                }
                while (stack.Count > 0)
                {
                    var tem = stack.Pop();//逐个出栈
                    result.Add(tem.val);//输出这个节点
                    if (tem.right != null)//节点右节点不为空，将右节点当作一颗新的树，重新查找最右端得节点
                    {
                        stack.Push(tem.right);
                        break;
                    }
                }
            }
            return result;
        }
        public IList<int> LDRRecursion(TreeNode node)
        {
            IList<int> result = new List<int>();
            //if (node == null) return result;
            LDRRecursion(node, result);
            return result;
        }
        public void LDRRecursion(TreeNode node, IList<int> result)
        {
            if (node == null) return;
            LDRRecursion(node.left, result);
            result.Add(node.val);
            LDRRecursion(node.right, result);
            //if (node.left == null)
            //{
            //    result.Add(node.val);
            //}
            //else
            //{
            //    LDRRecursion(node.left, result);
            //    result.Add(node.val);
            //}
            //if (node.right != null)
            //{
            //    LDRRecursion(node.right, result);
            //}
        }
        /// <summary>
        /// 后序遍历（Postorder Traversal (LRD)）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IList<int> LRD(TreeNode node)
        {
            IList<int> result = new List<int>();
            if (node == null) return result;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode tem = null;
            while (stack.Count > 0)
            {
                while (stack.Peek().left != null)//先找到最左端得接口
                {
                    stack.Push(stack.Peek().right);
                }
                while (stack.Count > 0)
                {
                    if (stack.Peek().right == null || stack.Peek().right == tem)//最左端得节点如果右节点为空，或者右节点上一个处理过了，就出栈当前节点
                    {
                        tem = stack.Pop();
                        result.Add(tem.val);
                    }
                    else if (stack.Peek().right != null)//右节点不为空，入栈右节点
                    {
                        stack.Push(stack.Peek().right);
                        break;
                    }
                }
            }
            return result;
        }
        public IList<int> LRDRecursion(TreeNode node)
        {
            IList<int> result = new List<int>();
            //if (node == null) return result;
            LRDRecursion(node, result);
            return result;
        }
        public void LRDRecursion(TreeNode node, IList<int> result)
        {
            if (node == null) return;
            LRDRecursion(node.left, result);
            LRDRecursion(node.right, result);
            result.Add(node.val);

            //if (node.left == null && node.right == null)
            //{
            //    result.Add(node.val);
            //}
            //if (node.left != null)
            //{
            //    LDRRecursion(node, result);
            //}
            //if (node.right != null)
            //{
            //    LRDRecursion(node, result);
            //}
            //result.Add(node.val);
        }
    }
}
