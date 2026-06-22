using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _21_Merge_Two_Sorted_Lists
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

            static ListNode CreateList(int[] list)
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
                ListNode list1 = CreateList(new int[] { 1, 5, 6 });
                ListNode list2 = CreateList(new int[] { 1, 2, 8 });

                ListNode result = MergeTwoLists(list1, list2);
                PrintList(result);
            }
            public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                ListNode result = new ListNode(0);
                ListNode demo = result;
                while (list1 != null && list2 != null)
                {
                    if (list1.val < list2.val)
                    {
                        demo.next = list1;
                        list1 = list1.next;
                        demo = demo.next;
                    }
                    else
                    {
                        demo.next = list2;
                        list2 = list2.next;
                        demo = demo.next;
                    }
                }
                if (list1 != null)
                {
                    demo.next = list1;
                    list1 = null;
                }
                if (list2 != null)
                {
                    demo.next = list2;
                    list2 = null;
                }
                return result.next;
            }
        }
    }
}