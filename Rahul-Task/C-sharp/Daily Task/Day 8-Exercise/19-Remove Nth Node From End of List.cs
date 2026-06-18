using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _19_Remove_Nth_Node_From_End_of_List
    {
        public class Solution
        {
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
            static ListNode CreateList(int[] arr)
            {
                ListNode dummy = new ListNode(0);
                ListNode head = dummy;
                foreach (int i in arr)
                {
                    head.next = new ListNode(i);
                    head = head.next;
                }
                return dummy.next;
            }
            public static void Main(string[] args)
            {
                int[] arr = { 1, 2, 3, 4, 5 };
                ListNode head = CreateList(new int[] { 1, 2, 3, 4, 5 });

                var a = RemoveNthFromEnd(head, 2);
                while (a != null)
                {
                    Console.Write(a.val + " → ");
                    a = a.next;
                }
            }
            public static ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                ListNode dummy = new ListNode(0);
                dummy.next = head;

                ListNode slow = dummy;
                ListNode fast = dummy;
               
                for (int i = 0; i <= n; i++)
                    fast = fast.next;

                while (fast != null)
                {
                    fast = fast.next;
                    slow = slow.next;
                }
                slow.next = slow.next.next;
                return dummy.next;
            }
        }
    }
}
