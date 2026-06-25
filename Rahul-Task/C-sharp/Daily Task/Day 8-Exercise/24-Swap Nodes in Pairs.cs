using System;
using System.Data;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _24_Swap_Nodes_in_Pairs
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
            public static ListNode CreateList(int[] list)
            {
                ListNode dummy = new ListNode(0);
                ListNode head = dummy;
                foreach (int i in list)
                {
                    head.next = new ListNode(i);
                    head = head.next;
                }
                return dummy.next;
            }
            public static void PrintList(ListNode head)
            {
                ListNode current = head;
                while (current != null)
                {
                    Console.Write(current.val);
                    if (current.next != null)
                    {
                        Console.Write(" -> ");
                    }
                    current = current.next;
                }

                Console.WriteLine();
            }
            public static void Main(string[] args)
            {
                ListNode head = CreateList(new int[] { 1, 2, 3, 4, 5 });
                var result = SwapPairs(head);
                PrintList(result);
            }
            public static ListNode SwapPairs(ListNode head)
            {
                if (head == null || head.next == null)
                    return head;

                ListNode first = head;
                ListNode second = head.next;

                first.next = SwapPairs(second.next);
                second.next = first;

                return second;
            }
        }
    }
}


/*
  int[] list = { 1, 2, 3, 4, 5, 6, 7, 8 };
                int first = 0;
                int last = list.Length - 1;
                for (int i = 0; i < list.Length - 1; i++)
                {
                    if (first != list.Length - 1)
                    {
                        int temp = list[i + 1];
                        list[i + 1] = list[first];
                        list[first] = temp;
                    }
                    if (list[last] != list[i] && list[i] != list[last - 1])
                    {
                        int temp = list[last - 1];
                        list[last - 1] = list[last];
                        list[last] = temp;
                    }
                    first = i + 1;
                }
                foreach (int i in list)
                {
                    Console.Write(i);
                }
*/