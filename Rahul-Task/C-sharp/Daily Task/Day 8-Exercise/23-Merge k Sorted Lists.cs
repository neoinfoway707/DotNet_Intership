using System;
using System.Linq;
using System.Security.Cryptography;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _23_Merge_k_Sorted_Lists
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

            public static ListNode[] CreateList(int[][] list)
            {
                ListNode[] result = new ListNode[list.Length];
                for (int i = 0; i < list.Length; i++)
                {
                    ListNode dummy = new ListNode(0);
                    ListNode head = dummy;
                    foreach (int j in list[i])
                    {
                        head.next = new ListNode(j);
                        head = head.next;
                    }
                    result[i] = dummy.next;
                }

                return result;
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
                int[][] arr = { new int[] { 1, 2, 3 }, new int[] { 1, 4, 5 }, new int[] { 2, 5, 8 } };
                ListNode[] list = CreateList(arr);

                var result = MergeKLists(list);
                PrintList(result);
            }
            public static ListNode MergeKLists(ListNode[] lists)
            {
                if (lists == null || lists.Length == 0) return null;
                int interval = 1;
                while (interval < lists.Length)
                {
                    for (int i = 0; i + interval < lists.Length; i += interval * 2)
                    {
                        lists[i] = MergeTwoList(lists[i], lists[i + interval]);
                    }
                    interval *= 2;
                }

                return lists[0];
            }
            public static ListNode MergeTwoList(ListNode list1, ListNode list2)
            {
                if (list1 == null) return list2;
                if (list2 == null) return list1;

                if (list1.val < list2.val)
                {
                    list1.next = MergeTwoList(list1.next, list2);
                    return list1;
                }
                else
                {
                    list2.next = MergeTwoList(list1, list2.next);
                    return list2;
                }
            }

           /* public static ListNode MergeTwoList(ListNode list1, ListNode list2)
            {
                ListNode result = new ListNode();
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
            }*/
        }
    }
}