using System;
using System.Collections.Generic;
using System.Text;


namespace LeetCode.niuke
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }

    }
    class ReverseListSolution
    {
        public ListNode ReverseList(ListNode pHead)
        {
            // write code here
            if (pHead == null)
            {
                return pHead;
            }
            var index = pHead?.next;
            var result = pHead;
            while (index != null)
            {
                var tem = index.next;
                index.next = result;
                result = index;
                index = tem;
            }
            return result;
        }
    }
}