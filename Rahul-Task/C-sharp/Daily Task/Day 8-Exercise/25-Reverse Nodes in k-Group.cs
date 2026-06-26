using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _25_Reverse_Nodes_in_k_Group
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
                ListNode head = CreateList(new int[] { 1, 2, 3, 4, 5, 6 });
                var result = ReverseKGroup(head, 3);
                PrintList(result);
            }

            //Using recursive
            public static ListNode ReverseKGroup(ListNode head, int k)
            {
                if (head == null || head.next == null || k <= 1)
                    return head;
                ListNode result = head;
                int count = 0;
                while (result != null && count < k)
                {
                    result = result.next;
                    count++;
                }
                if (count < k)
                    return head;

                ListNode prev = null;
                ListNode curr = head;
                for (int i = 0; i < k; i++)
                {
                    ListNode next = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = next;
                }
                head.next = ReverseKGroup(curr, k);
                return prev;
            }

            //using iteration
            /*public static ListNode ReverseKGroup(ListNode head, int k)
            {
                if (head == null || k <= 1)
                    return head;
                ListNode dummy = new ListNode(0);
                dummy.next = head;
                ListNode groupPrev = dummy;
                while (true)
                {
                    ListNode kNode = GetKNode(groupPrev, k);
                    if (kNode == null)
                        break;
                    ListNode groupNext = kNode.next;
                    ListNode groupHead = groupPrev.next;

                    ListNode prev = null;
                    ListNode curr = groupHead;
                    for (int i = 0; i < k; i++)
                    {
                        ListNode next = curr.next;
                        curr.next = prev;
                        prev = curr;
                        curr = next;
                    }
                    groupHead.next = groupNext;
                    groupPrev.next = kNode;
                    groupPrev = groupHead;
                }
                return dummy.next;
            }
            public static ListNode GetKNode(ListNode head, int k)
            {
                int count = 0;
                ListNode findK = head;
                while (findK != null && count < k)
                {
                    findK = findK.next;
                    count++;
                }
                return findK;
            }*/
        }
    }
}