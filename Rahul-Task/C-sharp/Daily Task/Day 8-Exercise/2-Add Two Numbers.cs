using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    internal class _2_Add_Two_Numbers
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

        public class Solution
        {
            public static ListNode AddLast(ListNode node, int next)
            {
                ListNode l1 = new ListNode(next);
                if (node == null)
                    return l1;
                ListNode current = node;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = l1;
                return node;
            }
            public static void displ(ListNode node)
            {
                ListNode current = node;
                while (current != null)
                {
                    Console.Write(current.val);
                    current = current.next;
                }
                Console.WriteLine();
            }
            static void Main(string[] args)
            {
                ListNode l1 = new ListNode(2);
                l1.next = new ListNode(4);
                l1 = AddLast(l1, 3);

                ListNode l2 = new ListNode(5);
                l2.next = new ListNode(6);
                l2 = AddLast(l2, 4);

                ListNode list1 = l1;
                ListNode list2 = l2;
                ListNode res = AddTwoNumbers(l1, l2);

                Console.Write($"   List1  :  "); displ(l1);
                Console.Write(" + List2  :  "); displ(l2);
                Console.WriteLine("----------------");
                Console.Write("   Result :  "); displ(res);
            }
            public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                ListNode res = new ListNode(0);
                ListNode current = res;
                if (l1 == null || l2 == null)
                    return new ListNode();
                int reminder = 0;

                while (l1 != null || l2 != null)
                {
                    int sum = reminder;
                    if (l1 != null) { sum += l1.val; l1 = l1.next; }
                    if (l2 != null) { sum += l2.val; l2 = l2.next; }

                    reminder = sum / 10;
                    sum = sum % 10;

                    current.next = new ListNode(sum);
                    current = current.next;
                }
                if (reminder != 0)
                    current.next = new ListNode(reminder);
                return res.next;
            }
        }
    }
}
