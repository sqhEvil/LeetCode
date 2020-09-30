using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml;

namespace LeetCode.Tree._117
{
    class _117Solution
    {
        //给定一个二叉树
        //struct Node
        //        {
        //            int val;
        //            Node* left;
        //            Node* right;
        //            Node* next;
        //        }
        //        填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。
        //初始状态下，所有 next 指针都被设置为 NULL。




        //进阶：

        //你只能使用常量级额外空间。
        //使用递归解题也符合要求，本题中递归程序占用的栈空间不算做额外的空间复杂度。


        //示例：



        //输入：root = [1,2,3,4,5,null,7]
        //        输出：[1,#,2,3,#,4,5,7,#]
        //解释：给定二叉树如图 A 所示，你的函数应该填充它的每个 next 指针，以指向其下一个右侧节点，如图 B 所示。


        //        来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node-ii

        public Node Connect(Node root)
        {
            Node left = null;//子节点最左端
            Node index = null;//子节点索引
            Node tem = root;//父节点循环
            while (tem != null)
            {
                if (tem.left != null)
                {
                    if (left == null)
                    {
                        left = tem.left;
                    }
                    if (index != null)
                    {
                        index.next = tem.left;
                        index = tem.left;
                    }
                    else
                    {
                        index = tem.left;
                    }
                }
                if (tem.right != null)
                {
                    if (left == null)
                    {
                        left = tem.right;
                    }
                    if (index != null)
                    {
                        index.next = tem.right;
                        index = tem.right;
                    }
                    else
                    {
                        index = tem.right;
                    }
                }
                tem = tem.next;
                if (tem == null)
                {
                    tem = left;
                    left = null;
                    index = null;
                }
            }
            return root;
        }
        public Node Connect1(Node root)
        {
            ConnectNode(root);
            return root;
        }

        public void ConnectNode(Node node)
        {
            Node left = null;
            Node index = null;
            Node tem = node;
            while (tem != null)
            {
                if (tem.left != null)
                {
                    if (left == null)
                    {
                        left = tem.left;
                    }
                    if (index != null)
                    {
                        index.next = tem.left;
                        index = tem.left;
                    }
                    else
                    {
                        index = tem.left;
                    }
                }
                if (tem.right != null)
                {
                    if (left == null)
                    {
                        left = tem.right;
                    }
                    if (index != null)
                    {
                        index.next = tem.right;
                        index = tem.right;
                    }
                    else
                    {
                        index = tem.right;
                    }
                }
                tem = tem.next;
            }
            if (left != null)
            {
                ConnectNode(left);
            }
        }



















































        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
    }
}
