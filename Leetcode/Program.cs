using System;
using System.Text;

namespace Leetcode
{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            var node = this;
            var sb = new StringBuilder();
            
            sb.Append('[');
            sb.Append(val);
            
            while (node.next != null)
            {
                node = node.next;
                sb.Append(',');
                sb.Append(' ');
                sb.Append(node.val);
            }

            sb.Append(']');

            return sb.ToString();
        }
    }
    
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
            var head = new ListNode(1, new ListNode(1, new ListNode(1)));
            return DeleteDuplicates(head).ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;
            
            ListNode node = head;
            while (node.next != null)
            {
                if (node.val == node.next.val)
                {
                    node.val = node.next.val;
                    node.next = node.next.next;
                }
                else 
                    node = node.next;

                if (node.next == null) break;
                
            }

            return head;
        }
    }
}
