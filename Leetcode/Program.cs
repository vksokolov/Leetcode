using System;

namespace Leetcode
{
    class Program
    {
        public static void Main()
        {
            var s = new Solution();
            Print(s.GetResult());
        }

        private static void Print(string msg) =>
            Console.WriteLine(msg);
    }

    internal partial class Solution
    {
        public string GetResult()
        {
            var result = MergeTwoLists()
            return .ToString();
        }
    }

    internal partial class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;
         
            ListNode result = list1;
            if (list1.val > list2.val)
            {
                list1 = list2;
                list2 = result;
                result = list1;
            }
            ListNode cur = list1;
            ListNode tmp;
            
            while (list2 != null)
            {
                if (cur.next == null || cur.next.val > list2.val)
                {
                    tmp = list2;
                    list2 = list2.next;

                    tmp.next = cur.next;
                    cur.next = tmp;
                    cur = tmp;
                }
                else
                {
                    cur = cur.next;
                }
            }

            return result;
        }
    }
    
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
}