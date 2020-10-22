using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.XPath;

namespace LeetCode.Tree._968
{
    class _968Solution
    {
        //给定一个二叉树，我们在树的节点上安装摄像头。

        //节点上的每个摄影头都可以监视其父对象、自身及其直接子对象。

        //计算监控树的所有节点所需的最小摄像头数量。



        //示例 1：



        //输入：[0,0,null,0,0]
        //        输出：1
        //解释：如图所示，一台摄像头足以监控所有节点。
        //示例 2：



        //输入：[0,0,null,0,null,0,null,null,0]
        //        输出：2
        //解释：需要至少两个摄像头来监视树的所有节点。 上图显示了摄像头放置的有效位置之一。

        //提示：

        //给定树的节点数的范围是[1, 1000]。
        //每个节点的值都是 0。
        //链接：https://leetcode-cn.com/problems/binary-tree-cameras
        int result = 0;
        public int MinCameraCover(TreeNode root)
        {
            if (GetNodeStatus(root) == 0)
            {
                result++;
            }
            return result;
        }
        //0没有覆盖，1有摄像头，2无摄像头但是有覆盖。
        int GetNodeStatus(TreeNode node)
        {
            if (node == null)
            {
                return 2;
            }
            int left = GetNodeStatus(node.left);
            int right = GetNodeStatus(node.right);
            if (left == 2 && right == 2) return 0;//左右节点都有覆盖，则当前节点由父节点覆盖为最优解
            if (left == 0 || right == 0)//左右子节点有1个没有覆盖，当前节点都需要摄像头
            {
                result++;
                return 1;
            }
            if (left == 1 || right == 1)
            {
                return 2;
            }
            return -1;

        }

        /// <summary>
        /// 获取节点的状态
        /// </summary>
        /// <param name="node"></param>
        /// <returns>数组索引0表示：当前节点有摄像头的最优解；索引1表示不论当前节点是否有摄像头的最优解；索引2表示不论当前节点是否有被监控的最优解。</returns>
        int[] GetCameraCOnverStatus(TreeNode node)
        {
            if (node == null)
            {
                int[] r = { int.MaxValue / 2, 0, 0 };
                return r;
            }
            int[] left = GetCameraCOnverStatus(node.left);
            int[] right = GetCameraCOnverStatus(node.right);
            int a = left[2] + right[2] + 1;//两个子树单独被覆盖，然后当前节点再放置一个摄像头
            //当前节点对应树的最优解在一下三种情况中取最优：
            //当前节点有摄像头后的最优解；
            //当前节点没有摄像头，左节点有摄像头，右节点最优；
            //当前节点没有摄像头，右节点有摄像头，左节点最优。
            int b = Math.Min(a, Math.Min(left[0] + right[1], left[1] + right[0]));
            //无论当前节点是否被覆盖，只覆盖两个子节点的最优解在以下两种情况中取最优：
            //1.当前节点有摄像头之后的最优解（两个子节点分开考虑之后，两子个节点都放置了摄像头，可以合并到当前节点。）
            //      0
            //    /   \
            //   0     0
            //2.分别覆盖左节点和右节点最优解之和
            int c = Math.Min(a, left[1] + right[1]);
            int[] result = { a, b, c };
            return result;
        }
        int min = int.MaxValue;
        int tem = -1;
        public int GetMinimumDifference(TreeNode root)
        {
            Mid(root);
            return min;
        }
        public void Mid(TreeNode node)
        {

            if (node.left != null)
            {
                Mid(node.left);
            }

            if (tem >= 0)
            {
                min = min < (node.val - tem) ? node.val - tem : min;
            }
            tem = node.val;
            if (node.right != null)
            {
                Mid(node.right);
            }

        }




        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode SwapPairs(ListNode head)
        {
            System.Collections.Concurrent.ConcurrentDictionary<int, int> cd;
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode front = head;

            head = head.next;
            front.next = head.next;
            head.next = front;
            while (front.next != null)
            {
                if (front.next.next != null)
                {
                    var tem = front.next;

                    front.next = front.next.next;
                    tem.next = front.next.next;
                    front.next.next = tem;

                    front = tem;
                }
                else
                {
                    break;
                }
            }
            var aa = head;
            while (aa != null)
            {
                Console.WriteLine(aa.val);
                aa = aa.next;
            }
            return head;
        }

        public IList<string> CommonChars(string[] A)
        {
            IList<string> result = new List<string>();
            var resultChar = A[0].ToList();
            int[] dc = new int[26];
            for (int i = 0; i < resultChar.Count; i++)
            {
                dc[resultChar[i] - 'a']++;
            }
            for (int i = 1; i < A.Length; i++)
            {
                int[] tem = new int[26];
                var l = A[i].ToList();
                for (int j = 0; j < l.Count; j++)
                {
                    tem[l[j] - 'a']++;
                }
                for (int k = 0; k < 26; k++)
                {
                    dc[k] = Math.Min(dc[k], tem[k]);
                }
            }
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < dc[i]; j++)
                {
                    result.Add(('a' + i).ToString());
                }
            }
            return result;
        }

        public bool BackspaceCompare(string S, string T)
        {
            var si = GetIndex(S, S.Length - 1);
            var ti = GetIndex(T, T.Length - 1);
            while (si >= 0 || ti >= 0)
            {
                if (GetValue(S, si) != GetValue(T, ti))
                {
                    return false;
                }
                si = GetIndex(S, si - 1);
                ti = GetIndex(T, ti - 1);
            }
            return true;
        }
        char GetValue(string ca, int index)
        {
            if (index < 0)
            {
                return '#';
            }
            return ca[index];
        }
        int GetIndex(string cs, int index)
        {
            if (index < 0) return -1;
            int c = 0;
            while (c > 0 || cs[index] == '#')
            {
                if (cs[index] == '#')
                {
                    c++;
                }
                else
                {
                    c--;
                }
                index--;
                if (index < 0)
                {
                    return -1;
                }
            }
            return index;
        }

        public void ReorderList(ListNode head)
        {
            Stack<ListNode> s = new Stack<ListNode>();
            var tem = head;
            while (tem != null)
            {
                s.Push(tem);
                tem = tem.next;
            }
            tem = head;
            while (tem != null)
            {

                if (tem == s.Peek())
                {
                    tem.next = null;
                    break;
                }
                else if (tem.next == s.Peek())
                {
                    tem.next.next = null;
                    break;
                }
                s.Peek().next = tem.next;
                tem.next = s.Pop();
                tem = tem.next.next;
            }
        }
    }
}
